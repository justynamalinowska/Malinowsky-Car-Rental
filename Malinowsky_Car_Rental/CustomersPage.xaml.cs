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
using System.Linq;
using Malinowsky_Car_Rental.DB;

namespace Malinowsky_Car_Rental
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Window
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        public Klienci klienci;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (klienci != null && klienci.IdKlienta != 0)
            {
                txtName.Text = klienci.Imie;
                txtSurname.Text = klienci.Nazwisko;
                txtPESEL.Text = klienci.Pesel;
                txtCountry.Text = klienci.Kraj;
                txtCity.Text = klienci.Miasto;
                txtStreet.Text = klienci.Ulica;
                txtApartmentNo.Text = klienci.NumerLokalu;
                txtHouseNo.Text = klienci.NumerDomu;
                txtContactNo.Text = klienci.NrTelefonu;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtPESEL.Text.Trim() == "")
                MessageBox.Show("Please fill PESEL area!");
            else
            {
                using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    if (klienci != null && klienci.IdKlienta != 0)
                    {
                        int idKlienta = klienci.IdKlienta;
                        Klienci update = db.Klienci.FirstOrDefault(p => p.IdKlienta == idKlienta);
                        update.Imie = txtName.Text;
                        update.Nazwisko = txtSurname.Text;
                        update.Pesel = txtPESEL.Text;
                        update.Kraj = txtCountry.Text;
                        update.Miasto = txtCity.Text;
                        update.Ulica = txtStreet.Text;
                        update.NumerLokalu = txtApartmentNo.Text;
                        update.NumerDomu = txtHouseNo.Text;
                        update.NrTelefonu = txtContactNo.Text;

                        db.SaveChanges();

                        MessageBox.Show("Informations have been updated!");
                    }
                    else 
                    {
                        Klienci kli = new Klienci();
                        kli.Imie = txtName.Text;
                        kli.Nazwisko = txtSurname.Text;
                        kli.Pesel = txtPESEL.Text;
                        kli.Kraj = txtCountry.Text;
                        kli.Miasto = txtCity.Text;
                        kli.Ulica = txtStreet.Text;
                        kli.NumerLokalu = txtApartmentNo.Text;
                        kli.NumerDomu = txtHouseNo.Text;
                        kli.NrTelefonu = txtContactNo.Text;

                        db.Klienci.Add(kli);
                        db.SaveChanges();

                        MessageBox.Show("Customer has been added!");
                    }
                   
                    txtName.Clear();
                    txtSurname.Clear();
                    txtPESEL.Clear();
                    txtCountry.Clear();
                    txtCity.Clear();
                    txtStreet.Clear();
                    txtApartmentNo.Clear();
                    txtHouseNo.Clear();
                    txtContactNo.Clear();
                }

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
