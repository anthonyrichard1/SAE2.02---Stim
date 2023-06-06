using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim
{
    public class DoubleToStar : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter is string && !string.IsNullOrEmpty(parameter as string))
            {
                string param = parameter as string;
                double rate = double.Parse(param.Split('|')[0]);
                int pos = int.Parse(param.Split('|')[0]);

                if (pos <= rate ) return "etoile_pleine.png";
                if (pos - 1 < rate && rate < pos) return "etoile_mi_plein.png";
            }
            return "etoile_vide.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
