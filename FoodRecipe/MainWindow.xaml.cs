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

        class MainImage
        {
            public string About { get; set; }
            public string Add { get; set; }
            public string Background { get; set; }
            public string Close { get; set; }
            public string Close_MouseOver { get; set; }
            public string Contact { get; set; }
            public string Favorite { get; set; }
            public string Home { get; set; }
            public string Icon { get; set; }
            public string Location { get; set; }
            public string Menu { get; set; }
            public string Menu_MouseOver { get; set; }
            public string Setting { get; set; }

            public MainImage()
            {

            }

            public MainImage(string[] images)
            {
                this.About = $"Images/MainScreen/{images[0]}";
                this.Add = $"Images/MainScreen/{images[1]}";
                this.Background = $"Images/MainScreen/{images[2]}";
                this.Close = $"Images/MainScreen/{images[3]}";
                this.Close_MouseOver = $"Images/MainScreen/{images[4]}";
                this.Contact = $"Images/MainScreen/{images[5]}";
                this.Favorite = $"Images/MainScreen/{images[6]}";
                this.Home = $"Images/MainScreen/{images[7]}";
                this.Icon = $"Images/MainScreen/{images[8]}";
                this.Location = $"Images/MainScreen/{images[9]}";
                this.Menu = $"Images/MainScreen/{images[10]}";
                this.Menu_MouseOver = $"Images/MainScreen/{images[11]}";
                this.Setting = $"Images/MainScreen/{images[12]}";
            }
        }

        const string Slash = "/";
        class MainImageDao
        {
            public static MainImage GetAll()
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var filepath = $"{folder}MainImageUI.txt";
                MainImage result;
                using (var reader = new StreamReader(filepath))
                {
                    var line = reader.ReadLine();
                    string[] tokens = line.Split(new string[] { Slash }, StringSplitOptions.RemoveEmptyEntries);

                    result = new MainImage(tokens);

                }
                return result;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            MainImage inIt = MainImageDao.GetAll();

            DataContext = inIt;


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
