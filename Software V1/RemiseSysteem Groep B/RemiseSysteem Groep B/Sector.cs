using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// 
    /// </summary>
    class Sector
    {
        private int id;
        private bool isWissel;
        private bool isGeblokkeerd;
        private Tram tram;

        /// <summary>
        /// 
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsWissel { get { return isWissel; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGeblokkeerd { get { return isGeblokkeerd; } set { isGeblokkeerd = value; } }

        /// <summary>
        /// 
        /// </summary>
        public Tram Tram { get { return tram; } set { tram = value; } }

        /// <summary>
        /// 
        /// </summary>
        public int SpoorID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Sector(int id) 
        {
            this.id = id;
            this.isGeblokkeerd = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BlokkeerSector() 
        {
            if(this.Tram == null) 
            {
                this.isGeblokkeerd = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeblokkeerSector() 
        {
            this.isGeblokkeerd = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        public void TramVerwijderen() 
        {
            this.tram = null;
        }
    }
}
