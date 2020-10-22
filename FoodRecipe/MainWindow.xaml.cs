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

        class SplashScreen 
        {
            public string Image { get; set; }
            public string Title { get; set; }
            public string Overview { get; set; }

        }
        const string Slash = "/";
        class SplashScreenDAO
        { 
            public static SplashScreen getAll()
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var filepath = $"{folder}splashscreen.txt";

                var splscreen = new SplashScreen();

                using (var reader = new StreamReader(filepath))
                {
                    
                    var line = reader.ReadLine();

                    string[] tokens = line.Split(new string[] { Slash }, StringSplitOptions.RemoveEmptyEntries);

                    splscreen.Image = $"Images/{tokens[0]}";
                    splscreen.Title = tokens[1];
                    splscreen.Overview = tokens[2];
                    
                }    
                return splscreen;
              
            }
        }



        public int count = 0;
        public int target = 100;

        public System.Timers.Timer _timer;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer(1);
            _timer.Elapsed += UpdateValueProgressBar;
            _timer.Start();
            count = (int) progressBar.Minimum;
            target = (int)progressBar.Maximum;
            this.Start.Visibility = Visibility.Hidden;
        }
        
        private void UpdateValueProgressBar(object sender, ElapsedEventArgs e)
        {
            count++;
            double per = count * 100.0 / target;
            string result = string.Format("{0:0.00}%", per);           

            if(count == target)
            {
                _timer.Stop();
                Dispatcher.Invoke(() =>
                {
                    percent.Text = result;
                    this.Start.Visibility = Visibility.Visible;
                });
               
                //... main screen display
            }
            Dispatcher.Invoke(() => {
                percent.Text = result;
                progressBar.Value = count;
            });
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = SplashScreenDAO.getAll();
        }
    }
}
