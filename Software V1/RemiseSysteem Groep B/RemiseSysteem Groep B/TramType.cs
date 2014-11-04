using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class TramType
    {
        public string Naam { get; private set; }
        public double Lengte { get; private set; }
        public List<Lijn> WordtGebruiktOp { get; private set; }

        public TramType(string naam, double lengte)
        {
            this.Naam = naam;
            this.Lengte = lengte;
            WordtGebruiktOp = new List<Lijn>();
        }
    }
}
