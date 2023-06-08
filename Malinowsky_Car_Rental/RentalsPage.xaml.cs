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
    /// <summary>
    /// Interaction logic for RentalsPage.xaml
    /// </summary>
    public partial class RentalsPage : Window
    {
        public RentalsPage()
        {
            InitializeComponent();
        }

        public Wypozyczenia wypozyczenia;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCustomerId.SelectedItem != null && cmbEmployeeId.SelectedItem != null && cmbCarId.SelectedItem != null
                && datePickerRentalDate.SelectedDate != null && datePickerScheduledReturnDate.SelectedDate != null)
            {
                int customerId = (int)cmbCustomerId.SelectedValue;
                int employeeId = (int)cmbEmployeeId.SelectedValue;
                int carId = (int)cmbCarId.SelectedValue;
                DateTime rentalDate = datePickerRentalDate.SelectedDate.Value;
                DateTime scheduledReturnDate = datePickerScheduledReturnDate.SelectedDate.Value;

                using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    if (wypozyczenia != null && wypozyczenia.IdWypozyczenia != 0)
                    {
                        int rentalId = wypozyczenia.IdWypozyczenia;
                        Wypozyczenia update = db.Wypozyczenia.FirstOrDefault(w => w.IdWypozyczenia == rentalId);
                        if (update == null)
                        {
                            MessageBox.Show("Rental not found!");
                        }
                        else
                        {
                            update.IdKlienta = customerId;
                            update.IdPracownika = employeeId;
                            update.IdSamochodu = carId;
                            update.DataWypozyczenia = rentalDate;
                            update.PlanowanaDataZwrotu = scheduledReturnDate;
                            update.DataZwrotu = datePickerReturnDate.SelectedDate;
                            update.OplataDodatkowa = int.Parse(txtAdditionalFee.Text); 
                            db.SaveChanges();

                            MessageBox.Show("Information has been updated!");
                        }
                    }
                    else
                    {
                        Wypozyczenia wypozyczenia = new Wypozyczenia();
                        wypozyczenia.IdKlienta = customerId;
                        wypozyczenia.IdPracownika = employeeId;
                        wypozyczenia.IdSamochodu = carId;
                        wypozyczenia.DataWypozyczenia = rentalDate;
                        wypozyczenia.PlanowanaDataZwrotu = scheduledReturnDate;
                        wypozyczenia.DataZwrotu = datePickerReturnDate.SelectedDate; 
                        wypozyczenia.OplataDodatkowa = int.Parse(txtAdditionalFee.Text); 

                        db.Wypozyczenia.Add(wypozyczenia);
                        db.SaveChanges();

                        MessageBox.Show("Rental has been added!");
                    }

                    cmbCustomerId.SelectedItem = null;
                    cmbEmployeeId.SelectedItem = null;
                    cmbCarId.SelectedItem = null;
                    datePickerRentalDate.SelectedDate = null;
                    datePickerScheduledReturnDate.SelectedDate = null;
                    datePickerReturnDate.SelectedDate = null;
                    txtAdditionalFee.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the required fields.");
            }
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
            {

                List<Samochody> samochody = db.Samochody.ToList();
                cmbCarId.ItemsSource = samochody;
                cmbCarId.DisplayMemberPath = "IdSamochodu";
                cmbCarId.SelectedValuePath = "IdSamochodu";

                List<Pracownicy> pracownicy = db.Pracownicy.ToList();
                cmbEmployeeId.ItemsSource = pracownicy;
                cmbEmployeeId.DisplayMemberPath = "IdPracownika";
                cmbEmployeeId.SelectedValuePath = "IdPracownika";

                List<Klienci> klienci = db.Klienci.ToList();
                cmbCustomerId.ItemsSource = klienci;
                cmbCustomerId.DisplayMemberPath = "IdKlienta";
                cmbCustomerId.SelectedValuePath = "IdKlienta";
            }

            if (wypozyczenia != null && wypozyczenia.IdWypozyczenia != 0)
            {
                cmbCustomerId.SelectedValue = wypozyczenia.IdKlienta;
                cmbEmployeeId.SelectedValue = wypozyczenia.IdPracownika;
                cmbCarId.SelectedValue = wypozyczenia.IdSamochodu;
                datePickerRentalDate.SelectedDate = wypozyczenia.DataWypozyczenia;
                datePickerScheduledReturnDate.SelectedDate = wypozyczenia.PlanowanaDataZwrotu;
                datePickerReturnDate.SelectedDate = wypozyczenia.DataZwrotu; 
                txtAdditionalFee.Text = wypozyczenia.OplataDodatkowa.ToString(); 
            }
        }

    }
}
