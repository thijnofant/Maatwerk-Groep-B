using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Tram: IEquatable<Tram>
    {
        /// <summary>
        /// 
        /// </summary>
        private TramStatus status;

        /// <summary>
        /// 
        /// </summary>
        public TramStatus Status { get { return status; } private set { status = value; } }

        /// <summary>
        /// 
        /// </summary>
        private int nummer;

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set;  }

        /// <summary>
        /// 
        /// </summary>
        public TramType Type {  get; private set;  }

        /// <summary>
        /// 
        /// </summary>
        public Sector StaatOpSector { get; private set;  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="nummer"></param>
        public Tram(int id, TramType type, int nummer) 
        {
            this.Id = id;
            this.Type = type;
            this.Nummer = nummer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Tram other) 
        {
            return this.Id == other.Id;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int Nummer
        {
            get { return nummer; }
            set { nummer = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.Id + " - Nummer: " + this.nummer + " - Type: " + this.Type.Naam + " - Status: " + this.status.ToString() + " - Spoor & Sector: " +
                   this.StaatOpSector.SpoorID + "." + this.StaatOpSector.Id ;
        }
    }
}
