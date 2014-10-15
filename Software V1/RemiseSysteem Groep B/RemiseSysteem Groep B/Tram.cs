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
        private int id;
        private TramType type;
        private Sector staatOpSector;

        public int Id { get; private set; }
        public TramStatus Status { get; private set; }
        public TramType Type { get; private set; }
        public Sector StaatOpSector { get; private set; }

        public Tram(int id, TramType type) 
        {
            this.id = id;
            this.isType = type;
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
