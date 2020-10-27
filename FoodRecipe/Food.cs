using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipe
{
    class Food : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public bool isFavor { get; set; }

        public string isFavorImage { get; set; }

        public string Type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
