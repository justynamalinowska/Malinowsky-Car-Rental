using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class TypyNadwozia
    {
        public TypyNadwozia()
        {
            WersjeModeli = new HashSet<WersjeModeli>();
        }

        public int IdTypuNadwozia { get; set; }
        public string TypNadwozia { get; set; }

        public virtual ICollection<WersjeModeli> WersjeModeli { get; set; }
    }
}
