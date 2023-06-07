using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Malinowsky_Car_Rental.DB;

namespace Malinowsky_Car_Rental.Views
{
    /// <summary>
    /// Interaction logic for CustomersList.xaml
    /// </summary>
    public partial class CustomersList : UserControl
    {
        public CustomersList()
        {
            InitializeComponent();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Klienci> list = db.Klienci.OrderBy(x => x.IdKlienta).ToList();
                gridCustomers.ItemsSource = list;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomersPage page = new CustomersPage();
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Klienci> list = db.Klienci.ToList();
                gridCustomers.ItemsSource = list;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Klienci kli = (Klienci)gridCustomers.SelectedItem;
            CustomersPage page = new CustomersPage();
            page.klienci = kli;
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                gridCustomers.ItemsSource = db.Klienci.OrderBy(x => x.IdKlienta).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Klienci kli = (Klienci)gridCustomers.SelectedItem;
                if (kli != null)
                {
                    using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                    {
                        db.Klienci.Remove(kli);
                        db.SaveChanges();
                        MessageBox.Show("Record deleted successfully!");
                        gridCustomers.ItemsSource = db.Klienci.OrderBy(x => x.IdKlienta).ToList();
                    }
                }
                else
                {
                    MessageBox.Show("No record selected!");
                }
            }
        }

    }
}
