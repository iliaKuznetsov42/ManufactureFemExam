using ManufactureFemExam.View.Pages;
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

namespace ManufactureFemExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            MainFrame.Navigate(new CompaniesPage());
        }

        private void CompiesPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CompaniesPage());
        }

        //private void CompiesPageBtn_Click_1(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new CompaniesPage());
        //}

        private void OrderPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderPage());
        }

        private void ManufacturePageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturePage());
        }

        private void SpecPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SpecPage());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                Title =$"Главное окно - {page.Title}" ;            
            }
        }
    }
}
