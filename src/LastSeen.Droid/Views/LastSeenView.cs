using Android.App;
using LastSeen.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace LastSeen.Droid.Views
{
	[Activity(Label = "LastSeen", MainLauncher = true)]
	public class LastSeenView : MvxActivity<LastSeenViewModel>
	{
		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			SetContentView(Resource.Layout.lastSeen);
		}
	}
}