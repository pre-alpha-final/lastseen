using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
			_sections = _lastSeenItems.Select(e => e.Tag).Distinct().ToList();
			foreach (var section in _sections)
			{
				var items = _lastSeenItems.Where(e => e.Tag == section);
				sectionDictionary.Add(section, items.Select(Mapper.Map<ItemPO>).ToList());
			}

			return sectionDictionary;
		}

		private void EnsureLoaded()
		{
			_lastSeenItems = _dataStorage.Read<List<LastSeenItem>>(DataFile);

			if (_lastSeenItems == null)
			{
				_lastSeenItems = new List<LastSeenItem>
				{
					new LastSeenItem(true),
				};
			}
		}

		private void MapperInit()
		{
			
		}
	}
}
