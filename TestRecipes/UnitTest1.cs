using RecipeApp.Classes;

namespace TestRecipes
{
    public class UnitTest1
    {
        
        [Fact]
        public void CanAddRecipeToList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));
        }

        [Fact]
        public void CanAddMultipleRecipesToList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Dictionary<Ingredient, int> ingredients2 = new Dictionary<Ingredient, int>();
            ingredients2.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients2.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);
            Recipe recipe2 = new Recipe("pie2", "Bake2", ingredients2);

            recipe.AddRecipe();
            recipe2.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe) && App.Recipes.Contains(recipe2));
        }

        [Fact]
        public void CanRemoveRecipeFromList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.RemoveRecipe();

            Assert.False(App.Recipes.Contains(recipe));
        }

        [Fact]
        public void CanRemoveMultipleRecipesFromList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Dictionary<Ingredient, int> ingredients2 = new Dictionary<Ingredient, int>();
            ingredients2.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients2.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);
            Recipe recipe2 = new Recipe("pie2", "Bake2", ingredients2);

            recipe.AddRecipe();
            recipe2.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe) && App.Recipes.Contains(recipe2));

            recipe.RemoveRecipe();
            recipe2.RemoveRecipe();

            Assert.True(App.Recipes.Count == 0);
        }

        [Fact]
        public void CheckIfOwnedWorks()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();

            Assert.True(recipe.CheckIfOwned());
        }

        [Fact]
        public void CheckIfOwnedReturnsFalseAfterRemovingRecipe()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();
            recipe.RemoveRecipe();

            Assert.False(recipe.CheckIfOwned());
        }

        [Fact]
        public void CheckIfEditRecipeWorks()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Dictionary<Ingredient, int> ingredients2 = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("cherry", "fruit", 0.70m), 15);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.EditRecipe("pie", "Cook", ingredients2);

            Assert.True(recipe.Name == "pie" && recipe.Instructions == "Cook" && recipe.Ingredients == ingredients2);
        }


        [Fact]
        public void CheckIfEditRecipeWorksWithTwoEdits()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Dictionary<Ingredient, int> ingredients2 = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("cherry", "fruit", 0.70m), 15);

            Dictionary<Ingredient, int> ingredients3 = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("peach", "fruit", 0.70m), 4);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.EditRecipe("pie", "Cook", ingredients2);
            recipe.EditRecipe("pie", "Make", ingredients3);


            Assert.True(recipe.Name == "pie" && recipe.Instructions == "Make");
        }
        [Fact]
        public void SuggestRecipeBasedOnIngredients()
        {
            App.Recipes.Clear();
            App.Ingredients.Clear();
            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Dictionary<Ingredient, int> ingredients2 = new Dictionary<Ingredient, int>();
            ingredients2.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients2.Add(new Ingredient("peporoni", "meat", 0.70m), 3);

            App.Ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);

            Recipe recipe = new Recipe("pie", "Bake", ingredients);
            Recipe recipe2 = new Recipe("pizza", "Bake2", ingredients2);

            recipe.AddRecipe();
            recipe2.AddRecipe();

            var suggestedList = Recipe.SuggestRecipeBasedOnIngredients();
            Assert.True(suggestedList.ContainsValue(1));

        }
    }
}
