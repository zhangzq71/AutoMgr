using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AutoMgrW8.Helpers;
using System.Data.Services.Client;
using Windows.UI.Xaml.Data;
using Microsoft.Practices.ServiceLocation;

namespace AutoMgrW8.ViewModel
{
    public class VMRepairFty : ViewModelBase
    {
        private AutoMgrSvc.repair_item_detail _currentRepairItemDetail;
        private readonly INavigationService _navigationService;
        private readonly AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));

        public VMRepairFty(INavigationService navigationService)
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                _navigationService = navigationService;

                RepairCatalog = new CollectionViewSource();
            }
        }

        public bool IsPopupOpen
        {
            get { return _isPopupOpen; }
            private set
            {
                _isPopupOpen = value;
                RaisePropertyChanged();
            }
        }
        private bool _isPopupOpen;

        public bool Isediting
        {
            get { return _isEditing; }
            private set
            {
                _isEditing = value;
                RaisePropertyChanged();
            }
        }
        private bool _isEditing;

        public CollectionViewSource Departments
        {
            get { return _departments; }
            private set
            {
                _departments = value;
                RaisePropertyChanged();
            }
        }
        private CollectionViewSource _departments;

        public CollectionViewSource Repairs
        {
            get { return _repairs; }
            private set
            {
                _repairs = value;
                RaisePropertyChanged();
            }
        }
        private CollectionViewSource _repairs;

        public CollectionViewSource RepairItems
        {
            get { return _repairItems; }
            private set
            {
                _repairItems = value;
                RaisePropertyChanged();
            }
        }
        private CollectionViewSource _repairItems;

        public CollectionViewSource RepairCatalog
        {
            get { return _repairCatalog; }
            set
            {
                _repairCatalog = value;
                RaisePropertyChanged("RepairCatalog");
            }
        }
        private CollectionViewSource _repairCatalog;

        public AutoMgrSvc.repair RepairDetail
        {
            get { return _repairDetail; }
            set
            {
                _repairDetail = value;
                RaisePropertyChanged();
            }
        }
        private AutoMgrSvc.repair _repairDetail;

        /// <summary>
        /// 维修单号
        /// </summary>
        public string RepairNum
        {
            get { return _repairNum; }
            private set
            {
                _repairNum = value;
                RaisePropertyChanged();
            }
        }
        private string _repairNum;

        /// <summary>
        /// 维修项目名称
        /// </summary>
        public string RepairItemName
        {
            get { return _repairItemName; }
            private set
            {
                _repairItemName = value;
                RaisePropertyChanged();
            }
        }
        private string _repairItemName;

        /// <summary>
        /// 维修时段，从
        /// </summary>
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            private set
            {
                _dateFrom = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _dateFrom;

        /// <summary>
        /// 维修时段，到
        /// </summary>
        public DateTime DateTo
        {
            get { return _dateTo; }
            private set
            {
                _dateTo = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _dateTo;

        /// <summary>
        /// 搜索命令
        /// </summary>
        public RelayCommand<AutoMgrSvc.repair_item_detail> CommandSelectDepartment
        {
            get
            {
                if (_commandSelectDepartment == null)
                {
                    _commandSelectDepartment = new RelayCommand<AutoMgrSvc.repair_item_detail>((val) =>
                    {
                        IsPopupOpen = !IsPopupOpen;

                        _currentRepairItemDetail = val;
                    });
                }

                return _commandSelectDepartment;
            }
        }
        private RelayCommand<AutoMgrSvc.repair_item_detail> _commandSelectDepartment;

        public RelayCommand CommandRefresh
        {
            get
            {
                if (_commandRefresh == null)
                {
                    _commandRefresh = new RelayCommand(() =>
                    {
                        System.Diagnostics.Debug.WriteLine("REFRESH");
                        var catas = new DataServiceCollection<AutoMgrSvc.repair_cate>();
                        catas.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                        {
                            if (e != null)
                            {
                                RepairCatalog = new CollectionViewSource() { Source = catas };
                            }
                        });
                        var qry = from cata in _context.repair_cate.Expand("repair_cate_item/repair_item") select cata;
                        catas.LoadAsync(qry);

                        var repairItems = new DataServiceCollection<AutoMgrSvc.repair_item>();
                        repairItems.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                        {
                            if (e != null)
                            {
                                RepairItems = new CollectionViewSource() { Source = repairItems };
                            }
                        });
                        var qry1 = from item in _context.repair_item select item;
                        repairItems.LoadAsync(qry1);

                        var departments = new DataServiceCollection<AutoMgrSvc.department>();
                        departments.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                        {
                            if (e != null)
                            {
                                Departments = new CollectionViewSource() { Source = departments };
                                Departments.View.CurrentChanged += new EventHandler<object>((s1, e1) =>
                                {
                                    _currentRepairItemDetail.department = (AutoMgrSvc.department)Departments.View.CurrentItem;
                                    _currentRepairItemDetail.department_id = _currentRepairItemDetail.department.id;
                                });
                            }
                        });
                        var qry2 = from department in _context.department select department;
                        departments.LoadAsync(qry2);
                    });
                }

                return _commandRefresh;
            }
        }

        private RelayCommand _commandRefresh;

        public RelayCommand<string> CommandButton
        {
            get
            {
                if (_commandButton == null)
                {
                    _commandButton = new RelayCommand<string>((btnTitle) =>
                    {
                        switch (btnTitle)
                        {
                            case "修车接车":
                                RepairDetail = new AutoMgrSvc.repair()
                                {
                                    branch_id = 1,
                                    recv_stuff_id = 1,
                                    recv_date = DateTime.Now,
                                    quote_only = false,
                                    repair_price = 0,
                                    parts_price = 0,
                                    discount = 0,
                                    real_price = 0,
                                    vehicle = new AutoMgrSvc.vehicle()
                                    {
                                        car_num = "12345",
                                        engine_num = "54321",
                                        frame_num = "9876543",
                                        brand = "东风日产2",
                                        model = "A200",
                                        customer = new AutoMgrSvc.customer()
                                        {
                                            company = "第3运输公司",
                                            address = "广州市",
                                            phone = "13316161002",
                                        },
                                    },
                                };

                                Isediting = true;

                                //_context.AddTocustomer(RepairDetail.vehicle.customer);
                                //_context.AddTovehicle(RepairDetail.vehicle);
                                //_context.SetLink(RepairDetail.vehicle, "customer", RepairDetail.vehicle.customer);

                                //_context.AddTorepair(RepairDetail);
                                //var repair_item = new AutoMgrSvc.repair_item_detail() { department_id = 6, item_id = 1 };
                                //var repair_part = new AutoMgrSvc.repair_parts() { goods_id = 1, price = 100.00m, quote_only = false, };
                                //var repair_part1 = new AutoMgrSvc.repair_parts() { goods_id = 2, price = 120.00m, quote_only = false, };

                                //RepairDetail.repair_item_detail.Add(repair_item);
                                //RepairDetail.repair_parts.Add(repair_part);
                                //RepairDetail.repair_parts.Add(repair_part1);

                                //_context.AddTorepair_parts(repair_part);
                                //_context.AddTorepair_parts(repair_part1);
                                //_context.AddTorepair_item_detail(repair_item);

                                //_context.SetLink(RepairDetail, "vehicle", RepairDetail.vehicle);
                                //_context.SetLink(repair_item, "repair", RepairDetail);
                                //_context.SetLink(repair_part, "repair", RepairDetail);
                                //_context.SetLink(repair_part1, "repair", RepairDetail);
                                //_context.AddLink(RepairDetail, "repair_item_detail", repair_item);
                                //_context.AddLink(RepairDetail, "repair_parts", repair_part);
                                //_context.AddLink(RepairDetail, "repair_parts", repair_part1);
                                //_context.BeginSaveChanges(result => { _context.EndSaveChanges(result); }, null);
                                break;

                            case "取消接车":
                                Isediting = false;
                                break;

                            case "添加项目":
                                RepairDetail.repair_item_detail.Add(new AutoMgrSvc.repair_item_detail() { item_id = ((AutoMgrSvc.repair_item)RepairItems.View.CurrentItem).id, repair_item = (AutoMgrSvc.repair_item)RepairItems.View.CurrentItem, });
                                break;

                            case "添加类型":
                                break;

                            case "测试":
                                IsPopupOpen = !IsPopupOpen;
                                break;

                            case "搜索":
                                var repairs = new DataServiceCollection<AutoMgrSvc.repair>();
                                repairs.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) => 
                                {
                                    if (e.Error == null)
                                    {
                                        Repairs = new CollectionViewSource() { Source = repairs };
                                    }
                                });
                                //var query = from repair in _context.repair.Expand("vehicle/customer").Expand("staff").Expand("repair_item_detail/repair_item").Expand("repair_item_detail/department").Expand("repair_parts/goods") select repair;
                                var query = from repair in _context.repair.Expand("vehicle/customer").Expand("staff").Expand("repair_item_detail/repair_item").Expand("repair_item_detail/department").Expand("repair_parts/goods") select repair;
                                repairs.LoadAsync(query);
                                break;
                        }
                    });
                }

                return _commandButton;
            }
        }
        private RelayCommand<string> _commandButton;
    }
}
