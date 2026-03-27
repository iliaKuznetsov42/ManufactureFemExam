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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {

        public AddProductWindow()
        {
            InitializeComponent();

            UnitCmb.SelectedValuePath = "id";
            UnitCmb.DisplayMemberPath = "Name";
            UnitCmb.ItemsSource = App.context.Unit.ToList();
        }

        private void LoadData()
        {

        }

        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Product newProduct = new Product()
                {
                    Name = NameProductTb.Text,
                    Price = Convert.ToInt32(PriceTb.Text),
                    Unit = UnitCmb.SelectedItem as Unit

                };
                App.context.Product.Add(newProduct);
                App.context.SaveChanges();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(NameProductTb.Text))
            {
                MessageBox.Show("Введите название товара");
                NameProductTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PriceTb.Text))
            {
                MessageBox.Show("Введите цену");
                PriceTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(UnitCmb.Text))
            {
                MessageBox.Show("Выберите ед измерения");
                UnitCmb.Focus();
                return false;
            }


            return true;
        }
    }
}
