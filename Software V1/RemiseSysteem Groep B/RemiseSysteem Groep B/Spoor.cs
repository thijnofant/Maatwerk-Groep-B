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
    class Spoor
    {
        private int id;
        private int nummer;
        private List<Sector> sectoren;
        private List<Lijn> lijnen;

        /// <summary>
        /// 
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// 
        /// </summary>
        public List<Sector> Sectoren { get { return sectoren; } }

        /// <summary>
        /// 
        /// </summary>
        public List<Lijn> Lijnen { get { return lijnen; } }

        /// <summary>
        /// 
        /// </summary>
        public int Nummer
        {
            get { return nummer; }
            set { nummer = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sectoren"></param>
        /// <param name="lijnen"></param>
        public Spoor(int id, List<Sector> sectoren, List<Lijn> lijnen)
        {
            this.id = id;
            this.sectoren = sectoren;
            this.lijnen = lijnen;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Blokkeren()
        {

        }
    }
}
