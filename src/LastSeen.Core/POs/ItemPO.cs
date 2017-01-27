using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.POs
{
	public class ItemPO : MvxNotifyPropertyChanged
	{
		private string _id;
		public string Id
		{
			get { return _id; }
			set
			{
				_id = value;
				RaisePropertyChanged(() => Id);
			}
		}

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

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged(() => Name);
			}
		}

		private string _tag;
		public string Tag
		{
			get { return _tag; }
			set
			{
				_tag = value;
				RaisePropertyChanged(() => Tag);
			}
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				RaisePropertyChanged(() => Title);
			}
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				RaisePropertyChanged(() => Description);
			}
		}

		private int _season;
		public int Season
		{
			get { return _season; }
			set
			{
				_season = value;
				RaisePropertyChanged(() => Season);
			}
		}

		private int _episode;
		public int Episode
		{
			get { return _episode; }
			set
			{
				_episode = value;
				RaisePropertyChanged(() => Episode);
			}
		}
	}
}
