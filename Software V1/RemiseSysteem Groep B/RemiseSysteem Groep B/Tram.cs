using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Tram
    {
        private TramStatus status;

        public int Id { get { return id; } }
        public TramType Type { get { return type; } }
        public Sector StaatOpSector { get { return staatOpSector; } }

        public Tram(int id, TramType type) 
        {
            this.Id = id;
            this.Type = type;
        }

        public TramStatus Status
        {
            get { return status; }
            set { status = value ; }
        }

        
        /// <summary>
        /// Verandert de huidige status van de tram naar een nieuwe opgegeven status.
        /// </summary>
        /// <param name="nieuweStatus"></param>
        public void StatusWijzigen(TramStatus nieuweStatus) 
        {
            this.status = nieuweStatus;
        }
    }
}
