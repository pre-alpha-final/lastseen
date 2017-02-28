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
			SaveCommand = new MvxCommand(Save);
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

		public IMvxCommand SaveCommand { get; }
		private void Save()
		{
			_lastSeenService.SaveItem(ItemPo);
			ShowViewModel<LastSeenViewModel>();
		}
	}
}
