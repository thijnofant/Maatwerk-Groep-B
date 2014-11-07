using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// Dit is de Klasse voor een Lijn.
    /// </summary>
    class Lijn
    {
        /// <summary>
        /// Dt is de Property die het Nummer van een Lijn bevat.
        /// </summary>
        public int Lijnnummer { get; private set; }

        /// <summary>
        /// Dit is een Lijst met alle sporen die bij Deze Lijn horen.
        /// </summary>
        public List<Spoor> Sporen { get; private set; }

        /// <summary>
        /// Dit is de Constructor voor Lijn.
        /// </summary>
        /// <param name="lijnnummer">Nummer van de Lijn</param>
        /// <param name="sporen">Sporen die bij de Lijn horen.</param>
        public Lijn(int lijnnummer, List<Spoor> sporen)
        {
            this.Lijnnummer = lijnnummer;
            this.Sporen = sporen;
        }
    }
}
