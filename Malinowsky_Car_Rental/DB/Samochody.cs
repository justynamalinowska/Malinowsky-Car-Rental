using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class Samochody
    {
        public Samochody()
        {
            Wypozyczenia = new HashSet<Wypozyczenia>();
        }

        public int IdSamochodu { get; set; }
        public int? IdTypu { get; set; }
        public int? IdBazy { get; set; }
        public int? IdStanuSamochodu { get; set; }
        public string Vin { get; set; }
        public int? Przebieg { get; set; }
        public short? CenaZaDzien { get; set; }

        public virtual Bazy IdBazyNavigation { get; set; }
        public virtual StanySamochodu IdStanuSamochoduNavigation { get; set; }
        public virtual TypySamochodow IdTypuNavigation { get; set; }
        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }
    }
}
