using FoodRecipe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipe.DAO
{
    class StepDAO
    {
        private static StepDAO instance = null;

        public static StepDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StepDAO();
                return instance;
            }

            set => instance = value;
        }

        private StepDAO() { }

        public List<Step> GetAllAtRecipe(int foodID)
        {
            List<Step> stepList = new List<Step>();

            string query = "EXEC GetAllStepAtRecipe @foodID";

            try
            {
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { foodID });
                foreach (DataRow row in data.Rows)
                {
                    int stepIndex = data.Rows.IndexOf(row);
                    List<FoodImage> foodImageList = FoodImageDAO.Instance.GetAllAtStep(foodID, stepIndex);

                    Step Step = new Step(row, foodImageList);
                    stepList.Add(Step);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Excute GetAllStepAtRecipe failed", e);
            }

            return stepList;
        }

    }
}
