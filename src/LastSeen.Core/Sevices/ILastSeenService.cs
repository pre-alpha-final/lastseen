using System.Collections.Generic;
using LastSeen.Core.POs;

namespace LastSeen.Core.Sevices
{
	interface ILastSeenService
	{
		Dictionary<string, List<ItemPO>> GetItems();
	}
}
