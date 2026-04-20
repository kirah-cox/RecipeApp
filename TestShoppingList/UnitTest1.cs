using RecipeApp.Classes;

namespace TestShoppingList
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateShoppingList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", "Desert", ingredients);

            recipe.AddRecipe();

            ShoppingList.CreateShoppingList();

            Assert.True(ShoppingList.Ingredients != null);
            Assert.True(ShoppingList.Ingredients.Keys.Any(key => recipe.Ingredients.ContainsKey(key)));
        }

        [Fact]
        public void DoesNotAddIngredientToShoppingListIfUserAlreadyHasIngredient()
        {
            App.Recipes.Clear();
            App.Ingredients.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", "Desert", ingredients);
            recipe.AddRecipe();

            Ingredient ingredient = new Ingredient("flour", "grain", 3.00m);
            ingredient.AddIngredient(2);


            ShoppingList.CreateShoppingList();

            Assert.True(ShoppingList.Ingredients != null);
            Assert.False(ShoppingList.Ingredients.Keys.Any(key => App.Ingredients.ContainsKey(key)));
        }

        [Fact]
        public void CanRemoveShoppingList()
        {
            App.Recipes.Clear();

            Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
            ingredients.Add(new Ingredient("flour", "grain", 3.00m), 2);
            ingredients.Add(new Ingredient("apple", "fruit", 0.70m), 3);

            Recipe recipe = new Recipe("pie", "Bake", "Desert", ingredients);

            recipe.AddRecipe();

            ShoppingList.CreateShoppingList();

            Assert.True(ShoppingList.Ingredients != null);
            Assert.True(ShoppingList.Ingredients.Keys.Any(key => recipe.Ingredients.ContainsKey(key)));

            ShoppingList.RemoveShoppingList();

            Assert.True(ShoppingList.TotalPrice == 0);
            Assert.False(ShoppingList.Ingredients.Any());
        }


        [Fact]
        public void CanAddToShoppingList()
        {
            ShoppingList.CreateShoppingList();

            Ingredient ingredient = new Ingredient("flour", "grain", 3.00m);

            ShoppingList.AddToShoppingList(ingredient, 2);

            Assert.True(ShoppingList.Ingredients.ContainsKey(ingredient));
            Assert.True(ShoppingList.Ingredients[ingredient] == 2);
        }


        [Fact]
        public void CanRemoveFromShoppingList()
        {
            ShoppingList.CreateShoppingList();

            Ingredient ingredient = new Ingredient("flour", "grain", 3.00m);

            ShoppingList.AddToShoppingList(ingredient, 1);

            Assert.True(ShoppingList.Ingredients.ContainsKey(ingredient));
            Assert.True(ShoppingList.Ingredients[ingredient] == 1);

            ShoppingList.RemoveFromShoppingList(ingredient, 1);

            Assert.False(ShoppingList.Ingredients.ContainsKey(ingredient));
        }


        [Fact]
        public void CanRemoveOnlyOneFromShoppingList()
        {
            ShoppingList.CreateShoppingList();

            Ingredient ingredient = new Ingredient("flour", "grain", 3.00m);

            ShoppingList.AddToShoppingList(ingredient, 2);

            Assert.True(ShoppingList.Ingredients.ContainsKey(ingredient));
            Assert.True(ShoppingList.Ingredients[ingredient] == 2);

            ShoppingList.RemoveFromShoppingList(ingredient, 1);

            Assert.True(ShoppingList.Ingredients.ContainsKey(ingredient));
            Assert.True(ShoppingList.Ingredients[ingredient] == 1);
        }
    }
}
