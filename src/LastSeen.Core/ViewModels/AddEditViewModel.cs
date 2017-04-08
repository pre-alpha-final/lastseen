using AutoMapper;
using LastSeen.Core.Infrastructure.Deserialization;
using LastSeen.Core.POs;
using LastSeen.Core.Sevices;
using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class AddEditViewModel : MvxViewModel
	{
		private readonly ILastSeenService _lastSeenService;
		private string _id;

		public ItemPO ItemPo { get; set; }

		public AddEditViewModel(ILastSeenService lastSeenService)
		{
			_lastSeenService = lastSeenService;
			DeleteCommand = new MvxCommand(Delete);
			UpdateSeasonCommand = new MvxCommand<int>(UpdateSeason);
			UpdateEpisodeCommand = new MvxCommand<int>(UpdateEpisode);
		}

		public void Init(string id)
		{
			_id = id;
		}

		public override void Start()
		{
			if (string.IsNullOrWhiteSpace(_id) == false)
				ItemPo = _lastSeenService.GetItem(_id);
			else
			{
				ItemPo = Mapper.Map<ItemPO>(new LastSeenItem(true));
			}
		}

		public IMvxCommand DeleteCommand { get; }
		private void Delete()
		{
			_lastSeenService.DeleteItem(ItemPo);
			ShowViewModel<LastSeenViewModel>();
		}

		public IMvxCommand UpdateSeasonCommand { get; }
		private void UpdateSeason(int counter)
		{
			if (ItemPo != null)
				ItemPo.Season = counter;
		}

		public IMvxCommand UpdateEpisodeCommand { get; }
		private void UpdateEpisode(int counter)
		{
			if (ItemPo != null)
				ItemPo.Episode = counter;
		}
	}
}
