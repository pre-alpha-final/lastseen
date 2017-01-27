using System.Collections.Generic;
using System.Linq;
using LastSeen.Core.Infrastructure.Deserialization;
using LastSeen.Core.POs;

namespace LastSeen.Core.Sevices.Implementations
{
	public class LastSeenService : ILastSeenService
	{
		private const string DataFile = "LastSeen.data";
		private List<LastSeenItem> _lastSeenItems;
		private List<string> _sections;
		private readonly IDataStorage _dataStorage;

		public LastSeenService(IDataStorage dataStorage)
		{
			_dataStorage = dataStorage;
		}

		public Dictionary<string, List<ItemPO>> GetItems()
		{
			EnsureLoaded();

			var sectionDictionary = new Dictionary<string, List<ItemPO>>();
			_sections = (List<string>) _lastSeenItems.Select(e => e.Tag).Distinct();
			foreach (var section in _sections)
			{
				var items = _lastSeenItems.Where(e => e.Tag == section);
				// mapper stuff
				sectionDictionary.Add(section, //mapped stuff);
			}

			return sectionDictionary;
		}

		private void EnsureLoaded()
		{
			_lastSeenItems = _dataStorage.Read<List<LastSeenItem>>(DataFile);

			if (_lastSeenItems == null)
			{
				_lastSeenItems = new List<LastSeenItem>();
			}
		}

		private void MapperInit()
		{
			
		}
	}
}
