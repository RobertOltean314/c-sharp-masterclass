namespace _04_Cookies_Recipe_Assigment.Recipes.Ingredients
{
    public class Butter : Ingredient
    {
        public override int ID => 3;
        public override string Name => "Butter";
        public override string PreparationInstructions => $"Melt on low heat. {base.PreparationInstructions}";
    }
}
