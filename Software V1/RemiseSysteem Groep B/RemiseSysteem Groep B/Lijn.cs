using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Lijn
    {
        public int Lijnnummer { get; private set; }
        public List<Spoor> Sporen { get; private set; }

        public Lijn(int lijnnummer, List<Spoor> sporen)
        {
            this.Lijnnummer = lijnnummer;
            this.Sporen = sporen;
        }
    }
}
