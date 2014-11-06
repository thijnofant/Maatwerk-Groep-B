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
    class Lijn
    {
        /// <summary>
        /// 
        /// </summary>
        public int Lijnnummer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Spoor> Sporen { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lijnnummer"></param>
        /// <param name="sporen"></param>
        public Lijn(int lijnnummer, List<Spoor> sporen)
        {
            this.Lijnnummer = lijnnummer;
            this.Sporen = sporen;
        }
    }
}
