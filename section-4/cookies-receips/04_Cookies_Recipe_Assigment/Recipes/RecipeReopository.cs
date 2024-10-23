using _04_Cookies_Recipe_Assigment.DataAccess;
using _04_Cookies_Recipe_Assigment.Recipes;
using _04_Cookies_Recipe_Assigment.Recipes.Ingredients;

public class RecipeReopository : IRecipeReopository
{
    private readonly IStringsRespository _stringsRespository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipeReopository(
        IStringsRespository stringsRespository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRespository = stringsRespository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> GetAllRecipes(string filePath)
    {
        List<string> recipesFromFile = _stringsRespository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetByID(id);
            ingredients.Add(ingredient);
        }
        return new Recipe(ingredients);
    }

    public void WriteAllRecipes(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.ID);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        _stringsRespository.Write(filePath, recipesAsStrings);
    }
}

