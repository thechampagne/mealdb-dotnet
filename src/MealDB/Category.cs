using System.Collections.Generic;

namespace MealDB
{
    class Categories
    {
        public List<Category> categories;
    }

    public class Category
    {
        public string idCategory;
		public string strCategory;
		public string strCategoryThumb;
		public string strCategoryDescription;
    }
}