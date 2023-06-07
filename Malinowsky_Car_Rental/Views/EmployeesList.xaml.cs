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
    /// Interaction logic for EmployeersList.xaml
    /// </summary>
    public partial class EmployeesList : UserControl
    {
        public EmployeesList()
        {
            InitializeComponent();
            using(MalinowskyCarRentalContext db=new MalinowskyCarRentalContext())
            {
                List<Pracownicy> list = db.Pracownicy.OrderBy(x=>x.IdPracownika).ToList();
                gridEmployees.ItemsSource = list;
            }
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeesPage page = new EmployeesPage();
            page.ShowDialog();
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                List<Pracownicy> list = db.Pracownicy.ToList();
                gridEmployees.ItemsSource = list;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy prac = (Pracownicy)gridEmployees.SelectedItem;
            EmployeesPage page = new EmployeesPage();
            page.pracownicy = prac;
            page.ShowDialog();
            using(MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {
                gridEmployees.ItemsSource = db.Pracownicy.OrderBy(x => x.IdPracownika).ToList();
            }
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Pracownicy prac = (Pracownicy)gridEmployees.SelectedItem;
                if (prac != null)
                {
                    using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                    {
                        db.Pracownicy.Remove(prac);
                        db.SaveChanges();
                        MessageBox.Show("Record deleted successfully!");
                        gridEmployees.ItemsSource = db.Pracownicy.OrderBy(x => x.IdPracownika).ToList();
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
