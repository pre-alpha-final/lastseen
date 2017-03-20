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

		public ItemPO GetItem(string id)
		{
			EnsureLoaded();
			return Mapper.Map<ItemPO>(_lastSeenItems.FirstOrDefault(e => e.Id == id));
		}

		public void SaveItem(ItemPO itemPo)
		{
			EnsureLoaded();
			var newItem = Mapper.Map<LastSeenItem>(itemPo);
			var oldItem = _lastSeenItems.FirstOrDefault(e => e.Id == newItem.Id);
			var index = _lastSeenItems.IndexOf(oldItem);
			if (index != -1)
				_lastSeenItems[index] = newItem;
			else
			{
				_lastSeenItems.Add(newItem);
			}
			SaveAllItems();
		}

		public void DeleteItem(ItemPO itemPo)
		{
			EnsureLoaded();
			var item = _lastSeenItems.FirstOrDefault(e => e.Id == itemPo.Id);
			_lastSeenItems.Remove(item);

			SaveAllItems();
		}

		private void SaveAllItems()
		{
			_dataStorage.Write(DataFile, _lastSeenItems);
		}

		private void EnsureLoaded()
		{
			if (_lastSeenItems != null)
				return;

			_lastSeenItems = _dataStorage.Read<List<LastSeenItem>>(DataFile);

			if (_lastSeenItems == null)
			{
				_lastSeenItems = new List<LastSeenItem>
				{
					new LastSeenItem(true),
				};
			}
		}
	}
}
