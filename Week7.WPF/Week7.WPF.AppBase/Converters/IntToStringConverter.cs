using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Week7.WPF.AppBase.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //conversione da intero a stringa
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //conversione da stringa a intero
            int.TryParse(value.ToString(), out int result);

            return result == 0 ? parameter : result;

            throw new NotImplementedException();
        }
    }
}
