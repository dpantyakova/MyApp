using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace MyApp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // Возвращает `true` (элемент видим), если значение true, иначе `false` (элемент скрыт)
                return boolValue;
            }

            // Возвращает `false`, если входное значение не bool
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Поскольку метод ConvertBack может не использоваться, возвращаем false, если он вызван.
            if (value is bool boolValue)
            {
                return boolValue;
            }

            return false;
        }
    }
}
