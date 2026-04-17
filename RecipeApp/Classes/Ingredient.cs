namespace RecipeApp.Classes
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public Ingredient(string name, string type, decimal price)
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
                var existingIngredient = Classes.App.Ingredients
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
        }

        public bool CheckIfOwned()
        {
            var existingIngredient = Classes.App.Ingredients
            .FirstOrDefault(i =>
                i.Key.Name == this.Name &&
                i.Key.Type == this.Type &&
                i.Key.Price == this.Price);

            if (existingIngredient.Key != null)
                return true;
            
            return false;
        }
    }
}
