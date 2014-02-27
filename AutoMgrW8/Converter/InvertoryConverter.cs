using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using System.Data.Services.Client;

namespace AutoMgrW8.Converter
{
    public class InvertoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string rtn = "0";

            if (value != null)
            {
                decimal quantity = 0;
                DataServiceCollection<AutoMgrSvc.shelf> shelfs = (DataServiceCollection<AutoMgrSvc.shelf>)value;
                foreach (var shelf in shelfs)
                {
                    quantity += shelf.quantity;
                }

                rtn = quantity.ToString();
            }

            return rtn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
