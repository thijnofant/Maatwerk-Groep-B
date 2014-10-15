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
        private BeurtType Soort;
        private bool IsKlaar;

        private List<Medewerker> Medewerkers;

        private Tram Tram;

        public Beurt(DateTime beginDatum, int id, BeurtType soort)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Soort = soort;
        }

        public abstract List<Medewerker> MedewerkersOpvragen();

        public abstract void VoegMedewerkerToe(Medewerker medewerker);

        public abstract void VerwijderMedewerker(Medewerker medewerker);
    }
}
