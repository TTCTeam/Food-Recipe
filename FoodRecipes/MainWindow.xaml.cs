using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region MainImage claas
        class MainImage : INotifyPropertyChanged
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

            public string Color { get; set; }

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
                this.Color = "";
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        #endregion

        const string Slash = "/";

        #region MainImageDao
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
        #endregion


        //public int page = 1;

        //Food selected;

        //string[] isFavorImage = new string[]
        //       {
        //            "like.png",
        //            "notlike.png",
        //       };

        //class StudentDao
        //{
        //    public static BindingList<Food> GetAll()
        //    {
        //        var result = new BindingList<Food>()
        //        {
        //            new Food() { Name="Chu Tùng Nhân", Image="/Images/Image01.jpg", Type = "Tráng miệng"},
        //            new Food() { Name="Nguyen Ánh Du", Image="/Images/Image02.jpg"},
        //            new Food() { Name="Lều Bách Khánh", Image="/Images/Image03.jpg"},
        //            new Food() { Name="Thiều Duy Hành", Image="/Images/Image04.jpg" },
        //            new Food() { Name="Nhiệm Băng Đoan", Image="/Images/Image05.jpg" },
        //            new Food() { Name="Mang Đình Từ", Image="/Images/Image06.jpg" },
        //            new Food() { Name="Bùi Tuyền", Image="/Images/Image07.jpg" },
        //            new Food() { Name="Triệu Triều Hải", Image="/Images/Image08.jpg" },
        //            new Food() { Name="Thiều Duy Hành", Image="/Images/Image04.jpg" },
        //            new Food() { Name="Nhiệm Băng Đoan", Image="/Images/Image05.jpg" },
        //            new Food() { Name="Mang Đình Từ", Image="/Images/Image06.jpg" },
        //            new Food() { Name="Bùi Tuyền", Image="/Images/Image07.jpg" },
        //            new Food() { Name="Triệu Triều Hải", Image="/Images/Image08.jpg" }
        //        };
        //        return result;
        //    }
        //}

        //BindingList<Food> _list = new BindingList<Food>();


        //BindingList<Food> list;

        ////list of favorite food
        //BindingList<Food> _favoritelist = new BindingList<Food>();

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _list = StudentDao.GetAll();
        //    updateData();
        //}

        //MainImage inIt;

        //public MainWindow()
        //{
        //    InitializeComponent();

        //    inIt = MainImageDao.GetAll();

        //    var valueColor = ConfigurationManager.AppSettings["ColorTheme"];

        //    inIt.Color = valueColor;
        //    DataContext = inIt;


        //    this.OpacityGrid.Visibility = Visibility.Hidden;

        //    Display("Home");
        //}

        //private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        //{

        //    this.OpacityGrid.Visibility = Visibility.Hidden;
        //}

        //private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        //{

        //    this.OpacityGrid.Visibility = Visibility.Visible;
        //}

        //private void Close_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //#region Button Menu bar
        //private void About_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    Display("Aboutus");
        //}

        //private void Setting_Btn_Click(object sender, RoutedEventArgs e)
        //{

        //    Display("Setting");

        //    //ĐỌc thông tin biến lưu xem yêu cầu về hiển thị splashscreen để set checked cho checkbox
        //    var value = ConfigurationManager.AppSettings["DontShowSplashScreen"];
        //    var valuecolor = ConfigurationManager.AppSettings["ColorTheme"];

        //    var showplash = bool.Parse(value);
        //    this.checkShowPlashScreen.IsChecked = showplash;

        //    switch (valuecolor)
        //    {
        //        //Green theme
        //        case "#d4fc79":
        //            Green_Theme.IsChecked = true;
        //            break;

        //        //Red Theme
        //        case "#fa709a":
        //            Red_Theme.IsChecked = true;
        //            break;

        //        //Blue Theme
        //        case "#4facfe":
        //            Blue_Theme.IsChecked = true;
        //            break;

        //        //Yellow Theme
        //        case "#f7b733":
        //            Yellow_Theme.IsChecked = true;
        //            break;
        //    }


        //}

        //private void AddRecipe_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    Display("AddRecipe");
        //    this.Tg_Btn.IsChecked = false;
        //}

        //private void Contact_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    Display("Contact");
        //    this.Tg_Btn.IsChecked = false;
        //}

        //private void Favorite_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    dataListView.ItemsSource = _favoritelist;
        //    Display("Favorite");
        //    this.Tg_Btn.IsChecked = false;


        //}

        //private void Home_Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    dataListView.ItemsSource = list;
        //    Display("Home");
        //    this.Tg_Btn.IsChecked = false;
        //}
        //#endregion

        //private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.Tg_Btn.IsChecked = false;
        //}

        //private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int index = ListView.SelectedIndex;
        //    this.Tg_Btn.IsChecked = false;
        //    switch (index)
        //    {
        //        //Home
        //        case 0:
        //            Display("Home");
        //            break;
        //        //Favorite
        //        case 1:
        //            Display("Favorite");

        //            break;
        //        //Contact
        //        case 2:
        //            Display("Contact");

        //            break;
        //        //Add recipe
        //        case 3:
        //            Display("AddRecipe");

        //            break;
        //        //Setting
        //        case 4:
        //            Display("Setting");

        //            break;
        //        //About us
        //        case 5:

        //            Display("Aboutus");

        //            break;
        //    }

        //}

        /// <summary>
        /// Display the grid you want to
        /// </summary>
        /// <param name="currntSelectedItem">/// </param>
        //void Display(string currntSelectedItem)
        //{
        //    Home_ListView.Visibility = Visibility.Hidden;
        //    Contact.Visibility = Visibility.Hidden;
        //    Add.Visibility = Visibility.Hidden;
        //    Setting.Visibility = Visibility.Hidden;
        //    About.Visibility = Visibility.Hidden;
        //    switch (currntSelectedItem)
        //    {
        //        case "Home":
        //        case "Favorite":
        //            Home_ListView.Visibility = Visibility.Visible;
        //            break;

        //        case "Contact":
        //            Contact.Visibility = Visibility.Visible;
        //            break;
        //        case "AddRecipe":
        //            Add.Visibility = Visibility.Visible;
        //            break;
        //        case "Setting":
        //            Setting.Visibility = Visibility.Visible;
        //            break;

        //        case "Aboutus":
        //            About.Visibility = Visibility.Visible;
        //            break;

        //    }
        //}

        //private void nextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int n = 1;
        //    if (_list.Count % 8 == 0)
        //    {
        //        n = 0;
        //    }
        //    if (page < _list.Count / 8 + n)
        //    {
        //        page++;
        //        updateData();
        //    }
        //}

        //private void previosButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (page > 1)
        //    {
        //        page--;
        //        updateData();
        //    }
        //}

        //public void updateData()
        //{
        //    int totalPage = _list.Count + 1;
        //    list = new BindingList<Food>();
        //    for (int i = 0; i < _list.Count; i++)
        //    {
        //        if (i >= (page - 1) * 8 && i < (page - 1) * 8 + 8)
        //        {
        //            list.Add(_list[i]);
        //        }
        //    }
        //    Page.Content = $"{page}/{totalPage / 8 + 1}";
        //    dataListView.ItemsSource = list;
        //}

        ///// <summary>
        ///// Favorite function - HeartButton
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void heartButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var bt = sender as Button;
        //    var item = bt.DataContext;
        //    selected = item as Food;
        //    selected.isFavor = !selected.isFavor;

        //    if (selected.isFavor == true)
        //    {
        //        _favoritelist.Add(selected);
        //    }
        //    else
        //    {
        //        _favoritelist.Remove(selected);
        //    }

        //}

        //private void dataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (dataListView.SelectedIndex != -1)
        //    {
        //        MessageBoxResult result = MessageBox.Show("KKK");
        //    }

        //    dataListView.SelectedIndex = -1;
        //}

        //private void SaveSetting_Click(object sender, RoutedEventArgs e)
        //{
        //    var config = ConfigurationManager.OpenExeConfiguration(
        //     ConfigurationUserLevel.None);

        //    if (this.checkShowPlashScreen.IsChecked == true)
        //    {
        //        config.AppSettings.Settings["DontShowSplashScreen"].Value = "true";
        //    }
        //    else
        //    {
        //        config.AppSettings.Settings["DontShowSplashScreen"].Value = "false";
        //    }

        //    string color = "";
        //    //Color Theme
        //    if (Green_Theme.IsChecked == true)
        //    {
        //        config.AppSettings.Settings["ColorTheme"].Value = "#d4fc79";
        //        color = "#d4fc79";
        //    }

        //    if (Red_Theme.IsChecked == true)
        //    {
        //        config.AppSettings.Settings["ColorTheme"].Value = "#fa709a";
        //        color = "#fa709a";
        //    }

        //    if (Blue_Theme.IsChecked == true)
        //    {
        //        config.AppSettings.Settings["ColorTheme"].Value = "#4facfe";
        //        color = "#4facfe";
        //    }

        //    if (Yellow_Theme.IsChecked == true)
        //    {
        //        config.AppSettings.Settings["ColorTheme"].Value = "#f7b733";
        //        color = "#f7b733";
        //    }

        //    inIt.Color = color;

        //    config.Save(ConfigurationSaveMode.Minimal);

        //    MessageBox.Show("Successfully", "Save", MessageBoxButton.OK, MessageBoxImage.Information);

        //    DataContext = inIt;
        //}
    }
}
