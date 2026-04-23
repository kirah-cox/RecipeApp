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
        public static List<(Recipe Recipe, double MatchPercent)> SuggestRecipeBasedOnIngredientsOwned()
        {
            if (App.Recipes == null || App.Ingredients == null)
                return new List<(Recipe, double)>();

            var ownedIngredientNames = App.Ingredients.Keys
                .Select(i => i.Name)
                .ToHashSet();

            return App.Recipes
                .Select(recipe =>
                {
                    var total = recipe.Ingredients.Count;
                    var matches = recipe.Ingredients.Count(i =>
                        ownedIngredientNames.Contains(i.Key.Name));

                    double percent = total == 0 ? 0 : (double)matches / total;

                    return (Recipe: recipe, MatchPercent: percent);
                })
                .OrderByDescending(x => x.MatchPercent)
                .ThenBy(x => x.Recipe.Name)
                .ToList();
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
