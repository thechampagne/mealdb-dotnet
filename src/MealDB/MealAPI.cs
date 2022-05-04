using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MealDB
{
    /// <summary>
    /// TheMealDB API client
    /// <br/>
    /// An open, crowd-sourced database
    /// of Recipes from around the world.
    /// </summary>
    public class MealAPI
    {
        private static string Http(string endpoint)
        {
            try
            {
                HttpWebRequest client = (HttpWebRequest) WebRequest.Create($"https://themealdb.com/api/json/v1/1/{endpoint}");
                client.Method = "GET";
                var webResponse = client.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                var response = responseReader.ReadToEnd();
                responseReader.Close();
                responseReader.Dispose();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Search Meal by name.
        /// </summary>
        /// <param name="s">Meal name.</param>
        /// <returns>List of <see cref="Meal"/></returns>
        public static List<Meal> Search(string s)
        {
            try
            {
                var response = Http($"search.php?s={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    Meals meal = JsonConvert.DeserializeObject<Meals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Meal> list = new List<Meal>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search meals by first letter.
        /// </summary>
        /// <param name="c">Meals letter.</param>
        /// <returns>List of <see cref="Meal"/></returns>
        public static List<Meal> SearchByLetter(char c)
        {
            try
            {
                var response = Http($"search.php?f={c}");
                if (response != null && response.Length != 0)
                {
                    Meals meal = JsonConvert.DeserializeObject<Meals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Meal> list = new List<Meal>();
                        foreach (var i in meal.meals)
                        {
                            list.Add(i);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Search meal details by id.
        /// </summary>
        /// <param name="l">Meal id.</param>
        /// <returns><see cref="Meal"/></returns>
        public static Meal SearchByID(long l)
        {
            try
            {
                var response = Http($"lookup.php?i={l}");
                if (response != null && response.Length != 0)
                {
                    Meals meal = JsonConvert.DeserializeObject<Meals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        return meal.meals[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Search a random meal.
        /// </summary>
        /// <returns><see cref="Meal"/></returns>
        public static Meal Random()
        {
            try
            {
                var response = Http("random.php");
                if (response != null && response.Length != 0)
                {
                    Meals meal = JsonConvert.DeserializeObject<Meals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        return meal.meals[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the meals categories.
        /// </summary>
        /// <returns>List of <see cref="Category"/></returns>
        public static List<Category> MealCategories()
        {
            try
            {
                var response = Http("categories.php");
                if (response != null && response.Length != 0)
                {
                    Categories meal = JsonConvert.DeserializeObject<Categories>(response);
                    if (meal.categories != null && meal.categories.Count != 0)
                    {
                        List<Category> list = new List<Category>();
                        foreach (var c in meal.categories)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by ingredient.
        /// </summary>
        /// <param name="s">Ingredient name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByIngredient(string s)
        {
            try
            {
                var response = Http($"filter.php?i={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterMeals meal = JsonConvert.DeserializeObject<FilterMeals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by Area.
        /// </summary>
        /// <param name="s">Area name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByArea(string s)
        {
            try
            {
                var response = Http($"filter.php?a={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterMeals meal = JsonConvert.DeserializeObject<FilterMeals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by Category.
        /// </summary>
        /// <param name="s">Category name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByCategory(string s)
        {
            try
            {
                var response = Http($"filter.php?c={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterMeals meal = JsonConvert.DeserializeObject<FilterMeals>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// List the categories filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> CategoriesFilter()
        {
            try
            {
                var response = Http("list.php?c=list");
                if (response != null && response.Length != 0)
                {
                    CategoriesFilter meal = JsonConvert.DeserializeObject<CategoriesFilter>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c.strCategory);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// List the ingredients filter.
        /// </summary>
        /// <returns>List of <see cref="Ingredient"/></returns>
        public static List<Ingredient> IngredientsFilter()
        {
            try
            {
                var response = Http("list.php?i=list");
                if (response != null && response.Length != 0)
                {
                    Ingredients meal = JsonConvert.DeserializeObject<Ingredients>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<Ingredient> list = new List<Ingredient>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the area filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> AreaFilter()
        {
            try
            {
                var response = Http("list.php?a=list");
                if (response != null && response.Length != 0)
                {
                    AreaFilter meal = JsonConvert.DeserializeObject<AreaFilter>(response);
                    if (meal.meals != null && meal.meals.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in meal.meals)
                        {
                            list.Add(c.strArea);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}