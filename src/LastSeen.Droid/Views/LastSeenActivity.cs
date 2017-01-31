using Android.App;
using Android.OS;
using LastSeen.Core.ViewModels;
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
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.lastSeenView);
		}
	}
}