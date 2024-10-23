using _09_Assignment.DTOs;
using System.Numerics;
using System.Text.Json;

try
{
    var consoleUserInteractor = new ConsoleUserInteractor();
    var planetsStatsUserInteractor = new PlanetsStatsUserInteractor(consoleUserInteractor);

    await new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new APIDataReader(),
            consoleUserInteractor
            ),
        new PlanetsStatisticsAnalyzer(
            planetsStatsUserInteractor), planetsStatsUserInteractor
        ).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " +
        "Exception message: " + ex.Message);
}
Console.ReadKey();

public class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;

    public StarWarsPlanetsStatsApp(IPlanetsReader planetsReader, IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        foreach (var planet in planets)
        {
            Console.WriteLine(planet);
        }

        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}

public interface IPlanetsStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}

public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;
    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorsMapping = new Dictionary<string, Func<Planet, int?>>
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["water surface"] = planet => planet.SurfaceWater
        };

        var userChoice = _planetsStatsUserInteractor.ChooseStatisticsToBeShown(
            propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null ||
            !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            Console.WriteLine("Invalid choice");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                propertyNamesToSelectorsMapping[userChoice]);
        }
    }
    private static void ShowStatistics(
    IEnumerable<Planet> planets,
    string propertyName,
    Func<Planet, int?> propertySelector
    )
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);
        ShowStatistics(
            "Min",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);
    }
    private static void ShowStatistics(
    string descriptor,
    Planet selectedPlanet,
    Func<Planet, int?> propertySelector,
    string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is:" +
            $" {propertySelector(selectedPlanet)} " +
            $"(planet: {selectedPlanet.Name})");
    }
}

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IAPIDataReader _apiDataReader;

    public PlanetsFromApiReader(IAPIDataReader apiDataReader)
    {
        _apiDataReader = apiDataReader;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        const string baseAddress = "https://swapi.dev/";
        const string requestUri = "api/planets";

        var json = await _apiDataReader.Read(baseAddress, requestUri);

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }
    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public int? Population { get; }

    public Planet(
        string name,
        int diameter,
        int? surfaceWater,
        int? population
        )
    {
        if (name is null)
        {
            throw new ArgumentException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        var diameter = int.Parse(planetDto.diameter);

        int? population = planetDto.population.ToIntOrNull();
        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, surfaceWater, population);
    }
}
public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input)
    {
        return int.TryParse(input, out int resultParsed) ?
        resultParsed :
        null;
    }
}

public interface IUserInteractor
{
    void ShowMessage(string message);
    string? ReadFromUser();
}

public class ConsoleUserInteractor : IUserInteractor
{
    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChoosen);
    void ShowMessage(string message);
}

public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChoosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage("The statistics of which property would you " +
            "like to see? ");
        _userInteractor.ShowMessage(
            string.Join(
                Environment.NewLine,
                propertiesThatCanBeChoosen));
        return _userInteractor.ReadFromUser();
    }

    public void Show(IEnumerable<Planet> planets)
    {
        throw new NotImplementedException();
    }

    public void ShowMessage(string message)
    {
        throw new NotImplementedException();
    }
}