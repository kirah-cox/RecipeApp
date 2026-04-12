

using RecipeApp.Classes;

namespace TestIngredients
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddIngredientToDictionary()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(App.Ingredients.ContainsKey(ingredient));
        }

        [Fact]
        public void CanAddMultipleIngredientsToDictionary()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(2);

            Assert.True(App.Ingredients[ingredient] == 2);
        }

        [Fact]
        public void CanRemoveIngredientFromDictionary()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(App.Ingredients.ContainsKey(ingredient));

            ingredient.RemoveIngredient(1);

            Assert.True(App.Ingredients[ingredient] == 0);
        }

        [Fact]
        public void CanRemoveMultipleIngredientFromDictionary()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(2);

            Assert.True(App.Ingredients[ingredient] == 2);

            ingredient.RemoveIngredient(2);

            Assert.True(App.Ingredients[ingredient] == 0);
        }

        [Fact]
        public void CheckIfOwnedWorks()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(ingredient.CheckIfOwned());
        }

        [Fact]
        public void CheckIfOwnedReturnsFalseAfterRemovingAllIngredients()
        {
            Ingredient ingredient = new Ingredient("Apple", "Fruit", 0.75m);

            ingredient.AddIngredient(1);

            ingredient.RemoveIngredient(1);

            Assert.False(ingredient.CheckIfOwned());
        }
    }
}
