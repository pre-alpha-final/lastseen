using Android.App;
using Android.Content;
using MvvmCross.Droid.Views;

namespace LastSeen.Droid.Views
{
	[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : MvxActivity
	{
		protected override void OnResume()
		{
			base.OnResume();

			StartActivity(new Intent(Application.Context, typeof(LastSeenActivity)));
		}
	}
}