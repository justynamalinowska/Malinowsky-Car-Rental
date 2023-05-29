using System;
using System.Collections.Generic;

namespace Malinowsky_Car_Rental.DB
{
    public partial class StanySamochodu
    {
        public StanySamochodu()
        {
            Samochody = new HashSet<Samochody>();
        }

        public int IdStanuSamochodu { get; set; }
        public string StanSamochodu { get; set; }

        public virtual ICollection<Samochody> Samochody { get; set; }
    }
}
