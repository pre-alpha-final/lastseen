using System.Collections.Generic;
using LastSeen.Core.POs;
using MvvmCross.Core.ViewModels;

namespace LastSeen.Core.ViewModels
{
	public class LastSeenViewModel : MvxViewModel
	{

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
			SectionDictionary = new Dictionary<string, List<ItemPO>>
			{
				{
					"SectionA", new List<ItemPO>
					{
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
				{
					"SectionB", new List<ItemPO>
					{
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
				{
					"SectionC", new List<ItemPO>
					{
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
			};
		}
	}
}
