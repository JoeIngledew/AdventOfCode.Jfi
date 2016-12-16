namespace AdventOfCode.Day152015
{
    using System.Collections.Generic;
    using System.Linq;

    public class ScienceForHungryPeople
    {
        private List<Ingredient> _ingredients;

        public void Setup(string input)
        {
            _ingredients = new List<Ingredient>();

            var splitIn = input.Replace("\r", "").Split('\n');

            foreach (var line in splitIn)
            {
                var splitLn = line.Split(' ');
                var name = splitLn[0].Replace(":", "");
                var capacity = int.Parse(splitLn[2].Replace(",", ""));
                var durability = int.Parse(splitLn[4].Replace(",", ""));
                var flavour = int.Parse(splitLn[6].Replace(",", ""));
                var texture = int.Parse(splitLn[8].Replace(",", ""));
                var calories = int.Parse(splitLn[10]);
                _ingredients.Add(new Ingredient(name, capacity, durability, flavour, texture, calories));
            }
        }

        public List<KeyValuePair<Ingredient, int>> GetBestRecipe(List<List<KeyValuePair<Ingredient, int>>> allPossibleRecipes)
        {
            var highestTotal = 0;
            List<KeyValuePair<Ingredient, int>> bestCombo = new List<KeyValuePair<Ingredient, int>>();

            foreach (var recipe in allPossibleRecipes)
            {
                var total = GetTotalVal(recipe);

                if (total > highestTotal)
                {
                    bestCombo = recipe;
                    highestTotal = total;
                }
            }

            return bestCombo;
        }

        public List<KeyValuePair<Ingredient, int>> GetBestRecipeWithRightCalories(
            List<List<KeyValuePair<Ingredient, int>>>  allPossible,
            int numCals)
        {
            var highestTotal = 0;
            List<KeyValuePair<Ingredient, int>> bestCombo = new List<KeyValuePair<Ingredient, int>>();

            foreach (var recipe in allPossible)
            {
                if (HasRightCals(recipe, numCals))
                {
                    var total = GetTotalVal(recipe);

                    if (total > highestTotal)
                    {
                        bestCombo = recipe;
                        highestTotal = total;
                    }
                }
            }

            return bestCombo;
        }

        public int GetTotalVal(List<KeyValuePair<Ingredient, int>> recipe)
        {
            var capacity = recipe.Sum(k => k.Key.Capacity * k.Value);
            var durability = recipe.Sum(k => k.Key.Durability * k.Value);
            var flavour = recipe.Sum(k => k.Key.Flavour * k.Value);
            var texture = recipe.Sum(k => k.Key.Texture * k.Value);

            if (capacity < 0) capacity = 0;
            if (durability < 0) durability = 0;
            if (flavour < 0) flavour = 0;
            if (texture < 0) texture = 0;

            return capacity * durability * flavour * texture;
        }

        public bool HasRightCals(List<KeyValuePair<Ingredient, int>> recipe, int target)
        {
            var calories = recipe.Sum(k => k.Key.Calories * k.Value);

            return calories == target;
        }

        public List<List<KeyValuePair<Ingredient, int>>> GetAllPossibleRecipes()
        {
            List<List<KeyValuePair<Ingredient, int>>> setsOfIngredients = 
                (from i in Enumerable.Range(0, 100)
                from j in Enumerable.Range(0, (100 - i))
                from k in Enumerable.Range(0, (100 - j))
                let l = 100 - (i + j + k)
                select
                    new List<KeyValuePair<Ingredient, int>>
                    {
                        new KeyValuePair<Ingredient,int>(
                            _ingredients[0],
                            i),
                        new KeyValuePair<Ingredient,int>(
                            _ingredients[1],
                            j),
                        new KeyValuePair<Ingredient,int>(
                            _ingredients[2],
                            k),
                        new KeyValuePair<Ingredient,int>(
                            _ingredients[3],
                            l),
                    })
                .ToList();

            return setsOfIngredients;
        }
    }

    public class Ingredient
    {
        public Ingredient(string name, int capacity, int durability, int flavour, int texture, int calories)
        {
            Name = name;
            Capacity = capacity;
            Durability = durability;
            Flavour = flavour;
            Texture = texture;
            Calories = calories;
        }

        public string Name { get; }
        public int Capacity { get; }
        public int Durability { get; }
        public int Flavour { get; }
        public int Texture { get; }
        public int Calories { get; }
    }
}