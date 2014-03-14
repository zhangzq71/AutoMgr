using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using System.Data.Services.Client;
using Microsoft.Practices.ServiceLocation;

namespace AutoMgrW8.Converter
{
    public class RepairFtyIsenableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolValue;
            bool.TryParse(value.ToString(), out boolValue);

            if (parameter != null)
            {
                return !boolValue;
            }
            else
            {
                return boolValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
