using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace Iebcn.Live.Controls
{
	public class WidthToThicknessConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new Thickness(System.Convert.ToDouble(value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
