using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class Bazy
    {
        public Bazy()
        {
            Pracownicy = new HashSet<Pracownicy>();
            Samochody = new HashSet<Samochody>();
        }

        public int IdBazy { get; set; }
        public int? IdPracownika { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerLokalu { get; set; }

        public virtual Pracownicy IdPracownikaNavigation { get; set; }
        public virtual ICollection<Pracownicy> Pracownicy { get; set; }
        public virtual ICollection<Samochody> Samochody { get; set; }
    }
}
