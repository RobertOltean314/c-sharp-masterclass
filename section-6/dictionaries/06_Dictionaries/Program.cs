var countryToCurrencyMapping = new Dictionary<string, string>()
{
    ["USA"] = "USDT",
    ["India"] = "INR",
    ["Romania"] = "RON",
};

//countryToCurrencyMapping.Add("USA", "USDT");
//countryToCurrencyMapping.Add("India", "INR");
//countryToCurrencyMapping.Add("Romania", "RON");

// Console.WriteLine($"Currency in Spain is " + countryToCurrencyMapping["Spain"]);

//foreach (var countryToCurrencyPair in countryToCurrencyMapping)
//{
//    Console.WriteLine($"Country: {countryToCurrencyPair.Key}, " +
//        $"currency: {countryToCurrencyPair.Value}");
//}

var employees = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 25000),
    new Employee("Anaa Blake", "Space Navigation", 29000),
    new Employee("Barbara Oak", "Xenobiology", 21500),
    new Employee("Damien Parker", "Xenobiology", 22000),
    new Employee("Nisha Patel", "Machanics", 21000),
    new Employee("Gustavo Sanchez", "Machanics", 20000),
};

var result = CalculateAverageSalaryPerDepartment(employees);

Console.ReadKey();

Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();

    foreach (var employee in employees)
    {
        if (!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();

        }
        employeesPerDepartments[employee.Department].Add(employee);
    }

    var result = new Dictionary<string, decimal>();

    foreach (var employeesPerDepartment in employeesPerDepartments)
    {
        decimal sumOfSlaries = 0;

        foreach (var employee in employeesPerDepartment.Value)
        {
            sumOfSlaries += employee.MonthlySalary;
        }

        var average = sumOfSlaries / employeesPerDepartment.Value.Count;

        result[employeesPerDepartment.Key] = average;
    }

    return result;
}

public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public string Name { get; init; }
    public string Department { get; init; }
    public decimal MonthlySalary { get; init; }
}