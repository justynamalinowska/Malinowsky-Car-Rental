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
using Malinowsky_Car_Rental.ViewModels;

namespace Malinowsky_Car_Rental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Employees List";
            DataContext = new EmployeesViewModel();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Customers List";
            DataContext = new CustomersViewModel();
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Cars List";
            DataContext = new CarsViewModel();
        }

        private void btnRentals_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Rentals List";
            DataContext = new RentalsViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RentalMainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
