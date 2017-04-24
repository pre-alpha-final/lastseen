using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace LastSeen.Droid.Converters
{
	public class IntToStringConverter : MvxValueConverter<int, string>
	{
		protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != 0 ? value.ToString() : string.Empty;
		}

		protected override int ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
		{
			int i;
			int.TryParse(value, out i);
			return i;
		}
	}
}