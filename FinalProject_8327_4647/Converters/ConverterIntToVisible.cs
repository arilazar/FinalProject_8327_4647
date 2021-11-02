using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FinalProject_8327_4647.Converters
{
    public class ConverterterToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Visibility.Visible;

            if (value != null && (int)value > 0)
                result = Visibility.Collapsed;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ConverterterToNotVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Visibility.Visible;

            if (value != null && (int)value > 0)
                result = Visibility.Collapsed;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
