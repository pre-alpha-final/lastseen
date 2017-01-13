using Android.App;
using LastSeen.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace LastSeen.Droid.Views
{
	[Activity(Label = "LastSeen", MainLauncher = true)]
	public class LastSeenView : MvxActivity
	{
		public new LastSeenViewModel ViewModel
		{
			get { return (LastSeenViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			ViewModel.Bar = "bar";
			SetContentView(Resource.Layout.lastSeen);
		}
	}
}