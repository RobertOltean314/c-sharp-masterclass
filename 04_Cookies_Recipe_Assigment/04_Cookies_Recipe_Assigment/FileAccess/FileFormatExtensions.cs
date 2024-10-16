namespace _04_Cookies_Recipe_Assigment.FileAccess
{
    public static class FileFormatExtensions
    {
        public static string AsFileExtension(this FileFormat fileFormat) =>
            fileFormat == FileFormat.Json ? "json" : "txt";
    }
}
