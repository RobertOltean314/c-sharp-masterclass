namespace _04_Cookies_Recipe_Assigment.Recipes.Ingredients
{
    public abstract class Flour : Ingredient
    {
        public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
    }
}
