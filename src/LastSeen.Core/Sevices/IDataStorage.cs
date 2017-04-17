namespace LastSeen.Core.Sevices
{
	public interface IDataStorage
	{
		T Read<T>(string filename) where T : class;
		void Write(string filename, object obj);
		void Delete(string filename);
	}
}