var converter = new ObjectToTextConverter();
Console.WriteLine(
converter.Convert(
    new House("123 Maple Road", 170.6, 2)));

class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();
        var properties = type
            .GetProperties()
            .Where(p => p.Name != "EqualityContract");

        return String.Join(
            ",",
            properties
            .Select(property => $"{property.Name} is {property.GetValue(obj)} ")
            );
    }
}

public record House(string Address, double Area, int Floor);