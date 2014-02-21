using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Import();

            //return;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"D:\resp.xlsx");
            xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            using (var conn = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=AutoMgrDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                conn.Open();

                decimal inventory_id = 0;
                string sql = string.Empty;
                SqlTransaction trans = conn.BeginTransaction();

                sql = string.Format("INSERT INTO inventory(branch_id, date, staff_id) VALUES(1, GETDATE(), 1)");
                using (var cmd = new SqlCommand(sql, conn, trans))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand("SELECT @@IDENTITY", conn, trans))
                {
                    inventory_id = (decimal)cmd.ExecuteScalar();
                }

                try
                {
                    for (int i = 2; i < range.Rows.Count; i++)
                    {
                        object val = (range.Cells[i, 1] as Excel.Range).Value;
                        string barcode = val != null ? string.Format("{0}", val).Trim().Replace(" ", "") : "";
                        val = (range.Cells[i, 2] as Excel.Range).Value;
                        string name = val != null ? string.Format("{0}", val).Trim() : "";
                        val = (range.Cells[i, 3] as Excel.Range).Value;
                        string model = val != null ? string.Format("{0}", val).Trim() : "";
                        val = (range.Cells[i, 4] as Excel.Range).Value;
                        string original = val != null ? string.Format("{0}", val).Trim() : "";
                        val = (range.Cells[i, 5] as Excel.Range).Value;
                        string unit = val != null ? string.Format("{0}", val).Trim() : "";
                        double? quantity = (double?)(range.Cells[i, 6] as Excel.Range).Value;
                        double? price = (double?)(range.Cells[i, 7] as Excel.Range).Value;
                        val = (range.Cells[i, 8] as Excel.Range).Value;
                        string stock = val != null ? string.Format("{0}", val).Trim() : "";
                        val = (range.Cells[i, 10] as Excel.Range).Value;
                        string brand = val != null ? string.Format("{0}", val).Trim() : "";

                        price = price == null ? 0 : price;
                        quantity = quantity == null ? 0 : quantity;

                        if (string.IsNullOrEmpty(stock))
                        {
                            stock = string.Format("temp-{0}", i);
                        }

                        decimal goods_id = 0;
                        if (!string.IsNullOrEmpty(name))
                        {
                            sql = string.Format("INSERT INTO goods(name, unit, price, brand, origin, model) VALUES('{0}', '{1}', {2}, '{3}', '{4}', '{5}')", name, unit, price, brand, original, model);
                            using (var cmd = new SqlCommand(sql, conn, trans))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            sql = "SELECT @@IDENTITY";
                            using (var cmd = new SqlCommand(sql, conn, trans))
                            {
                                goods_id = (decimal)cmd.ExecuteScalar();
                            }

                            if (!string.IsNullOrEmpty(barcode))
                            {
                                string[] barcodes = barcode.Split('/');
                                foreach (string bc in barcodes)
                                {
                                    sql = string.Format("INSERT INTO barcode_goods(goods_id, barcode) VALUES({0}, '{1}')", goods_id, bc);
                                    using (var cmd = new SqlCommand(sql, conn, trans))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            sql = string.Format("INSERT INTO shelf(branch_id, barcode, name, goods_id, quantity) VALUES(1, '{0}', '{0}', {1}, {2})", stock, goods_id, quantity);
                            using (var cmd = new SqlCommand(sql, conn, trans))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            decimal shelf_id = 0;
                            using (var cmd = new SqlCommand("SELECT @@IDENTITY", conn, trans))
                            {
                                shelf_id = (decimal)cmd.ExecuteScalar();
                            }

                            sql = string.Format("INSERT INTO shelf_io(inventory_id, shelf_id, quantity, datetime) VALUES({0}, {1}, {2}, GETDATE())", inventory_id, shelf_id, quantity);
                            using (var cmd = new SqlCommand(sql, conn, trans))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        System.Console.WriteLine(string.Format("{8} -- {7}\t{0}\t{1}\t{2}\t{3}{4:0.00}\t{5:0.00}\t{6}", name, model.Trim(), original, unit, quantity, price, stock, barcode, i));
                    }

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return;
                }

                trans.Commit();

                conn.Close();
            }

        }

        static public void Import()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"D:\resp.xlsx");
            xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            try
            {
                AutoMgrDbEntities db = new AutoMgrDbEntities();

                var inventory = new inventory()
                {
                    branch_id = 1,
                    staff_id = 1,
                    date = System.DateTime.Now,
                };
                db.inventory.Add(inventory);

                for (int i = 2; i < range.Rows.Count; i++)
                {
                    object val = (range.Cells[i, 1] as Excel.Range).Value;
                    string barcode = val != null ? string.Format("{0}", val).Trim().Replace(" ", "") : "";
                    val = (range.Cells[i, 2] as Excel.Range).Value;
                    string name = val != null ? string.Format("{0}", val).Trim() : "";
                    val = (range.Cells[i, 3] as Excel.Range).Value;
                    string model = val != null ? string.Format("{0}", val).Trim() : "";
                    val = (range.Cells[i, 4] as Excel.Range).Value;
                    string original = val != null ? string.Format("{0}", val).Trim() : "";
                    val = (range.Cells[i, 5] as Excel.Range).Value;
                    string unit = val != null ? string.Format("{0}", val).Trim() : "";
                    double? quantity = (double?)(range.Cells[i, 6] as Excel.Range).Value;
                    double? price = (double?)(range.Cells[i, 7] as Excel.Range).Value;
                    val = (range.Cells[i, 8] as Excel.Range).Value;
                    string stock = val != null ? string.Format("{0}", val).Trim() : "";
                    val = (range.Cells[i, 10] as Excel.Range).Value;
                    string brand = val != null ? string.Format("{0}", val).Trim() : "";

                    price = price == null ? 0 : price;
                    quantity = quantity == null ? 0 : quantity;

                    if (string.IsNullOrEmpty(stock))
                    {
                        stock = string.Format("temp-{0}", i);
                    }

                    System.Console.WriteLine(string.Format("{8} -- {7}\t{0}\t{1}\t{2}\t{3}{4:0.00}\t{5:0.00}\t{6}", name, model.Trim(), original, unit, quantity, price, stock, barcode, i));

                    if (!string.IsNullOrEmpty(name))
                    {
                        var goods = new goods()
                        {
                            name = name,
                            unit = unit,
                            price = (decimal)price,
                            brand = brand,
                            origin = original,
                            model = model,
                        };
                        db.goods.Add(goods);

                        if (!string.IsNullOrEmpty(barcode))
                        {
                            string[] barcodes = barcode.Split('/');
                            foreach (string bc in barcodes)
                            {
                                var bg = new barcode_goods()
                                {
                                    barcode = bc,
                                    goods = goods,
                                };
                                db.barcode_goods.Add(bg);
                            }
                        }

                        var shelf = new shelf()
                        {
                            branch_id = 1,
                            barcode = stock,
                            name = stock,
                            quantity = (decimal)quantity,
                            goods = goods,
                        };
                        db.shelf.Add(shelf);

                        var shelf_io = new shelf_io()
                        {
                            inventory = inventory,
                            shelf = shelf,
                            quantity = (decimal)quantity,
                            datetime = System.DateTime.Now,
                        };

                        db.shelf_io.Add(shelf_io);

                        db.SaveChanges();
                    }

                }

                //db.SaveChanges();
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }
    }
}
