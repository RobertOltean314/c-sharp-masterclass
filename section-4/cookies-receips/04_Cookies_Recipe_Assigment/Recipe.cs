// Trebuie sa avem un Ingredient 
// Ex: Wheat flour, Sugar, Butter, 
// Fiecare ingredient are un ID, a name si un string cu intructions on preparing
// Fiecare ingredient este parte dintr-un Recipe 


public class Recipe
{
    private List<Ingredient> ingredients { get; }

    public Recipe()
    {
        ingredients = new List<Ingredient>();
    }

    public void AddIngredients(List<Ingredient> listOfIngredients)
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            var userInput = Console.ReadLine();
            var userChoice = int.TryParse(userInput, out int choice);

            if (userChoice && choice > 0 && choice < 9)
            {
                ingredients.Add(listOfIngredients[choice]);
            }
            else if (choice < 0 || choice > 9 || userChoice)
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            else
            {
                Console.WriteLine("Finished adding ingredients.");
                exit = true;
            }

        } while (!exit);
    }
}