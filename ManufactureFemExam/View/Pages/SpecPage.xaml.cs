using ManufactureFemExam.Model;
using ManufactureFemExam.View.Windows;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManufactureFemExam.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpecPage.xaml
    /// </summary>
    public partial class SpecPage : Page
    {
        string selectedSpec;
        private List<Spec> _specs;
        private List<string> _specTypes = new List<string>()
        {

        };

        public SpecPage()
        {
            InitializeComponent();

            SpecLv.ItemsSource = App.context.Spec.ToList();
        }

        private void LoadData()
        {
            _specs = App.context.Spec.ToList();

            SpecLv.ItemsSource = _specs;

            if (selectedSpec == "Все")
            {
                SpecLv.ItemsSource = _specs;
            }
            else
            {
                SpecLv.ItemsSource = _specs.Where(c => c.IsSpec == Convert.ToBoolean(_specTypes));
            }
        }

        private void AddSpecBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSpecWindow addSpec = new AddSpecWindow();
            if (addSpec.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void EditSpecBtn_Click(object sender, RoutedEventArgs e)
        {
            Spec selectedSpec = (Spec)SpecLv.SelectedItem;
            if (selectedSpec != null)
            {
                AddSpecWindow addSpecWindow = new AddSpecWindow(selectedSpec);
                addSpecWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выберите заказ");
            }
        }

        private void RemoveSpecBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            var filteredList = _specs.Where(spec => spec.Product.ToString().Contains(searchString) ||
            spec.Amount.ToString().Contains(searchString) ||
            spec.Company.ToString().Contains(searchString)).ToList();

            SpecLv.ItemsSource = filteredList;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
