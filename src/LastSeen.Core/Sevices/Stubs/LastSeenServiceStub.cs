using System.Collections.Generic;
using LastSeen.Core.POs;

namespace LastSeen.Core.Sevices.Stubs
{
	class LastSeenServiceStub : ILastSeenService
	{
		public Dictionary<string, List<ItemPO>> GetItems()
		{
			var sectionDictionary = new Dictionary<string, List<ItemPO>>
			{
				{
					"SectionA", new List<ItemPO>
					{
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
				{
					"SectionB", new List<ItemPO>
					{
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
				{
					"SectionC", new List<ItemPO>
					{
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
						new ItemPO { Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png" },
					}
				},
			};
			return sectionDictionary;
		}

		public ItemPO GetItem(string id)
		{
			return new ItemPO {Name = "Name", Image = "http://www.clipartbest.com/cliparts/yTo/g7n/yTog7nLLc.png"};
		}

		public void SaveItem(ItemPO itemPo)
		{
		}

		public void DeleteItem(ItemPO itemPo)
		{
		}
	}
}
