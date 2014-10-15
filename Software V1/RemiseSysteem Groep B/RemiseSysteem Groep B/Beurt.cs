using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    abstract class Beurt
    {
        private DateTime BeginDatum;
        private int ID;
        private BeurtType Beurt;
        private bool IsKlaar;

        public Beurt(DateTime beginDatum, int id, BeurtType beurt)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Beurt = beurt;
        }

        public abstract void Goedkeuren();
    }
}
