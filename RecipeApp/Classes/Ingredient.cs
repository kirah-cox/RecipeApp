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

        public void AddIngredient()
        {
            if (!CheckIfOwned())
            {
                App.Ingredients.Add(this, 1);
            }
            else
            {
                App.Ingredients[this]++;
            }
        }

        public void RemoveIngredient()
        {
            if (CheckIfOwned())
            {
                App.Ingredients[this]--;
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
