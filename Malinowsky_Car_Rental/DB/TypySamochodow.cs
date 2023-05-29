using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class TypySamochodow
    {
        public TypySamochodow()
        {
            Samochody = new HashSet<Samochody>();
        }

        public int IdTypu { get; set; }
        public int? IdWersji { get; set; }
        public short? RokProdukcji { get; set; }
        public string Kolor { get; set; }

        public virtual WersjeModeli IdWersjiNavigation { get; set; }
        public virtual ICollection<Samochody> Samochody { get; set; }
    }
}
