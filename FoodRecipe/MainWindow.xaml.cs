using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.XPath;

namespace FoodRecipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       
        public MainWindow()
        {
            InitializeComponent();
            this.About.Visibility = Visibility.Hidden;
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.About.Visibility = Visibility.Visible;
        }

        private void Setting_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Location_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Contact_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Favorite_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Tg_Btn.IsChecked = false;
        }
    }
}
