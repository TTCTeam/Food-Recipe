using FoodRecipe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipe.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance = null;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }

            set => instance = value;
        }

        private FoodDAO() { }

        public List<Food> GetAll()
        {
            List<Food> foodList = new List<Food>();

            string query = "SELECT * FROM Food";

            try
            {
                DataTable data = DataProvider.Instance.ExcuteQuery(query);
                foreach (DataRow row in data.Rows)
                {
                    string foodID = (string)row["FoodID"];

                    Recipe recipe = RecipeDAO.Instance.GetRecipe(foodID);

                    List<Ingredient> ingredients = IngredientDAO.Instance.GetAll(foodID);

                    Food food = new Food(row, recipe, ingredients);
                    foodList.Add(food);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Excute GetAllFood failed", e);
            }

            return foodList;
        }

        public List<Food> GetListFoodWithoutDetail()
        {
            List<Food> foodList = new List<Food>();

            string query = "SELECT * FROM Food";

            try
            {
                DataTable data = DataProvider.Instance.ExcuteQuery(query);
                foreach (DataRow row in data.Rows)
                {
                    Food food = new Food(row);
                    foodList.Add(food);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Excute GetListFoodWithoutDetail failed", e);
            }

            return foodList;
        }

        public void GetDetail(ref Food food)
        {
            if (food.FoodID!=null)
            {
                Recipe recipe = RecipeDAO.Instance.GetRecipe(food.FoodID);

                List<Ingredient> ingredients = IngredientDAO.Instance.GetAll(food.FoodID);

                food.Recipe = recipe;
                food.Ingredients = ingredients;
            }
        }
    }
}
