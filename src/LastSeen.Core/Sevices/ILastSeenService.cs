using System.Collections.Generic;
using LastSeen.Core.POs;

namespace LastSeen.Core.Sevices
{
	public interface ILastSeenService
	{
		Dictionary<string, List<ItemPO>> GetItems();
		ItemPO GetItem(string id);
		void SaveItem(ItemPO itemPo);
		void DeleteItem(ItemPO itemPo);
	}
}
