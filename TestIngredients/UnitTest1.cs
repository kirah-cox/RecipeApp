

using RecipeApp.Classes;

namespace TestIngredients
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddIngredientToDictionary()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(App.Ingredients.ContainsKey(ingredient));
        }

        [Fact]
        public void CanAddMultipleIngredientsToDictionary()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(2);

            Assert.True(App.Ingredients[ingredient] == 2);
        }

        [Fact]
        public void CanRemoveIngredientFromDictionary()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(App.Ingredients.ContainsKey(ingredient));

            ingredient.RemoveIngredient(1);

            Assert.False(App.Ingredients.ContainsKey(ingredient));
        }

        [Fact]
        public void CanRemoveMultipleIngredientFromDictionary()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(2);

            Assert.True(App.Ingredients[ingredient] == 2);

            ingredient.RemoveIngredient(2);

            Assert.False(App.Ingredients.ContainsKey(ingredient));
        }

        [Fact]
        public void CheckIfOwnedWorks()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(1);

            Assert.True(ingredient.CheckIfOwned());
        }

        [Fact]
        public void CheckIfOwnedReturnsFalseAfterRemovingAllIngredients()
        {
            App.Ingredients.Clear();

            Ingredient ingredient = new Ingredient("Apple", IngredientType.Fruit, 0.75m);

            ingredient.AddIngredient(1);

            ingredient.RemoveIngredient(1);

            Assert.False(ingredient.CheckIfOwned());
        }
    }
}
