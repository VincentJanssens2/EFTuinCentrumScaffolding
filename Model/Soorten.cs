using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Soorten
    {
        public Soorten()
        {
            Planten = new HashSet<Planten>();
        }

        public int SoortId { get; set; }
        public string Soort { get; set; }
        public byte MagazijnNr { get; set; }

        public virtual ICollection<Planten> Planten { get; set; }
    }
}
