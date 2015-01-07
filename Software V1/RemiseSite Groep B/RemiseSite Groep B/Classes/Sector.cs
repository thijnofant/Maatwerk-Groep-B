using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    public class Sector
    {
        private int id;
        private bool isGeblokkeerd;
        private Tram tram;

        /// <summary>
        /// Deze Property haalt de Database ID van deze Sector op.
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Deze Property haalt van deze Sector op of deze Geblokeerd is of niet.
        /// </summary>
        public bool IsGeblokkeerd { get { return isGeblokkeerd; }
            set {
                if (value) {
                    Blokkade = "x";
                } 
                isGeblokkeerd = value; } }

        /// <summary>
        /// Deze Property haalt de Tram op die op deze Sector staat.
        /// </summary>
        public Tram Tram { get { return tram; } set { tram = value; } }

        /// <summary>
        /// Deze Property haalt de Database ID van het Spoor op waar deze Sector een onderdeel van is.
        /// </summary>
        public int SpoorID { get; set; }

        public string Blokkade { get; set; }

        /// <summary>
        /// Dit is de Constructor van een Sector.
        /// </summary>
        /// <param name="id">De DatabaseId van de Sector.</param>
        public Sector(int id)
        {
            this.id = id;
            this.isGeblokkeerd = false;
        }
    }
}