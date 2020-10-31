using FoodRecipe.DAO;
using FoodRecipe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoodRecipe
{
    /// <summary>
    /// Interaction logic for TestDAO.xaml
    /// </summary>
    public partial class TestDAO : Window
    {
        public TestDAO()
        {
            InitializeComponent();
            LoadAllFood();
        }

        public void LoadAllFood()
        {
            //int num = FoodDAO.Instance.GetNumOfFoodWithFilter(null,null,"Miền Trung");
            //Recipe l = RecipeDAO.Instance.GetRecipe(1);

            //dataGrid.Items.Add(num.ToString());

            Food food = FoodDAO.Instance.GetByID(1);
            food.IsFavor = true;
            food.FavorChanged();
            
        
            

        }
          
    }
}
