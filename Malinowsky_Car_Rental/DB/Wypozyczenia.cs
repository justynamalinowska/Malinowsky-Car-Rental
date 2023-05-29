using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class Wypozyczenia
    {
        public int IdWypozyczenia { get; set; }
        public int? IdKlienta { get; set; }
        public int? IdPracownika { get; set; }
        public int? IdSamochodu { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime PlanowanaDataZwrotu { get; set; }
        public DateTime? DataZwrotu { get; set; }
        public int? OplataDodatkowa { get; set; }

        public virtual Klienci IdKlientaNavigation { get; set; }
        public virtual Pracownicy IdPracownikaNavigation { get; set; }
        public virtual Samochody IdSamochoduNavigation { get; set; }
    }
}
