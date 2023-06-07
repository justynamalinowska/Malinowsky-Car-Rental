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
                txtCustomerId.Text = klienci.IdKlienta.ToString();
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

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
