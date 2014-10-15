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

        public Tram Tram { get; private set; }

        public Sector(int id, bool isWissel) 
        {
            this.id = id;
            this.isWissel = isWissel;
        }

        public bool TramToevoegen(Tram tram) 
        {
            if(this.tram == null) 
            {
                this.tram = tram;
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public void TramVerwijderen() 
        {
            this.tram = null;
        }
    }
}
