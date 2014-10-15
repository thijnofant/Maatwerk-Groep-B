using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class TramType
    {
        private string naam;
        private double lengte;
        private List<Lijn> wordtGebruiktOp;

        public TramType(string naam, double lengte)
        {
            this.naam = naam;
            this.lengte = lengte;
            wordtGebruiktOp = new List<Lijn>();
        }
    }
}
