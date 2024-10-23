using System.Text.Json;

namespace _04_Cookies_Recipe_Assigment.DataAccess
{
    public class StringsJsonRespository : StringsRespository
    {
        protected override string StringsToText(List<string> strings)
        {
            return JsonSerializer.Serialize(strings);
        }

        protected override List<string> TextToStrings(string fileContent)
        {
            return JsonSerializer.Deserialize<List<string>>(fileContent);
        }
    }
}
