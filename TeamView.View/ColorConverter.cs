using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TeamView.View
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string team = value.ToString();

            switch (team)
            {
                case "Alabama":
                    return new SolidColorBrush(Colors.Red);
                case "Ohio State":
                    return new SolidColorBrush(Colors.Pink);
                case "Florida State":
                    return new SolidColorBrush(Colors.Maroon);
                case "USC":
                    return new SolidColorBrush(Colors.Gold);
                case "Clemson":
                    return new SolidColorBrush(Colors.Orange);
                case "Penn State":
                    return new SolidColorBrush(Colors.Blue);
                case "Oklahoma":
                    return new SolidColorBrush(Colors.Red);
                case "Washington":
                    return new SolidColorBrush(Colors.Blue);
                case "Winconsin":
                    return new SolidColorBrush(Colors.Red);
                case "Oklahoma State":
                    return new SolidColorBrush(Colors.Orange);
                case "MICHIGAN":
                    return new SolidColorBrush(Colors.DarkBlue);
                case "Auburn":
                    return new SolidColorBrush(Colors.Maroon);
                default:
                    return new SolidColorBrush(Colors.Blue);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
