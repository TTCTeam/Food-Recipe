using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen :Window
    {
        public int page = 1;

        Food selected;

        string[] isFavorImage = new string[]
               {
                    "like.png",
                    "notlike.png",
               };
        public HomeScreen()
        {
            InitializeComponent();
        }

        class StudentDao
        {
            public static BindingList<Food> GetAll()
            {
                var result = new BindingList<Food>()
                {
                    new Food() { Name="Chu Tùng Nhân", Image="/Images/Image01.jpg", Type = "Tráng miệng"},
                    new Food() { Name="Nguyen Ánh Du", Image="/Images/Image02.jpg"},
                    new Food() { Name="Lều Bách Khánh", Image="/Images/Image03.jpg"},
                    new Food() { Name="Thiều Duy Hành", Image="/Images/Image04.jpg" },
                    new Food() { Name="Nhiệm Băng Đoan", Image="/Images/Image05.jpg" },
                    new Food() { Name="Mang Đình Từ", Image="/Images/Image06.jpg" },
                    new Food() { Name="Bùi Tuyền", Image="/Images/Image07.jpg" },
                    new Food() { Name="Triệu Triều Hải", Image="/Images/Image08.jpg" },
                    new Food() { Name="Thiều Duy Hành", Image="/Images/Image04.jpg" },
                    new Food() { Name="Nhiệm Băng Đoan", Image="/Images/Image05.jpg" },
                    new Food() { Name="Mang Đình Từ", Image="/Images/Image06.jpg" },
                    new Food() { Name="Bùi Tuyền", Image="/Images/Image07.jpg" },
                    new Food() { Name="Triệu Triều Hải", Image="/Images/Image08.jpg" }
                };
                return result;
            }
        }

        BindingList<Food> _list = new BindingList<Food>();
        BindingList<Food> list;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = StudentDao.GetAll();
            updateData();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            int n = 1;
            if (_list.Count % 8 == 0)
            {
                n = 0;
            }
            if (page < _list.Count / 8 + n)
            {
                page++;
                updateData();
            }
        }

        private void previosButton_Click(object sender, RoutedEventArgs e)
        {
            if (page > 1)
            {
                page--;
                updateData();
            }
        }

        public void updateData()
        {
            int totalPage = _list.Count + 1;
            list = new BindingList<Food>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (i >= (page - 1) * 8 && i < (page - 1) * 8 + 8)
                {
                    list.Add(_list[i]);
                }
            }
            Page.Content = $"{page}/{totalPage / 8 + 1}";
            dataListView.ItemsSource = list;
        }

        private void heartButton_Click(object sender, RoutedEventArgs e)
        {
            var bt = sender as Button;
            var item = bt.DataContext;
            selected = item as Food;
            selected.isFavor = !selected.isFavor;
        }

        private void dataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataListView.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("KKK");
            }

            dataListView.SelectedIndex = -1;
        }

    }
}
