using Malinowsky_Car_Rental.DB;
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

namespace Malinowsky_Car_Rental.Views
{
    /// <summary>
    /// Interaction logic for RentalsList.xaml
    /// </summary>
    public partial class RentalsList : UserControl
    {
        public RentalsList()
        {
            InitializeComponent();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Wypozyczenia> list = db.Wypozyczenia.OrderBy(x => x.IdWypozyczenia).ToList();
                gridRentals.ItemsSource = list;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            RentalsPage page = new RentalsPage();
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Wypozyczenia> list = db.Wypozyczenia.ToList();
                gridRentals.ItemsSource = list;
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczenia wyp = (Wypozyczenia)gridRentals.SelectedItem;
            RentalsPage page = new RentalsPage();
            page.wypozyczenia = wyp;
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                gridRentals.ItemsSource = db.Wypozyczenia.OrderBy(x => x.IdWypozyczenia).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Wypozyczenia wyp = (Wypozyczenia)gridRentals.SelectedItem;
                if (wyp != null)
                {
                    using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                    {
                        db.Wypozyczenia.Remove(wyp);
                        db.SaveChanges();
                        MessageBox.Show("Record deleted successfully!");
                        gridRentals.ItemsSource = db.Wypozyczenia.OrderBy(x => x.IdWypozyczenia).ToList();
                    }
                }
                else
                {
                    MessageBox.Show("No record selected!");
                }
            }
    }
}
