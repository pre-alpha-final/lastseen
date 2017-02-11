using System;
using Android.App;
using Android.OS;
using Android.Views;
using LastSeen.Core.ViewModels;
using LastSeen.Droid.Controls;
using LastSeen.Droid.Infrastructure;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Fragments;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Shared.Caching;

namespace LastSeen.Droid.Views
{
	[Activity(
		Theme = "@style/MyTheme.Base",
		Label = "LastSeen",
		Name = "pl.sp.android.LastSeenActivity",
		MainLauncher = false)]
	public class LastSeenActivity : MvxAppCompatActivity<LastSeenViewModel>, IFragmentHost, IMvxFragmentHost, IFragmentCacheableActivity
	{
		public IFragmentCacheConfiguration FragmentCacheConfiguration => new DefaultFragmentCacheConfiguration();

		public bool Close(IMvxViewModel viewModel)
		{
			return true;
		}

		public bool Show(MvxViewModelRequest request)
		{
			return true;
		}

		public bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute)
		{
			//var fragmentView = (IMvxFragmentView)Activator.CreateInstance(fragmentType);
			//fragmentView.LoadViewModelFrom(request);
			//var ft = SupportFragmentManager.BeginTransaction();
			//ft.Replace(Resource.Id.last_seen_view, fragmentView.ToFragment(), Guid.NewGuid().ToString());
			//ft.Commit();

			var fragmentView = (IMvxFragmentView)Activator.CreateInstance(fragmentType);
			fragmentView.LoadViewModelFrom(request);

			var ft = SupportFragmentManager.BeginTransaction();
			ft.Replace(Resource.Id.foo, fragmentView.ToFragment());
			ft.Commit();
			return true;
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.lastSeenView);

			var urlButton = FindViewById<FillWidthUrlImageButton>(Resource.Id.urlbutton);
			urlButton.StandardUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Blue.png";
			urlButton.ClickedUrl = "https://cdn2.iconfinder.com/data/icons/freeicons/PNG_256x256/Rectangle%20Green.png";
		}
	}
}