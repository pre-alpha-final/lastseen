using System.Collections.Generic;
using LastSeen.Core.POs;
using LastSeen.Core.Sevices;
using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class LastSeenViewModel : MvxViewModel
	{
		private readonly ILastSeenService _lastSeenService;

		public LastSeenViewModel(ILastSeenService lastSeenService)
		{
			_lastSeenService = lastSeenService;
			AddCommand = new MvxCommand(Add);
			GridTapCommand = new MvxCommand<string>(GridTap);
		}

		private Dictionary<string, List<ItemPO>> _sectionDictionary;
		public Dictionary<string, List<ItemPO>> SectionDictionary
		{
			get { return _sectionDictionary; }
			set
			{
				_sectionDictionary = value;
				RaisePropertyChanged(() => SectionDictionary);
			}
		}

		public override void Start()
		{
			SectionDictionary = _lastSeenService.GetItems();
		}

		public IMvxCommand AddCommand { get; }
		private void Add()
		{
			ShowViewModel<AddEditViewModel>(new { id = "" });
		}

		public IMvxCommand GridTapCommand { get; }
		private void GridTap(string id)
		{
			ShowViewModel<AddEditViewModel>(new { id });
		}
	}
}
