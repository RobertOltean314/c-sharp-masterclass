const string ticketsFolderPath = "your-file-path";

try
{
    var ticketsAggregator = new TicketsAgreator(
        ticketsFolderPath,
        new FileWriter(),
        new DocumentsFromPdfsReader());
    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An exception ocurred. " +
        "Exception message: " + ex);
}
