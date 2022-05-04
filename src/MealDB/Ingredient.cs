using System.Collections.Generic;

namespace MealDB
{
    public class Ingredient
    {
        public string idIngredient;
		public string strIngredient;
		public string strDescription;
		public string strType;
    }

    class Ingredients
    {
        public List<Ingredient> meals;
    }
}