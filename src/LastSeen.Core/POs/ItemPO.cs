using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.POs
{
	public class ItemPO : MvxNotifyPropertyChanged
	{
		private string _image;
		public string Image
		{
			get { return _image; }
			set
			{
				_image = value;
				RaisePropertyChanged(() => Image);
			}
		}
	}
}
