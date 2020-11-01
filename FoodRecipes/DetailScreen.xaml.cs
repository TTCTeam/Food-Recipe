using FoodRecipe.DAO;
using FoodRecipe.DTO;
using System;
using System.Collections.Generic;
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

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for DetailScreen.xaml
    /// </summary>
    public partial class DetailScreen : Window
    {

        Food food;

        public DetailScreen(int foodID)
        {
            InitializeComponent();
            food = FoodDAO.Instance.GetByID(foodID);
        }

        

        private void DetailScreen_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = food;
            food.Recipe.StepList[1].FoodImageList.Add(new FoodImage(@"C:\Users\Minh Tan\Documents\GitHub\Food-Recipe\FoodRecipes\Images\MainScreen\background.png"));
            food.Recipe.StepList[1].FoodImageList.Add(new FoodImage(@"C:\Users\Minh Tan\Documents\GitHub\Food-Recipe\FoodRecipes\Images\MainScreen\background.png"));
            food.Recipe.StepList[1].FoodImageList.Add(new FoodImage(@"C:\Users\Minh Tan\Documents\GitHub\Food-Recipe\FoodRecipes\Images\MainScreen\background.png"));

            
            ingrediensDataGrid.ItemsSource = food.Ingredients;
            recipeListView.ItemsSource = food.Recipe.StepList.Skip(1);
            
        }
    }
}
