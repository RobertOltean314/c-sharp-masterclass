using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();

var ints = CreateCollectionOfRndomLength<int>(0);
stopwatch.Stop();
Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");

var people = new List<Person>
{
    new Person{Name = "Alina",YearOfBirth =  1987 },
    new Person{Name= "Andrei",YearOfBirth = 2000},
    new Person{Name = "Petru",YearOfBirth = 2106 }
};

var employees = new List<Employee>
{
    new Employee{Name = "Alina",YearOfBirth =  1987 },
    new Employee{Name= "Andrei",YearOfBirth = 2000},
    new Employee{Name = "Petru",YearOfBirth = 2106 }
};

var validPeople = GetOnlyValid(people);
var validEmployees = GetOnlyValid(people);

Console.ReadKey();

IEnumerable<T> CreateCollectionOfRndomLength<T>(int maxLength) where T : new()
{
    var length = new Random().Next(maxLength + 1);

    var result = new List<T>(length);

    for (int i = 0; i < length; i++)
    {
        result.Add(new T());
    }
    return result;
}

IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> persons)
    where TPerson : Person
{
    var result = new List<TPerson>();

    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 &&
            person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }
    return result;
}

void PrinInOrder<T>(T first, T second) where T : IComparable<T>
{
    if (first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second} > {first}");
    }
    else if (first.CompareTo(second) < 0)
    {
        Console.WriteLine($"{second} < {first}");
    }
    else
    {
        Console.WriteLine($"{second} = {first}");
    }
}

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    public int CompareTo(Person other)
    {
        if (YearOfBirth < other.YearOfBirth)
        {
            return 1;
        }
        if (YearOfBirth > other.YearOfBirth)
        {
            return -1;
        }
        return 0;
    }
}

public class Employee : Person
{
    public void GoToWork() => Console.WriteLine($"Going to work");
}

