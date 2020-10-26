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

            string query = "select * from FOOD";

            try
            {
                DataTable data = DataProvider.Instance.ExcuteQuery(query);
                foreach (DataRow row in data.Rows)
                {
                    int foodID = (int)row["FoodID"];

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

        public List<Food> GetAllWithoutDetail()
        {
            List<Food> foodList = new List<Food>();

            string query = "select * from FOOD";

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
                throw new Exception("Excute GetAllWithoutDetail failed", e);
            }

            return foodList;
        }

        public Food GetByID(int foodID)
        {
            Food result;
            try
            {
                Recipe recipe = RecipeDAO.Instance.GetRecipe(foodID);

                List<Ingredient> ingredients = IngredientDAO.Instance.GetAll(foodID);

                string query = "select * from FOOD where FoodID = @FoodID";

                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { foodID });

                result = new Food(data.Rows[0], recipe, ingredients);
            }
            catch (Exception e)
            {
                throw new Exception("Excute GetByID failed", e);
            }

            return result;
        }
    }
}
