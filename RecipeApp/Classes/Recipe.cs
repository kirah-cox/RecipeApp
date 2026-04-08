namespace RecipeApp.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        public Recipe(string name, string instructions) 
        {
            Name = name;
            Instructions = instructions;
            Ingredients = new Dictionary<Ingredient, int>();
        }
        public void AddRecipe()
        {
            return;
        }
        public void RemoveRecipe(Recipe recipe) 
        { 
            return;
        }
        public bool CheckIfOwned(Recipe recipe)
        {
            return false;
        }
        public void EditRecipe(Recipe recipe)
        {
            return; 
        }
    }
}
