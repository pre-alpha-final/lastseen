using LastSeen.Core.Sevices;
using LastSeen.Core.Sevices.Stubs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace LastSeen.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.LazyConstructAndRegisterSingleton<ILastSeenService, LastSeenServiceStub>();
		}
	}
}
