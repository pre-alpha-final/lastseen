using System;
using System.Globalization;
using Android.Views;
using MvvmCross.Platform.Converters;

namespace LastSeen.Droid.Converters
{
	public class IntToVisibilityConverter : MvxValueConverter<int, ViewStates>
	{
		protected override ViewStates Convert(int value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != 0 ? ViewStates.Visible : ViewStates.Gone;
		}
	}
}