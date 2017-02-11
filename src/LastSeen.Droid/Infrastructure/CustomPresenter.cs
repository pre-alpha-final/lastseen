using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using System.Collections.Generic;

namespace LastSeen.Droid.Infrastructure
{
	public class CustomPresenter : MvxAndroidViewPresenter, ICustomPresenter
	{
		// map between view-model and fragment host which creates and shows the view based on the view-model type
		private Dictionary<Type, IFragmentHost> dictionary = new Dictionary<Type, IFragmentHost>();

		public override void Show(MvxViewModelRequest request)
		{
			IFragmentHost host;
			if (dictionary.TryGetValue(request.ViewModelType, out host))
			{
				if (host.Show(request))
				{
					return;
				}
			}
			base.Show(request);
		}

		public void Register(Type viewModelType, IFragmentHost host)
		{
			dictionary[viewModelType] = host;
		}
	}
}