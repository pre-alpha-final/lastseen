using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class LastSeenViewModel : MvxViewModel
	{
		public string Image => "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png";

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
