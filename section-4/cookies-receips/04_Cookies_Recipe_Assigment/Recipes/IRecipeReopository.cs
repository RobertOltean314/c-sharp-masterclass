
using _04_Cookies_Recipe_Assigment.Recipes;

public interface IRecipeReopository
{
    List<Recipe> GetAllRecipes(string filePath);
    void WriteAllRecipes(string filePath, List<Recipe> allRecipes);
}
