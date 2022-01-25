using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Week7.WPF.AppBase.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        //adesso invece che avere due tipi di base abbiamo (tipo base <-> proprietà)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string target_Type = targetType.ToString();
            string received_Type = value.GetType().ToString();

            bool v = System.Convert.ToBoolean(value);
            return v ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //usiamo una particolarità del binding, il do nothing
            return Binding.DoNothing;
        }
    }
}
