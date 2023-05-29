using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class RodzajePaliwa
    {
        public RodzajePaliwa()
        {
            WersjeModeli = new HashSet<WersjeModeli>();
        }

        public int IdRodzajuPaliwa { get; set; }
        public string RodzajPaliwa { get; set; }

        public virtual ICollection<WersjeModeli> WersjeModeli { get; set; }
    }
}
