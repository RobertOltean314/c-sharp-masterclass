// Trebuie sa avem un Ingredient 
// Ex: Wheat flour, Sugar, Butter, 
// Fiecare ingredient are un ID, a name si un string cu intructions on preparing
// Fiecare ingredient este parte dintr-un Recipe 



public static class AvailableIngredients
{
    public static void ShowAvailableIngredients(List<Ingredient> ingredients)
    {
        Console.WriteLine("Creating a new cookie recipe! Available ingredients are: ");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.ID}. {ingredient.Name}");
        }

    }
}


