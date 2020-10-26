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
            List<Food> foodList = FoodDAO.Instance.GetListFoodWithoutDetail();

            dataGrid.ItemsSource = foodList;

        }
          
    }
}
