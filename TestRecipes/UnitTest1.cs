using RecipeApp.Classes;

namespace TestRecipes
{
    public class UnitTest1
    {
        
        [Fact]
        public void CanAddRecipeToList()
        {
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));
        }

        [Fact]
        public void CanAddMultipleRecipesToList()
        {
            Recipe recipe = new Recipe("pie", "Bake");
            Recipe recipe2 = new Recipe("pie2", "Bake2");

            recipe.AddRecipe();
            recipe2.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe) && App.Recipes.Contains(recipe2));
        }

        [Fact]
        public void CanRemoveRecipeFromList()
        {
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.RemoveRecipe();

            Assert.False(App.Recipes.Contains(recipe));
        }

        [Fact]
        public void CanRemoveMultipleRecipesFromList()
        {
            Recipe recipe = new Recipe("pie", "Bake");
            Recipe recipe2 = new Recipe("pie2", "Bake2");

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
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();

            Assert.True(recipe.CheckIfOwned());
        }

        [Fact]
        public void CheckIfOwnedReturnsFalseAfterRemovingRecipe()
        {
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();
            recipe.RemoveRecipe();

            Assert.False(recipe.CheckIfOwned());
        }

        [Fact]
        public void CheckIfEditRecipeWorks()
        {
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.EditRecipe("pie", "Cook");

            Assert.True(recipe.Name == "pie" && recipe.Instructions == "Cook");
        }


        [Fact]
        public void CheckIfEditRecipeWorksWithTwoEdits()
        {
            Recipe recipe = new Recipe("pie", "Bake");

            recipe.AddRecipe();

            Assert.True(App.Recipes.Contains(recipe));

            recipe.EditRecipe("pie", "Cook");
            recipe.EditRecipe("pie", "Make");


            Assert.True(recipe.Name == "pie" && recipe.Instructions == "Make");
        }
    }
}
