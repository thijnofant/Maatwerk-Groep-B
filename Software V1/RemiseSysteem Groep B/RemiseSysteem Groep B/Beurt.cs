using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    abstract class Beurt
    {
        private int id;
        private BeurtType soort;
        private bool isKlaar;
        private List<Medewerker> medewerkers;
        private Tram tram;
        private DateTime beginDatum;

        public int ID { get { return id; } }
        public BeurtType Soort { get { return soort; } }
        public bool IsKlaar { get { return isKlaar; } }
        public List<Medewerker> Medewerkers { get { return medewerkers; } }
        public Tram Tram { get { return tram; } protected set { tram = value; } }
        public DateTime BeginDatum { get { return beginDatum; } protected set { beginDatum = value; } }

        public Beurt(DateTime beginDatum, int id, BeurtType soort, Tram tram)
        {
            this.tram = tram;
            this.beginDatum = beginDatum;
            this.id = id;
            this.soort = soort;
            medewerkers = new List<Medewerker>();
        }

        public abstract List<Medewerker> MedewerkersOpvragen();

        public abstract void VoegMedewerkerToe(Medewerker medewerker);

        public abstract void VerwijderMedewerker(Medewerker medewerker);
    }
}
