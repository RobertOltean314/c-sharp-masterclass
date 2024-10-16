using System.Reflection;

var validPerson = new Person("Jhon", 2003);
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ?
    "Person is valid" :
    "Person is invalid"
    );

Console.ReadKey();

public class Person
{
    [StringLengthValidateAttribute(2, 25)]
    public string Name { get; }
    public int YearhOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearhOfBirth = yearOfBirth;
    }
    public Person(string name)
    {
        Name = name;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class StringLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

public class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type
            .GetProperties()
            .Where(property =>
            Attribute.IsDefined(
                property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string)
            {
                throw new InvalidOperationException($"Attribute {nameof(StringLengthValidateAttribute)}" +
                    $" can only be applied to strings.");
            }
            var value = (string)propertyValue;
            var attribute = (StringLengthValidateAttribute)
                property.GetCustomAttributes(
                typeof(StringLengthValidateAttribute), true).First();

            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                Console.WriteLine($"Property {property.Name} is invalid." +
                    $"Value is {value}");
                return false;
            }
        }
        return true;
    }
}


