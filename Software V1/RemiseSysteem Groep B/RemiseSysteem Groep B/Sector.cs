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
        private bool isGeblokkeerd;
        private Tram tram;

        public int Id { get; private set; }
        public bool IsWissel { get; private set; }
        public bool IsGeblokkeerd { get; private set; }
        public Tram Tram { get; private set; }

        public Sector(int id, bool isWissel) 
        {
            this.id = id;
            this.isWissel = isWissel;
            this.isGeblokkeerd = false;
        }

        public void BlokkeerSector() 
        {
            if(this.Tram == null) 
            {
                this.isGeblokkeerd = true;
            }
        }

        public void DeblokkeerSector() 
        {
            this.isGeblokkeerd = false;
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
