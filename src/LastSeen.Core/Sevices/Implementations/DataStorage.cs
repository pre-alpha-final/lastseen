using System;
using System.Diagnostics;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;

namespace LastSeen.Core.Sevices.Implementations
{
	public class DataStorage : IDataStorage
	{
		private readonly IMvxFileStore _fileStore;

		private static readonly object SyncObject = new object();

		public DataStorage(IMvxFileStore fileStore)
		{
			_fileStore = fileStore;
		}

		public T Read<T>(string filename)
			where T : class
		{
			lock (SyncObject)
			{
				string json;
				if (_fileStore.TryReadTextFile(filename, out json) == false)
					return default(T);

				try
				{
					var deserialized = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.Auto
					});
					return deserialized;
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
					return default(T);
				}
			}
		}

		public void Write(string filename, object obj)
		{
			lock (SyncObject)
			{
				var json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				});
				_fileStore.WriteFile(filename, json);
			}
		}

		public void Delete(string filename)
		{
			lock (SyncObject)
			{
				if (_fileStore.Exists(filename) == false)
					return;

				_fileStore.DeleteFile(filename);
			}
		}
	}
}