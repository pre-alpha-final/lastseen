using Android.Content;
using LastSeen.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace LastSeen.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}