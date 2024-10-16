public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        this._logFileName = logFileName;
    }

    public void Log(Exception ex)
    {
        var entry =
$@"[{DateTime.Now}]
Exception Message: {ex.Message}
Stack Trace: {ex.StackTrace}
";
        File.AppendAllText(this._logFileName, entry);
    }
}