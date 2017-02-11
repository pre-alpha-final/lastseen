using System;

namespace LastSeen.Droid.Infrastructure
{
	public interface ICustomPresenter
	{
		void Register(Type viewModelType, IFragmentHost host);
	}
}