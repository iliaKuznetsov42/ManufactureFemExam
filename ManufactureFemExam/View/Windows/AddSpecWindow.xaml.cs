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
    /// Логика взаимодействия для AddSpecWindow.xaml
    /// </summary>
    public partial class AddSpecWindow : Window
    {
        public readonly Spec _currentSpec;
        public AddSpecWindow()
        {
            InitializeComponent();
            Title = "Добавление компании";
            AddSpecBtn.Visibility = Visibility.Visible;
            EditSpecBtn.Visibility = Visibility.Collapsed;

            ProductCmb.SelectedValuePath = "id";
            ProductCmb.DisplayMemberPath = "Name";
            ProductCmb.ItemsSource = App.context.Product.ToList();
            
            CompanyCmb.SelectedValuePath = "id";
            CompanyCmb.DisplayMemberPath = "Name";
            CompanyCmb.ItemsSource = App.context.Company.ToList();
        }
        //Конструктор Добавления
        public AddSpecWindow(Spec selectedSpec)
        {
            InitializeComponent();
            _currentSpec = selectedSpec;
            Title = "Редактирование данных компании";
            EditSpecBtn.Visibility = Visibility.Visible;
            AddSpecBtn.Visibility = Visibility.Collapsed;

            ProductCmb.SelectedValuePath = "id";
            ProductCmb.DisplayMemberPath = "Name";
            ProductCmb.ItemsSource = App.context.Product.ToList();

            CompanyCmb.SelectedValuePath = "id";
            CompanyCmb.DisplayMemberPath = "Name";
            CompanyCmb.ItemsSource = App.context.Company.ToList();
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();
            MessageBox.Show("Данные успешно обновлены");
            DialogResult = true;
        }

        private void AddPOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Spec newSpec = new Spec()
                {
                    Product = ProductCmb.SelectedItem as Product,
                    Company = CompanyCmb.SelectedItem as Company,
                    Amount = Convert.ToInt32(AmountTb.Text)
                };
                App.context.Spec.Add(newSpec);
                App.context.SaveChanges();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductCmb.Text))
            {
                MessageBox.Show("Выберите продукт");
                ProductCmb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(CompanyCmb.Text))
            {
                MessageBox.Show("Выберите компанию");
                CompanyCmb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(AmountTb.Text))
            {
                MessageBox.Show("Введите количество");
                AmountTb.Focus();
                return false;
            }

            return true;
        }
    }
}
