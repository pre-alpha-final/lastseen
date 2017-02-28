using System;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using System.Collections.Generic;

namespace LastSeen.Droid.Views
{
	public abstract class BaseFragment<T> : MvxFragment<T> where T : class, IMvxViewModel
	{
		// Hack for xamarin forgetting to add DataContext back to fragment after screen rotation
		// breaks reusability of fragments though cause each fragment type has the same viewmodel attached
		public static Dictionary<Type, IMvxViewModel> ViewModels = new Dictionary<Type, IMvxViewModel>();

		protected MvxFragmentAttribute Attribute
		{
			get { return (MvxFragmentAttribute)System.Attribute.GetCustomAttribute(GetType(), typeof(MvxFragmentAttribute)); }
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (DataContext != null)
				ViewModels[typeof(T)] = (IMvxViewModel)DataContext;
			else
			{
				DataContext = ViewModels[typeof(T)];
				ViewModel = ViewModels[typeof(T)] as T;
			}
			this.EnsureBindingContextIsSet(inflater);
			return this.BindingInflate(Attribute.FragmentContentId, container, false);
		}
	}
}