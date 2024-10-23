


using _04_Cookies_Recipe_Assigment.Recipes;

public class CookiesRecipeApp
{
    private readonly IRecipeReopository _recipeReopository;
    private readonly IRecipeUserInteraction _recipeUserInteraction; // a way to communicate with the user: via console/GUI, etc

    public CookiesRecipeApp(
        IRecipeReopository recipeReopository,
        IRecipeUserInteraction recipeUserInteraction)
    {
        _recipeReopository = recipeReopository;
        _recipeUserInteraction = recipeUserInteraction;
    }
    public void Run(string filePath)
    {
        var allRecipes = _recipeReopository.GetAllRecipes(filePath);
        _recipeUserInteraction.PrintExistingRecipes(allRecipes);

        _recipeUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipeUserInteraction.ReadIngredientsFromTheUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipeReopository.WriteAllRecipes(filePath, allRecipes);

            _recipeUserInteraction.ShowMessage("Recipe was saved successfully");
            _recipeUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipeUserInteraction.ShowMessage("No ingredients were provided. Recipe will not be saved");
        }
        _recipeUserInteraction.Exit();
    }
}