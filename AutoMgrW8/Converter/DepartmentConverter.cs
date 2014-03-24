using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using System.Data.Services.Client;

namespace AutoMgrW8.Converter
{
    public class DepartmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "请点击这里安排班组";
            else
                return ((AutoMgrSvc.department)value).name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
