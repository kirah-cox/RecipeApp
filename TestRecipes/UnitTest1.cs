using RecipeApp.Classes;

namespace TestRecipes
{
    public class UnitTest1
    {
        [Fact]
        public void AddRecipeValidation()
        {
            Recipe OGRecipe = new Recipe("Test", "1.TEST");
            App NewApp = new App();
            NewApp.Recipes = new List<Recipe>();

            OGRecipe.AddRecipe();

            Assert.True(NewApp.Recipes.Contains(OGRecipe));
        }
    }
}
