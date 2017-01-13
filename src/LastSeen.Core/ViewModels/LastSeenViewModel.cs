using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class LastSeenViewModel : MvxViewModel
	{
		private string _bar;
		public string Bar
		{
			get { return _bar; }
			set
			{
				_bar = value;
				RaisePropertyChanged(() => Bar);
			}
		}
	}
}
