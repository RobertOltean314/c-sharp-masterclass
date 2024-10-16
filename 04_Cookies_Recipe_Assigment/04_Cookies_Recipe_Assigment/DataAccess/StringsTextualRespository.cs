namespace _04_Cookies_Recipe_Assigment.DataAccess
{
    public class StringsTextualRespository : StringsRespository
    {
        private static readonly string Separator = Environment.NewLine;

        protected override string StringsToText(List<string> strings)
        {
            return string.Join(Separator, strings);
        }

        protected override List<string> TextToStrings(string fileContent)
        {
            return fileContent.Split(Separator).ToList();
        }
    }
}
