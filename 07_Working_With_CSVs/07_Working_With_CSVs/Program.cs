const string filePath = "C:\\Users\\EOLTEAR8G\\OneDrive - NTT DATA EMEAL\\Escritorio\\Desktop Folder\\Proiecte\\Development\\.NET\\CSharpMasterclass\\07_Working_With_CSVs\\07_Working_With_CSVs\\sampleData.csv";

var data = new CSVReader().Read(filePath);

Console.ReadKey();

public class CSVReader
{
    public CSVData Read(string filePath)
    {
        using var streamReader = new StreamReader(filePath, true);
        const string Separator = ",";
        var columns = streamReader.ReadLine().Split(Separator);

        var rows = new List<string[]>();

        while (!streamReader.EndOfStream)
        {
            var cellsInRow = streamReader.ReadLine().Split(Separator);
            rows.Add(cellsInRow);
        }

        return new CSVData(columns, rows);
    }
}

public class CSVData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CSVData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}
