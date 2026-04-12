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
                App.Ingredients[this] += amount;
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
            if (App.Ingredients.ContainsKey(this) && App.Ingredients[this] != 0)
            return true;
            
            return false;
        }
    }
}
