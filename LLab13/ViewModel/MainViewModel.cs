using LLab13.Command;
using LLab13.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LLab13.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Lake> AllLakes { get; set; } = new();
        public ObservableCollection<Lake> FilteredLakes { get; set; } = new();
        private const string FilePath = "lakes.bin";
        public void AddLake(string name, string country, double depth, double salinity)
        {
            AllLakes.Add(new Lake
            {
                Name = name.Trim(),
                Country = country.Trim(),
                Depth = depth,
                Salinity = salinity
            });
        }
        public void FilterLakes()
        {
            FilteredLakes.Clear();

            foreach (var lake in AllLakes)
            {
                if (lake.Depth < 50 && lake.Salinity > 20)
                {
                    FilteredLakes.Add(lake);
                }
            }

            if (FilteredLakes.Count == 0)
                MessageBox.Show("Нет озёр под условие (глубина < 50м, солёность > 20%)!");
        }
        public void ClearAll()
        {
            AllLakes.Clear();
            FilteredLakes.Clear();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public void SaveToDesktop()
        {
            if (AllLakes.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения!");
                return;
            }

            var list = AllLakes.ToList();
            BinaryFile.Save(list);
        }
    }
}
