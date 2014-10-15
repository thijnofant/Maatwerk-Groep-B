using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Sector
    {
        private int id;
        private bool isWissel;
        private Tram tram;

        public Sector(int id, bool isWissel) 
        {
            this.id = id;
            this.isWissel = isWissel;
        }
    }
}
