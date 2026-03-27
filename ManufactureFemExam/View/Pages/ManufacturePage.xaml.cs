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
    /// Логика взаимодействия для ManufacturePage.xaml
    /// </summary>
    public partial class ManufacturePage : Page
    {
        string selectedProduct;
        private List<Product> _products;
        private List<string> _productTypes = new List<string>()
        {
            "Все",
            "Товар",
            "Не товар"
        };
        public ManufacturePage()
        {
            InitializeComponent();

            FilterCmb.ItemsSource = _productTypes;
            FilterCmb.SelectedIndex = 0;

            ProductLv.ItemsSource = App.context.Product.ToList();

            LoadData();
        }

        private void LoadData()
        {
            _products = App.context.Product.ToList();
            if (selectedProduct == "Все")
            {
                ProductLv.ItemsSource = _products;
            }
            else
            {
                ProductLv.ItemsSource = _products.Where(c => c.IsProduct = Convert.ToBoolean(selectedProduct));
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            if (addProductWindow.ShowDialog() == true)
            {
                LoadData();
            }

        }

        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = FilterCmb.SelectedItem.ToString();
            LoadData();
        }
    }
}
