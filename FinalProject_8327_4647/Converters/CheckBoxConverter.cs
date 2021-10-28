using System;
using System.Globalization;
using System.Windows.Data;

namespace FinalProject_8327_4647.Converters
{
    public class CheckBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = bool.FalseString.ToString();

            if (value != null)
            {
                if (value.ToString() == "true")
                    result = bool.TrueString.ToString();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
