using System.Globalization;
using System.Text;

internal class TicketsAgreator
{
    private string _ticketsFolderPath;
    private readonly Dictionary<string, CultureInfo> _domainToCultureMapping = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".fr"] = new CultureInfo("fr-FR"),
        [".jp"] = new CultureInfo("jp-JP")
    };
    private readonly IFileWriter _fileWriter;
    private readonly IDocumentsReader _documentsReader;

    public TicketsAgreator(string ticketsFolderPath, IFileWriter fileWriter, IDocumentsReader documentsReader)
    {
        _ticketsFolderPath = ticketsFolderPath;
        _fileWriter = fileWriter;
        _documentsReader = documentsReader;
    }

    internal void Run()
    {
        var stringBuilder = new StringBuilder();

        var ticketsDocuments = _documentsReader.Read(_ticketsFolderPath);

        foreach (var document in ticketsDocuments)
        {
            var lines = ProccessDocument(document);
            stringBuilder.AppendLine(string.Join(Environment.NewLine, lines));
        }

        _fileWriter.Write(stringBuilder.ToString(), _ticketsFolderPath, "aggregatedTickets.txt");

    }

    private IEnumerable<String> ProccessDocument(string document)
    {
        var separator = document.Split(
            new[] { "Title:", "Date:", "Time:", "Visit us:" },
            StringSplitOptions.None);

        var domain = separator.Last().ExtractDomain();
        var ticketCulture = _domainToCultureMapping[domain];

        for (int i = 1; i < separator.Length - 3; i += 3)
        {
            yield return BuildTicketData(separator, i, ticketCulture);
        }
    }

    private static string BuildTicketData(string[] separator, int i, CultureInfo ticketCulture)
    {
        var title = separator[i];
        var dateAsString = separator[i + 1];
        var timeAsString = separator[i + 2];

        var date = DateOnly.Parse(dateAsString, ticketCulture);
        var time = TimeOnly.Parse(timeAsString, ticketCulture);

        var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
        var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);

        var ticketData = $"{title,-40}|{dateAsStringInvariant}|{timeAsStringInvariant}";

        return ticketData;
    }
}
