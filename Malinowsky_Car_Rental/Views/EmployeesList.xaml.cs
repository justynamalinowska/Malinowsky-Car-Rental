﻿using System;
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
                List<Pracownicy> list = db.Pracownicy.ToList();
                gridEmployees.ItemsSource = list;


            }
           
        }
    }
}