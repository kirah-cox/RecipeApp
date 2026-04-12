namespace RecipeApp.Classes
{
    public static class ShoppingList
    {
        public static Dictionary<Ingredient, int> Ingredients = new Dictionary<Ingredient, int>();
        public static decimal TotalPrice = 0;

        public static void CreateShoppingList()
        {  
            Ingredients.Clear();
            TotalPrice = 0;
            foreach (var recipe in App.Recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    CheckIfUserHasIngredient(recipe, ingredient);
                }
            }
        }

        public static void RemoveShoppingList()
        {
            Ingredients.Clear();
            TotalPrice = 0;
        }

        public static void AddToShoppingList(Ingredient ingredient, int amount)
        {
            if (Ingredients.ContainsKey(ingredient))
            {
                Ingredients[ingredient] += amount;
            }
            else
            {
                Ingredients.Add(ingredient, amount);
            }
            TotalPrice += ingredient.Price;
        }

        public static void RemoveFromShoppingList(Ingredient ingredient, int amount)
        {
            if (Ingredients.ContainsKey(ingredient))
            {
                Ingredients[ingredient] -= amount;
                if (Ingredients[ingredient] <= 0)
                {
                    Ingredients.Remove(ingredient);
                }
                TotalPrice -= ingredient.Price * amount;
            }
        }

        private static void CheckIfUserHasIngredient(Recipe recipe, KeyValuePair<Ingredient, int> ingredient)
        {
            if (App.Ingredients.ContainsKey(ingredient.Key) && App.Ingredients[ingredient.Key] > 0)
            {
                UserHasIngredient(recipe, ingredient);
            }
            else
            {
                UserDoesNotHaveIngredient(ingredient);
            }
        }

        private static void UserHasIngredient(Recipe recipe, KeyValuePair<Ingredient, int> ingredient)
        {
            if (recipe.Ingredients[ingredient.Key] > App.Ingredients[ingredient.Key])
            {
                int neededAmount = recipe.Ingredients[ingredient.Key] - App.Ingredients[ingredient.Key];

                for (int i = 0; i < neededAmount; i++)
                {
                    if (Ingredients.ContainsKey(ingredient.Key))
                    {
                        Ingredients[ingredient.Key]++;
                    }
                    else
                    {
                        Ingredients.Add(ingredient.Key, 1);
                    }
                    TotalPrice += ingredient.Key.Price;
                }
            }
        }

        private static void UserDoesNotHaveIngredient(KeyValuePair<Ingredient, int> ingredient)
        {
            if (Ingredients.ContainsKey(ingredient.Key))
            {
                Ingredients[ingredient.Key] += ingredient.Value;
            }
            else
            {
                Ingredients.Add(ingredient.Key, ingredient.Value);
            }
            TotalPrice += ingredient.Key.Price * ingredient.Value;
        }
    }
}
