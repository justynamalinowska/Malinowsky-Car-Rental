using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class ModeleSamochodow
    {
        public ModeleSamochodow()
        {
            WersjeModeli = new HashSet<WersjeModeli>();
        }

        public int IdModelu { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }

        public virtual ICollection<WersjeModeli> WersjeModeli { get; set; }
    }
}
