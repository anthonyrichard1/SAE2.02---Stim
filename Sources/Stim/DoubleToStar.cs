using System.Globalization;

namespace Stim.Converter
{
    public class DoubleToStar : IValueConverter
    {
        public string EtoileVide { get; set; }
        public string EtoileMiPleine { get; set; }
        public string EtoilePleine { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double && parameter is string)
            {
                double rate = double.Parse(value.ToString());
                int pos = int.Parse(parameter as string);

                if (pos <= rate) return EtoilePleine;
                if (pos - 1 < rate && rate < pos) return EtoileMiPleine;
            }
            return EtoileVide;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
