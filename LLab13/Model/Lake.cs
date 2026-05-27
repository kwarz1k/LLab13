using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLab13.Model
{
    public class Lake : INotifyPropertyChanged
    {
        private string _name;
        private string _country;
        private double _depth;
        private double _salinity;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(nameof(Country)); }
        }

        public double Depth
        {
            get => _depth;
            set { _depth = value; OnPropertyChanged(nameof(Depth)); }
        }

        public double Salinity
        {
            get => _salinity;
            set { _salinity = value; OnPropertyChanged(nameof(Salinity)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
