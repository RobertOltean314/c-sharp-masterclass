namespace _04_Cookies_Recipe_Assigment.DataAccess
{
    public interface IStringsRespository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }
}
