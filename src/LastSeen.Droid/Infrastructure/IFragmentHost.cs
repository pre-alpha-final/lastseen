using MvvmCross.Core.ViewModels;

namespace LastSeen.Droid.Infrastructure
{
	public interface IFragmentHost
	{
		bool Show(MvxViewModelRequest request);
	}
}