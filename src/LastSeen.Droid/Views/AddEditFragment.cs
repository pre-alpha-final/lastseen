using Android.OS;
using Android.Views;
using LastSeen.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;

namespace LastSeen.Droid.Views
{
	[MvxFragment(typeof(LastSeenViewModel), Resource.Layout.addEditView, IsCacheableFragment = false)]
	class AddEditFragment : MvxFragment<AddEditViewModel>
	{
		protected MvxFragmentAttribute Attribute
		{
			get { return (MvxFragmentAttribute)System.Attribute.GetCustomAttribute(GetType(), typeof(MvxFragmentAttribute)); }
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.EnsureBindingContextIsSet(inflater);
			return this.BindingInflate(Attribute.FragmentContentId, container, false);
		}
	}
}