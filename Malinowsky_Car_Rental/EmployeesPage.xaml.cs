using Malinowsky_Car_Rental.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Malinowsky_Car_Rental
{
    /// <summary>
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Window
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtBaseId.Text.Trim() is null)
                MessageBox.Show("Please fill the empty spaces!");
            else
            {
                using(MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    Pracownicy emp = new Pracownicy();
                    ///emp.IdBazy = txtBaseId;
                    emp.Imie = txtName.Text;
                    emp.Nazwisko = txtSurname.Text;
                    db.Pracownicy.Add(emp);
                    db.SaveChanges();
                    txtName.Clear();
                    txtSurname.Clear();
                    MessageBox.Show("Employee has been added");

                }
            }
        }
    }
}
