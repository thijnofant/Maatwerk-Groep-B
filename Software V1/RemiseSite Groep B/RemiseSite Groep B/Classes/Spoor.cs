using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    class Spoor
    {
        private int id;
        private int nummer;
        private List<Sector> sectoren;
        private List<Lijn> lijnen;

        /// <summary>
        /// De Property voor het halen van de DatabaseID van dit Spoor.
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// De Property voor het halen van de Lijst met Sectoren van dit Spoor.
        /// </summary>
        public List<Sector> Sectoren { get { return sectoren; } }

        /// <summary>
        /// De Property voor het halen van de Lijst met Lijnen van dit Spoor.
        /// </summary>
        public List<Lijn> Lijnen { get { return lijnen; } }

        /// <summary>
        /// De Property voor het halen van het Nummer van dit Spoor.
        /// </summary>
        public int Nummer
        {
            get { return nummer; }
            set { nummer = value; }
        }

        /// <summary>
        /// De Constructor van Een Spoor.
        /// </summary>
        /// <param name="id">De Database ID van dit Spoor.</param>
        /// <param name="sectoren">De Sectoren die dit spoor heeft.</param>
        /// <param name="lijnen">De Lijst met Lijnen die gekoppelt zijn aan dit Spoor.</param>
        public Spoor(int id, List<Sector> sectoren, List<Lijn> lijnen)
        {
            this.id = id;
            this.sectoren = sectoren;
            this.lijnen = lijnen;
        }
    }
}