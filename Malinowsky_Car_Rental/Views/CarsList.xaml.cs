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
    }
}
