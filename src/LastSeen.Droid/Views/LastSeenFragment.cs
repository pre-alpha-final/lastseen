using Android.OS;
using LastSeen.Core.ViewModels;
using LastSeen.Droid.Controls;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using Android.Views;

namespace LastSeen.Droid.Views
{
	[MvxFragment(typeof(MainActivityViewModel), Resource.Layout.lastSeenView, ViewModelType = typeof(LastSeenViewModel), IsCacheableFragment = false)]
	public class LastSeenFragment : BaseFragment<LastSeenViewModel>
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = base.OnCreateView(inflater, container, savedInstanceState);

			var urlButton = view.FindViewById<FillWidthUrlImageButton>(Resource.Id.urlbutton);
			urlButton.StandardUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Blue.png";
			urlButton.ClickedUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Green.png";

			return view;
		}
	}
}