using System.Text.Json;

namespace RecipeApp.Classes
{
    public class App
    {
        public static List<Recipe> Recipes = new List<Recipe>();

        public static Dictionary<Ingredient, int> Ingredients = new Dictionary<Ingredient, int>();
        private static List<Recipe> ReadFromRecipes()
        {
            string jsonStringRecipe = File.ReadAllText("recipes.json");
            List<Recipe> recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonStringRecipe);
            return recipes;
        }
        private static Dictionary<Ingredient, int> ReadFromIngredients()
        {
            string jsonStringIngredients = File.ReadAllText("ingredients.json");
            Dictionary<Ingredient, int> ingredients = JsonSerializer.Deserialize<Dictionary<Ingredient, int>>(jsonStringIngredients);
            return ingredients;
        }
        private static void WriteToJson()
        {
            string jsonStringRecipe = JsonSerializer.Serialize(Recipes);
            File.WriteAllText("recipes.json", jsonStringRecipe);

            string jsonStringIngredients = JsonSerializer.Serialize(Ingredients);
            File.WriteAllText("ingredients.json", jsonStringIngredients);
        }
        
    }

}
