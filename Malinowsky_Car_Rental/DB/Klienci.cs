using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class Klienci
    {
        public Klienci()
        {
            Wypozyczenia = new HashSet<Wypozyczenia>();
        }

        public int IdKlienta { get; set; }
        public string Pesel { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string NrTelefonu { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerLokalu { get; set; }

        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }
    }
}
