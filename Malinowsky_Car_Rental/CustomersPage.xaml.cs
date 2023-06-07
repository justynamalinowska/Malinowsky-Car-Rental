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
            if (klienci != null && pracownicy.IdPracownika != 0)
            {
                txtName.Text = pracownicy.Imie;
                txtSurname.Text = pracownicy.Nazwisko;
                txtPESEL.Text = pracownicy.Pesel;
                txtPosition.Text = pracownicy.Stanowisko;
                txtHourlyRate.Text = pracownicy.StawkaGodzinowa.ToString();
                txtCountry.Text = pracownicy.Kraj;
                txtCity.Text = pracownicy.Miasto;
                txtStreet.Text = pracownicy.Ulica;
                txtApartmentNo.Text = pracownicy.NumerLokalu;
                txtHouseNo.Text = pracownicy.NumerDomu;
                txtContactNo.Text = pracownicy.NrTelefonu;
                cmbBaseId.Text = pracownicy.IdBazy.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
