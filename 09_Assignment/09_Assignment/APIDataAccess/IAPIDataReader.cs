public interface IAPIDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}
