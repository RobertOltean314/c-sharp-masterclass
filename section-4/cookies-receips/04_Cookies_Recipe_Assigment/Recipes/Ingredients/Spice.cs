namespace _04_Cookies_Recipe_Assigment.Recipes.Ingredients
{
    public abstract class Spice : Ingredient
    {
        public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";

    }
}
