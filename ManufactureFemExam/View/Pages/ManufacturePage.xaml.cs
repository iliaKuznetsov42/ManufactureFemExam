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
        public ManufacturePage()
        {
            InitializeComponent();

            ProductLv.ItemsSource = App.context.Product.ToList();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
