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
    /// Interaction logic for CarsList.xaml
    /// </summary>
    public partial class CarsList : UserControl
    {
        public CarsList()
        {
            InitializeComponent();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Samochody> list = db.Samochody.OrderBy(x => x.IdSamochodu).ToList();
                gridCars.ItemsSource = list;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CarsPage page = new CarsPage();
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Samochody> list = db.Samochody.ToList();
                gridCars.ItemsSource = list;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Samochody sam = (Samochody)gridCars.SelectedItem;
            CarsPage page = new CarsPage();
            page.samochody = sam;
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                gridCars.ItemsSource = db.Samochody.OrderBy(x => x.IdSamochodu).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Samochody sam = (Samochody)gridCars.SelectedItem;
                if (sam != null)
                {
                    using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                    {
                        db.Samochody.Remove(sam);
                        db.SaveChanges();
                        MessageBox.Show("Record deleted successfully!");
                        gridCars.ItemsSource = db.Samochody.OrderBy(x => x.IdSamochodu).ToList();
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
