using System.Text.Json;

namespace RecipeApp.Classes
{
    public class App
    {
        public static List<Recipe> Recipes = ReadFromRecipes("recipes.json");

        public static Dictionary<Ingredient, int> Ingredients = ReadFromIngredients("ingredients.json");
        private static List<Recipe> ReadFromRecipes(string jsonFile)
        {
            string jsonStringRecipe = File.ReadAllText(jsonFile);
            List<Recipe> recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonStringRecipe);
            return recipes;
        }
        private static Dictionary<Ingredient, int> ReadFromIngredients(string jsonFile)
        {
            string jsonStringIngredients = File.ReadAllText(jsonFile);
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
