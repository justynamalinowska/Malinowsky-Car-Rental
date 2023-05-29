using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class WersjeModeli
    {
        public WersjeModeli()
        {
            TypySamochodow = new HashSet<TypySamochodow>();
        }

        public int IdWersji { get; set; }
        public int? IdModelu { get; set; }
        public int? IdPaliwa { get; set; }
        public int? IdTypuNadwozia { get; set; }
        public short? MocKw { get; set; }
        public short? PojemnoscSilnika { get; set; }
        public byte? LiczbaMiejsc { get; set; }

        public virtual ModeleSamochodow IdModeluNavigation { get; set; }
        public virtual RodzajePaliwa IdPaliwaNavigation { get; set; }
        public virtual TypyNadwozia IdTypuNadwoziaNavigation { get; set; }
        public virtual ICollection<TypySamochodow> TypySamochodow { get; set; }
    }
}
