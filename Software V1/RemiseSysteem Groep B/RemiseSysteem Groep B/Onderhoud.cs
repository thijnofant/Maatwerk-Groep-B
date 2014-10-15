using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Onderhoud : Beurt
    {
        private DateTime BeginDatum;
        private int ID;
        private BeurtType Soort;
        private bool IsKlaar;

        private DateTime TijdsIndicatie;

        public Onderhoud(DateTime beginDatum, int id, BeurtType soort)
            :base(beginDatum, id, soort)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Soort = soort;
        }

        /// <summary>
        /// Vraagt de tijdsindicatie op voor deze onderhoudsbeurt
        /// </summary>
        public DateTime TijdsIndicatieOpvragen()
        {
            return this.TijdsIndicatie;
        }
    }
}
