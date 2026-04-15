namespace RecipeApp.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        public Recipe(string name, string instructions, Dictionary<Ingredient, int> ingredients) 
        {
            Name = name;
            Instructions = instructions;
            Ingredients = ingredients;
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
        public void EditRecipe(string newName, string newInstructions, Dictionary<Ingredient, int> newIngredients)
        {
            this.Name = newName;
            this.Instructions = newInstructions;
            this.Ingredients = newIngredients;
        }
        public static Dictionary<Recipe, int> SuggestRecipeBasedOnIngredients()
        {
            Dictionary<Recipe, int> allRecipes = new Dictionary<Recipe, int>();
            foreach (Recipe recipe in App.Recipes)
            {
                allRecipes.Add(recipe, 0);
                foreach(var ingredient in App.Ingredients)
                {
                    if(recipe.Ingredients.Contains(ingredient))
                    {
                        allRecipes[recipe] += 1;
                    }
                }
            }
            allRecipes.OrderBy(x => x.Value);
            return allRecipes;
        }
    }
}
