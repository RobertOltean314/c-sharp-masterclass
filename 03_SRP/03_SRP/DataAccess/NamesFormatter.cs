namespace _03_SRP.DataAccess;
class NamesFormatter
{
    public string Format(List<string> names) =>
    string.Join(Environment.NewLine, names);
}
