using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Tram: IEquatable<Tram>
    {
        private TramStatus status;
        public TramStatus Status { get { return status; } private set { status = value; } }
        private int nummer;
        public int Id { get; private set;  }
        public TramType Type {  get; private set;  }
        public Sector StaatOpSector { get; private set;  }

        public Tram(int id, TramType type, int nummer) 
        {
            this.Id = id;
            this.Type = type;
            this.Nummer = nummer;
        }
        public Tram(int id, TramType type) {
            this.Id = id;
            this.Type = type;
        }
        
        /// <summary>
        /// Verandert de huidige status van de tram naar een nieuwe opgegeven status.
        /// </summary>
        /// <param name="nieuweStatus"></param>
        public void StatusWijzigen(TramStatus nieuweStatus) 
        {
            this.Status = nieuweStatus;
        }

        public bool Equals(Tram other) 
        {
            return this.Id == other.Id;
        }

        public int Nummer
        {
            get { return nummer; }
            set { nummer = value; }
        }
    }
}
