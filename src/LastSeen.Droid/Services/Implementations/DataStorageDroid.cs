using System;
using System.Diagnostics;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;
using LastSeen.Core.Sevices;
using Android.App;
using Java.IO;

namespace LastSeen.Droid.Sevices.Implementations
{
	public class DataStorageDroid : IDataStorage
	{
		private readonly IMvxFileStore _fileStore;
		private readonly string _filesDirectory;

		private static readonly object SyncObject = new object();

		public DataStorageDroid(IMvxFileStore fileStore)
		{
			_fileStore = fileStore;

			string packageName = Application.Context.PackageName;
			_filesDirectory = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + File.Separator + "Android" + File.Separator + "data" + File.Separator + packageName + File.Separator + "files";
			File myFilesDir = new File(_filesDirectory);
			myFilesDir.Mkdirs();
		}

		public T Read<T>(string filename)
			where T : class
		{
			lock (SyncObject)
			{
				string json;
				if (_fileStore.TryReadTextFile(MakeFilePath(filename), out json) == false)
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
				_fileStore.WriteFile(MakeFilePath(filename), json);
			}
		}

		public void Delete(string filename)
		{
			lock (SyncObject)
			{
				if (_fileStore.Exists(MakeFilePath(filename)) == false)
					return;

				_fileStore.DeleteFile(MakeFilePath(filename));
			}
		}

		private string MakeFilePath(string filename)
		{
			return _filesDirectory + File.Separator + filename;
		}
	}
}