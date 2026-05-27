using LLab13.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LLab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = (MainViewModel)DataContext;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string country = txtCountry.Text;
            string depthText = txtDepth.Text;
            string salinityText = txtSalinity.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("Введите название и страну!");
                return;
            }

            if (!double.TryParse(depthText, out double depth))
            {
                MessageBox.Show("Глубина должна быть числом!");
                return;
            }

            if (!double.TryParse(salinityText, out double salinity))
            {
                MessageBox.Show("Солёность должна быть числом!");
                return;
            }
            _vm.AddLake(name, country, depth, salinity);
            txtName.Clear();
            txtCountry.Clear();
            txtDepth.Clear();
            txtSalinity.Clear();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _vm.FilterLakes();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _vm.ClearAll();
            txtName.Clear();
            txtCountry.Clear();
            txtDepth.Clear();
            txtSalinity.Clear();
        }
    }
}