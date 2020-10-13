using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Planten
    {
        public int PlantId { get; set; }
        public string Naam { get; set; }
        public int SoortId { get; set; }
        public int LevId { get; set; }
        public string Kleur { get; set; }
        public decimal VerkoopPrijs { get; set; }

        public virtual Leveranciers Lev { get; set; }
        public virtual Soorten Soort { get; set; }
    }
}
