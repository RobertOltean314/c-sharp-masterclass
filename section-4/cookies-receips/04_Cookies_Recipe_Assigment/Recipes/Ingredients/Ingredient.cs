namespace _04_Cookies_Recipe_Assigment.Recipes.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int ID { get; }
        public abstract string Name { get; }
        public virtual string PreparationInstructions => "Add to other ingredients";
        public override string ToString()
        {
            return $"{ID}.{Name}";
        }
    }
}
