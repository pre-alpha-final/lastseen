using Android.OS;
using Android.Views;
using LastSeen.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;

namespace LastSeen.Droid.Views
{
	[MvxFragment(typeof(MainActivityViewModel), Resource.Layout.addEditView, IsCacheableFragment = false)]
	class AddEditFragment : BaseFragment<AddEditViewModel>
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}