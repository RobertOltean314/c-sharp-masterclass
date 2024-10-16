namespace _04_Cookies_Recipe_Assigment.FileAccess
{
    public class FileMetaData
    {
        public string Name { get; }
        public FileFormat Format { get; }

        public FileMetaData(string name, FileFormat format)
        {
            Name = name;
            Format = format;
        }
        public string toPath() => $"{Name}.{Format.AsFileExtension()}";
    }
}
