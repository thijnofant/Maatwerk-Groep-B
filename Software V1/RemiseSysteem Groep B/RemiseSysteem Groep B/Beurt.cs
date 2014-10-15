using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    abstract class Beurt
    {
        private int ID;
        private BeurtType Soort;
        private bool IsKlaar;

        public List<Medewerker> Medewerkers { get; private set; }

        public Tram Tram { get; protected set; }
        public DateTime BeginDatum { get; protected set; }

        public Beurt(DateTime beginDatum, int id, BeurtType soort)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Soort = soort;
            Medewerkers = new List<Medewerker>();
        }

        public abstract List<Medewerker> MedewerkersOpvragen();

        public abstract void VoegMedewerkerToe(Medewerker medewerker);

        public abstract void VerwijderMedewerker(Medewerker medewerker);
    }
}
