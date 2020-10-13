using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Leveranciers
    {
        public Leveranciers()
        {
            Planten = new HashSet<Planten>();
        }

        public int LevId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string PostNr { get; set; }
        public string Woonplaats { get; set; }

        public virtual ICollection<Planten> Planten { get; set; }
    }
}
