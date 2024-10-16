namespace _04_Cookies_Recipe_Assigment.DataAccess
{
    public abstract class StringsRespository : IStringsRespository
    {
        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                return TextToStrings(fileContent);
            }
            return new List<string>();
        }

        protected abstract List<string> TextToStrings(string fileContent);
        protected abstract string StringsToText(List<string> strings);

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringsToText(strings));
        }
    }
}
