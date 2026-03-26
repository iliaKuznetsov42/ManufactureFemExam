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
    /// Логика взаимодействия для CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : Page
    {
        string selectedCompanyType;
        private List<Company> _companies;
        private List<string> _companyTypes = new List<string>()
        {
            "Все",
            "Клиент",
            "Производитель"
        };
        public CompaniesPage()
        {
            InitializeComponent();

            _companies = App.context.Company.ToList();

            CompaniesLv.ItemsSource = _companies;
            FilterCmb.ItemsSource = _companyTypes;
            FilterCmb.SelectedIndex = 0;
        }

        private void RemoveComanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniesLv.SelectedItem;
            if(selectedCompany != null)
            {
                try
                {
                App.context.Company.Remove(selectedCompany);
                App.context.SaveChanges();

                MessageBox.Show("Компания успешно удалена.");

                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Невохможно удалить компанию");
                }


            }
        }

        private void LoadData()
        {
            _companies = App.context.Company.ToList();

            CompaniesLv.ItemsSource = _companies;
            
            if(selectedCompanyType == "Все")
            {
                CompaniesLv.ItemsSource = _companies;
            }
            else
            {
                CompaniesLv.ItemsSource = _companies.Where(c => c.CompanyType == selectedCompanyType);
            }
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniesLv.SelectedItem;
            if(selectedCompany != null)
            {
                AddCompanyWindow addCompanyWindow = new AddCompanyWindow(selectedCompany);
                addCompanyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выберите компанию");
            }
        }

        private void AddCompiesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCompanyWindow addCompany = new AddCompanyWindow();
            if (addCompany.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ManufactureBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if(string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            var filteredList = _companies.Where(company => company.Name.ToLower().Contains(searchString) ||
            company.Insurance.ToLower().Contains(searchString) ||
            company.Phone.ToLower().Contains(searchString) ||
            company.Address.ToLower().Contains(searchString) ).ToList();

            CompaniesLv.ItemsSource = filteredList;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCompanyType = FilterCmb.SelectedItem.ToString();
                LoadData();
            
        }
    }
}
