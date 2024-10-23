
using _04_Cookies_Recipe_Assigment.Recipes;
using _04_Cookies_Recipe_Assigment.Recipes.Ingredients;

public class RecipeConsoleUserInteraction : IRecipeUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipeConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);

            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"***** {counter} *****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
        else
        {
            Console.WriteLine("No recipes found");
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie. Available ingredients are: ");

        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromTheUser()
    {
        bool exit = false;
        var ingredients = new List<Ingredient>();

        while (!exit)
        {
            Console.WriteLine("Add an ingredient by typing its ID, or type anithing else to finish");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetByID(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                exit = true;
            }
        }

        return ingredients;
    }
}