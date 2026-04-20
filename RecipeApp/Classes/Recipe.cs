namespace RecipeApp.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public RecipeGenre Genre { get; set; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        public Recipe(string name, string instructions, RecipeGenre genre, Dictionary<Ingredient, int> ingredients) 
        {
            Name = name;
            Instructions = instructions;
            Genre = genre;
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
        public static Dictionary<Recipe, int> SuggestRecipeBasedOnIngredientsOwned()
        {
            return App.Recipes
                .ToDictionary(
                    recipe => recipe,
                    recipe => recipe.Ingredients.Count(i => App.Ingredients.Contains(i))
                )
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
        public static List<Recipe> SuggestRecipeBasedOnGenre(RecipeGenre genre)
        {
            List<Recipe> sortedRecipes = new List<Recipe>();
            foreach (Recipe recipe in App.Recipes)
            {
                if (recipe.Genre == genre)
                {
                    sortedRecipes.Add(recipe);
                }
            }
            return sortedRecipes;
        }
    }

    public enum RecipeGenre
    {
        None,
        Breakfast,
        Lunch,
        Dinner,
        Dessert
    }
}
