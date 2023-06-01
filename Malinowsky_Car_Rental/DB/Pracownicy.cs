using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class Pracownicy
    {
        public Pracownicy()
        {
            Bazy = new HashSet<Bazy>();
            Wypozyczenia = new HashSet<Wypozyczenia>();
        }
 
        public int IdPracownika { get; set; }
        public int? IdBazy { get; set; }
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string NrTelefonu { get; set; }
        public DateTime? DataZatrudnienia { get; set; }
        public string Stanowisko { get; set; }
        public short? StawkaGodzinowa { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerLokalu { get; set; }

        public virtual Bazy IdBazyNavigation { get; set; }
        public virtual ICollection<Bazy> Bazy { get; set; }
        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }
    }
}
