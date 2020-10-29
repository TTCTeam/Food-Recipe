using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace FoodRecipe
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        class Splashscreen
        {
            public string CloseIcon { get; set; }
            public string Image { get; set; }
            public string Title { get; set; }
            public string Overview { get; set; }

        }
        const string Slash = "/";
        class SplashScreenDAO
        {
            
            public static Splashscreen getAll()
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var filepath = $"{folder}SplashScreen.txt";

                var splscreen = new Splashscreen();

                int range = SplashScreen.lineFile(filepath);

                int index = MyRandom.Instance.Next(range);

                using (var reader = new StreamReader(filepath))
                {
                    var line = "";
                    for(int i =0; i <=index;i++)
                    {
                         line = reader.ReadLine();
                    }
                  

                    string[] tokens = line.Split(new string[] { Slash }, StringSplitOptions.RemoveEmptyEntries);

                    splscreen.Image = $"Images/SplashScreen/{tokens[0]}";
                    splscreen.CloseIcon = $"Images/SplashScreen/{tokens[1]}";
                    splscreen.Title = tokens[2];
                    splscreen.Overview = tokens[3];
                }
                return splscreen;

            }
        }

        public static int lineFile(string filepath)
        {
            int lines = 0;

            using ( var reader = new StreamReader(filepath))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines++;
                }
            }    

            return lines;
        }

        public int count = 0;
        public int target = 100;

        public System.Timers.Timer _timer;

     
        public SplashScreen()
        {
            InitializeComponent();
           
            _timer = new System.Timers.Timer(1);
            _timer.Elapsed += UpdateValueProgressBar;
            _timer.Start();
            count = (int)progressBar.Minimum;
            target = (int)progressBar.Maximum;
            this.Start.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
        }
        private void UpdateValueProgressBar(object sender, ElapsedEventArgs e)
        {
            count++;
            double per = count * 100.0 / target;
            string result = string.Format("{0:0.00}%", per);

            if (count == target)
            {
                _timer.Stop();
                Dispatcher.Invoke(() =>
                {
                    percent.Text = result;
                    this.Start.Visibility = Visibility.Visible;
                    this.Cancel.Visibility = Visibility.Visible;
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

            if (checkShow.IsChecked == true)
            {

                config.AppSettings.Settings["ShowSplashScreen"].Value = "false";

            }
            else
            {
                config.AppSettings.Settings["ShowSplashScreen"].Value = "true";

            }

            config.Save(ConfigurationSaveMode.Minimal);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
