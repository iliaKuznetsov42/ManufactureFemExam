using ManufactureFemExam.Model;
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
using System.Windows.Shapes;

namespace ManufactureFemExam.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public readonly Order _curentOrder;
        public AddOrderWindow()
        {
            InitializeComponent();
            Title = "Добавление компании";
            AddPOrderBtn.Visibility = Visibility.Visible;
            EditOrderBtn.Visibility = Visibility.Collapsed;
        }
        //Конструктор Добавления
        public AddOrderWindow(Order selectedOrderType)
        {
            InitializeComponent();
            _curentOrder = selectedOrderType;
            Title = "Редактирование данных компании";
            EditOrderBtn.Visibility = Visibility.Visible;
            AddPOrderBtn.Visibility = Visibility.Collapsed;
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();
            MessageBox.Show("Данные заказа успешно обновлены");
            DialogResult = true;
        }

        private void AddPOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Order newOrder = new Order()
                {
                    Number = Convert.ToInt32(NameOrderTb.Text),
                    TotalPrice = Convert.ToInt32(PriceTb.Text),
                    date = DateDp.SelectedDate.Value
                };
                App.context.Order.Add(newOrder);
                App.context.SaveChanges();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(NameOrderTb.Text))
            {
                MessageBox.Show("Введите номер заказ");
                NameOrderTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PriceTb.Text))
            {
                MessageBox.Show("Введите цену");
                PriceTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DateDp.Text))
            {
                MessageBox.Show("Выберите дату");
                DateDp.Focus();
                return false;
            }
            return true;
        }
    }
}
