using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class MainActivityViewModel : MvxViewModel
	{
		public override void Start()
		{
			ShowViewModel<LastSeenViewModel>();
		}
	}
}
