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
            App.Recipes.Add(this);
        }
        public void RemoveRecipe() 
        { 
            if(App.Recipes.Contains(this)) 
                App.Recipes.Remove(this);
        }
        public bool CheckIfOwned()
        {
            if (App.Recipes.Contains(this))
                return true;
            return false;
        }
        public void EditRecipe(String newName, String newInstructions)
        {
            this.Name = newName;
            this.Instructions = newInstructions;
        }
    }
}
