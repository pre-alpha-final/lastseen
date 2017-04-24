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
				RaisePropertyChanged();
			}
		}

		private string _image;
		public string Image
		{
			get { return _image; }
			set
			{
				_image = value;
				RaisePropertyChanged();
			}
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged();
			}
		}

		private string _tag;
		public string Tag
		{
			get { return _tag; }
			set
			{
				_tag = value;
				RaisePropertyChanged();
			}
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				RaisePropertyChanged();
			}
		}

		private int _season;
		public int Season
		{
			get { return _season; }
			set
			{
				_season = value;
				RaisePropertyChanged();
				RaisePropertyChanged(() => SeasonEpisode);
			}
		}

		private int _episode;
		public int Episode
		{
			get { return _episode; }
			set
			{
				_episode = value;
				RaisePropertyChanged();
				RaisePropertyChanged(() => SeasonEpisode);
			}
		}

		private int _minutesWatched;
		public int MinutesWatched
		{
			get { return _minutesWatched; }
			set
			{
				_minutesWatched = value;
				RaisePropertyChanged();
			}
		}

		public string SeasonEpisode
		{
			get { return $"S: {Season}, E: {Episode}"; }
		}
	}
}
