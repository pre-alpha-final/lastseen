using System.Collections.Generic;
using LastSeen.Core.POs;
using LastSeen.Core.Sevices;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace LastSeen.Core.ViewModels
{
	public class LastSeenViewModel : MvxViewModel
	{
		public LastSeenViewModel()
		{
			AddEditCommand = new MvxCommand(AddEdit);
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
			SectionDictionary = Mvx.Resolve<ILastSeenService>().GetItems();
		}

		public IMvxCommand AddEditCommand { get; }
		private void AddEdit()
		{
			ShowViewModel<AddEditViewModel>();
		}
	}
}
