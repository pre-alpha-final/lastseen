using Android.App;
using Android.OS;
using Android.Views;
using LastSeen.Core.ViewModels;
using LastSeen.Droid.Controls;
using MvvmCross.Droid.Views;

namespace LastSeen.Droid.Views
{
	[Activity(
		Label = "LastSeen",
		Name = "pl.sp.android.LastSeenActivity",
		MainLauncher = false)]
	public class LastSeenActivity : MvxActivity<LastSeenViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.lastSeenView);

			var urlButton = FindViewById<FillWidthUrlImageButton>(Resource.Id.urlbutton);
			urlButton.StandardUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Blue.png";
			urlButton.ClickedUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Green.png";
		}
	}
}