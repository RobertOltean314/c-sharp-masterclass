namespace _04_Cookies_Recipe_Assigment.Recipes.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int ID => 4;
        public override string Name => "Chocolate";
        public override string PreparationInstructions => $"Melt on low heat. {base.PreparationInstructions}";
    }
}
