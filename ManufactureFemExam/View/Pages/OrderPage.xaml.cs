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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        string selectedOrderType;
        private List<Order> _orders;
        private List<string> _orderTypes = new List<string>()
        {
            "Все",
            "В работе",
            "Завершён"
        };
        public OrderPage()
        {
            InitializeComponent();

            _orders = App.context.Order.ToList();

            OrderLv.ItemsSource = App.context.Order.ToList();
        }

        private void AddCompiesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProduct = new AddProductWindow();
            if (addProduct.ShowDialog() == true)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            _orders = App.context.Order.ToList();

            OrderLv.ItemsSource = _orders;

            if (selectedOrderType == "Все")
            {
                OrderLv.ItemsSource = _orders;
            }
            else
            {
                OrderLv.ItemsSource = _orders.Where(c => c.IsOrder == Convert.ToBoolean(_orderTypes));
            }
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveComanyBtn_Click(object sender, RoutedEventArgs e)
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
