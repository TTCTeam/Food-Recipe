using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace FoodRecipes
{
    public class HeartConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const string fullHeartPath = @"Images\like.png";
            const string emptyHeartPath = @"Images\notlike.png";
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath;

            bool status = (bool)value;

            if (status)
            {
                absolutePath = $"{folder}{fullHeartPath}";
            }
            else
            {
                absolutePath = $"{folder}{emptyHeartPath}";
            }

            return absolutePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
