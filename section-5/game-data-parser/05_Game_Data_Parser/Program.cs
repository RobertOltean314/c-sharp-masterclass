using System.IO.Enumeration;
using System.Text.Json;

var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    logger.Log(ex);
}

Console.WriteLine("Press any key to close the window");
Console.ReadKey();


public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;

    public GameDataParserApp(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var fileContent = File.ReadAllText(fileName);
        var videoGames = DeserializeVideoGamesFrom(fileName, fileContent);
        PrintGames(videoGames);
    }

    private void PrintGames(List<VideoGame> videoGames)
    {
        if (videoGames.Count > 0)
        {
            _userInteractor.PrintMessage(string.Empty);
            _userInteractor.PrintMessage("Loaded games are: ");
            foreach (var game in videoGames)
            {
                _userInteractor.PrintMessage(game.ToString());
            }
        }
        else
        {
            _userInteractor.PrintMessage("No games has been found");
        }
    }

    private List<VideoGame> DeserializeVideoGamesFrom(string fileName, string fileContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
        }
        catch (JsonException ex)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            _userInteractor.PrintMessage($"JSON in {fileName} file was not " +
                $"in valid format. JSON body: ");
            _userInteractor.PrintMessage(fileContent);
            Console.ForegroundColor = originalColor;

            throw new JsonException($"{ex.Message} The file is {fileName}", ex);
        }
    }
}

public interface IUserInteractor
{
    string ReadValidFilePath();
    void PrintMessage(string message);
}

public class ConsoleUserInteractor : IUserInteractor
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadValidFilePath()
    {
        bool isFilePathValid = false;
        var fileName = default(string);

        do
        {
            Console.WriteLine("Please enter the name of the file you want to read: ");
            fileName = Console.ReadLine();

            if (fileName is null)
            {
                Console.WriteLine("The file name cannot be null");
            }
            else if (fileName == string.Empty)
            {
                Console.WriteLine("The file name cannot be empty");
            }
            else if (!File.Exists(fileName))
            {
                Console.WriteLine("The file does not exist");
            }
            else
            {
                isFilePathValid = true;
            }

        } while (!isFilePathValid);
        return fileName;
    }
}

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString()
    {
        return $"{Title}, Release Year: {ReleaseYear}, Rating: {Rating}";
    }
}