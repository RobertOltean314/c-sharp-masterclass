// Trebuie sa avem un Ingredient 
// Ex: Wheat flour, Sugar, Butter, 
// Fiecare ingredient are un ID, a name si un string cu intructions on preparing
// Fiecare ingredient este parte dintr-un Recipe 


public class Ingredient
{
    public int ID { get; }
    public string Name { get; }
    public string Instructions { get; }

    public Ingredient(int id, string name, string instructions)
    {
        ID = id;
        Name = name;
        Instructions = instructions;
    }

}
