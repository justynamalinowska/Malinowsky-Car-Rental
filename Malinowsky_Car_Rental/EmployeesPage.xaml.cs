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

        public Pracownicy pracownicy;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBaseId.SelectedItem != null && txtPESEL.Text.Length == 11)
            {
                int idBazy = (int)cmbBaseId.SelectedValue;

                using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    if (pracownicy != null && pracownicy.IdPracownika != 0)
                    {
                        int idPracownika = pracownicy.IdPracownika;
                        Pracownicy update = db.Pracownicy.FirstOrDefault(p => p.IdPracownika == idPracownika);
                        if (update == null)
                        {
                            MessageBox.Show("Employee not found!");
                        }
                        else
                        {
                            update.IdBazy = idBazy;
                            update.Pesel = txtPESEL.Text;
                            update.Imie = txtName.Text;
                            update.Nazwisko = txtSurname.Text;
                            update.Stanowisko = txtPosition.Text;
                            update.StawkaGodzinowa = short.Parse(txtHourlyRate.Text);
                            update.Kraj = txtCountry.Text;
                            update.Miasto = txtCity.Text;
                            update.Ulica = txtStreet.Text;
                            update.NumerLokalu = txtApartmentNo.Text;
                            update.NumerDomu = txtHouseNo.Text;
                            update.NrTelefonu = txtContactNo.Text;

                            db.SaveChanges();

                            MessageBox.Show("Informations have been updated!");
                        }
                    }

                    else
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

                        MessageBox.Show("Employee has been added!");
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
                    cmbBaseId.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Please select a base ID or enter a valid PESEL");
            }
        }

        private void cmbBaseId_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {

                List<Bazy> bazy = db.Bazy.ToList();


                cmbBaseId.ItemsSource = bazy;
                cmbBaseId.DisplayMemberPath = "IdBazy";
                cmbBaseId.SelectedValuePath = "IdBazy";
            }
                if (pracownicy != null && pracownicy.IdPracownika != 0)
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
    }

    public class ComboValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

