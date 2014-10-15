﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Schoonmaak : Beurt
    {
        private DateTime BeginDatum;
        private int ID;
        private BeurtType Soort;
        private bool IsKlaar;

        public Schoonmaak(DateTime beginDatum, int id, BeurtType soort)
            :base(beginDatum, id, soort)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Soort = soort;
        }

        /// <summary>
        /// Wijzigt de datum van de schoonmaak beurt.
        /// </summary>
        /// <param name="nieuweDatum"></param>
        public void DatumWijzigen(DateTime nieuweDatum)
        {

        }
    }
}
