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
    /// Interaction logic for CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Window
    {
        public CarsPage()
        {
            InitializeComponent();
        }
        public Samochody samochody;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBaseId.SelectedItem != null && cmbTypeId.SelectedItem != null && !string.IsNullOrEmpty(txtVin.Text) && txtVin.Text.Length == 17 )
            {
                int idBazy = (int)cmbBaseId.SelectedValue;
                int idTypu = (int)cmbTypeId.SelectedValue;

                using (MalinowskyCarRentalContext db = new MalinowskyCarRentalContext())
                {
                    if (samochody != null && samochody.IdSamochodu != 0)
                    {
                        int idSamochodu = samochody.IdSamochodu;
                        Samochody update = db.Samochody.FirstOrDefault(s => s.IdSamochodu == idSamochodu);
                        if (update == null)
                        {
                            MessageBox.Show("Car not found!");
                        }
                        else
                        {
                            update.IdBazy = idBazy;
                            update.IdTypu = idTypu;
                            update.Vin = txtVin.Text;
                            update.Przebieg = int.Parse(txtMileage.Text);
                            update.CenaZaDzien = short.Parse(txtPricePerDay.Text);

                            db.SaveChanges();

                            MessageBox.Show("Information has been updated!");
                        }
                    }
                    else
                    {
                        Samochody samochody = new Samochody();
                        samochody.IdBazy = idBazy;
                        samochody.IdTypu = idTypu;
                        samochody.Vin = txtVin.Text;
                        samochody.Przebieg = int.Parse(txtMileage.Text);
                        samochody.CenaZaDzien = short.Parse(txtPricePerDay.Text);

                        db.Samochody.Add(samochody);
                        db.SaveChanges();

                        MessageBox.Show("Car has been added!");
                    }

                    cmbTypeId.SelectedItem = null;
                    cmbBaseId.SelectedItem = null;
                    txtVin.Clear();
                    txtMileage.Clear();
                    txtPricePerDay.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please select base ID, type ID and enter a valid VIN.");
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
                
                List<Bazy> bazy = db.Bazy.ToList();

                
                cmbBaseId.ItemsSource = bazy;
                cmbBaseId.DisplayMemberPath = "IdBazy"; 
                cmbBaseId.SelectedValuePath = "IdBazy";

                
                List<TypySamochodow> typySamochodow = db.TypySamochodow.ToList();

                
                cmbTypeId.ItemsSource = typySamochodow;
                cmbTypeId.DisplayMemberPath = "IdTypu"; 
                cmbTypeId.SelectedValuePath = "IdTypu";
            }

            if (samochody != null && samochody.IdSamochodu != 0)
            {
                txtVin.Text = samochody.Vin;
                txtMileage.Text = samochody.Przebieg.ToString();
                txtPricePerDay.Text = samochody.CenaZaDzien.ToString();
                cmbBaseId.SelectedValue = samochody.IdBazy;
                cmbTypeId.SelectedValue = samochody.IdTypu;
            }


        }
    }
}
