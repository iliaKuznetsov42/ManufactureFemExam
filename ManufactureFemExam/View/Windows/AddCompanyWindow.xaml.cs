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
    /// Логика взаимодействия для AddCompanyWindow.xaml
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        public readonly Company _curentCompany;
        //Конструктор Добавления
        public AddCompanyWindow()
        {
            InitializeComponent();
            Title = "Добавление компании";
            AddCompanyBtn.Visibility = Visibility.Visible;
            EditCompanyBtn.Visibility = Visibility.Collapsed;
        }
        //Конструктор Добавления
        public AddCompanyWindow(Company selectedCompany)
        {
            InitializeComponent();
            _curentCompany = selectedCompany;
            Title = "Редактирование данных компании";
            EditCompanyBtn.Visibility= Visibility.Visible;
            AddCompanyBtn.Visibility=Visibility.Collapsed;
        }


        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
           App.context.SaveChanges();
            MessageBox.Show("Данные компании успешно обновлены");
            DialogResult = true;
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                 Company newCompany = new Company()
                {
                    Name = NameTb.Text,
                        Insurance = InsurenceTb.Text,
                        Phone = PhoneTb.Text,
                        Address = AddresTb.Text,
                        IsCustomer = IsCustomerCb.IsChecked.Value,
                        IsManufacturer = IsManufactureCb.IsChecked.Value
                };
                App.context.Company.Add(newCompany);
                App.context.SaveChanges();
            }
        }
        private bool Validate()
        {
            if(string.IsNullOrWhiteSpace(NameTb.Text))
            {
                MessageBox.Show("Введите название компании");
                NameTb.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(InsurenceTb.Text))
            {
                MessageBox.Show("Введите ИНН");
                InsurenceTb.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                MessageBox.Show("Введите Телефон"); PhoneTb.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(AddresTb.Text))
            {
                MessageBox.Show("Введите аддрес");
                AddresTb.Focus();
                return false;
            }
            if(!IsCustomerCb.IsChecked.Value && !IsManufactureCb.IsChecked.Value)
            {
                MessageBox.Show("Выберите хотя бы один пункт");
                IsCustomerCb.Focus();
                return false;
            }
            return true;
        }
    }
}
