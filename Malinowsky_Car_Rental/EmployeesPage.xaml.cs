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
    public partial class EmployeesPage : Window
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBaseId.SelectedItem != null && txtPESEL.Text.Length == 11 && short.Parse(txtHourlyRate.Text) > 0)
            {
                int idBazy = ((ComboValue)cmbBaseId.SelectedItem).Id;

                using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    Pracownicy emp = new Pracownicy();
                    emp.IdBazy = idBazy;
                    emp.Pesel = txtPESEL.Text;
                    emp.Imie = txtName.Text;
                    emp.Nazwisko = txtSurname.Text;
                    emp.Stanowisko = txtPosition.Text;
                    emp.StawkaGodzinowa = short.Parse(txtHourlyRate.Text);
                    emp.Kraj = txtCountry.Text;
                    emp.Miasto = txtCity.Text;
                    emp.Ulica = txtStreet.Text;
                    emp.NumerLokalu = txtApartmentNo.Text;
                    emp.NumerDomu = txtHouseNo.Text;
                    emp.NrTelefonu = txtContactNo.Text;

                    db.Pracownicy.Add(emp);
                    db.SaveChanges();
                }

                txtName.Clear();
                txtSurname.Clear();
                txtPESEL.Clear();
                txtPosition.Clear();
                txtHourlyRate.Clear();
                txtCountry.Clear();
                txtCity.Clear();
                txtStreet.Clear();
                txtApartmentNo.Clear();
                txtHouseNo.Clear();
                txtContactNo.Clear();

                MessageBox.Show("Employee has been added");

            }
            else
            {
                MessageBox.Show("Please select a base ID or enter a valid PESEL");
            }
        }

        private void cmbBaseId_Loaded(object sender, RoutedEventArgs e)
        {
            List<ComboValue> list = new List<ComboValue>();
            ComboValue item1 = new ComboValue();
            item1.Id = 1;
            item1.Name = "Base1";
            ComboValue item2 = new ComboValue();
            item2.Id = 2;
            item2.Name = "Base2";
            list.Add(item1);
            list.Add(item2);

            cmbBaseId.ItemsSource = list;
            cmbBaseId.DisplayMemberPath = "Name";
            cmbBaseId.SelectedValuePath = "Id";
        }
    }

    public class ComboValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

