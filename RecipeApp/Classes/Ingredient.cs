namespace RecipeApp.Classes
{
    public class Ingredient
    {
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public decimal Price { get; set; }

        public Ingredient(string name, IngredientType type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public void AddIngredient(int amount)
        {
            if (!CheckIfOwned())
            {
                App.Ingredients.Add(this, amount);
            }
            else
            {
                var existingIngredient = App.Ingredients
                    .FirstOrDefault(i =>
                        i.Key.Name == this.Name &&
                        i.Key.Type == this.Type &&
                        i.Key.Price == this.Price);
                App.Ingredients[existingIngredient.Key] += amount;
            }
        }

        public void RemoveIngredient(int amount)
        {
            if (CheckIfOwned())
            {
                App.Ingredients[this] -= amount;
            }

            if (App.Ingredients[this] <= 0)
            {
                App.Ingredients.Remove(this);
            }
        }

        public bool CheckIfOwned()
        {
            var existingIngredient = App.Ingredients
            .FirstOrDefault(i =>
                i.Key.Name == this.Name &&
                i.Key.Type == this.Type &&
                i.Key.Price == this.Price);

            if (existingIngredient.Key != null)
                return true;
            
            return false;
        }
    }

    public enum IngredientType
    {
        None,
        Other,
        Vegetable,
        Fruit,
        Grain,
        Legume,
        Dairy,
        Egg,
        Meat,
        Seafood,
        Poultry,
        Sweetener,
        Liquid,
        Seasoning
    }
}
