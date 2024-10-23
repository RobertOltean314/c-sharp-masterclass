
using _04_Cookies_Recipe_Assigment.Recipes;
using _04_Cookies_Recipe_Assigment.Recipes.Ingredients;

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromTheUser();
}
