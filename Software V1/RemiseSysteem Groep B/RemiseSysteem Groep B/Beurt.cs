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
        private bool isGoedgekeurd;

        public int ID { get { return id; } }
        public BeurtType Soort { get { return soort; } }
        public bool IsKlaar { get { return isKlaar; } }
        public List<Medewerker> Medewerkers { get { return medewerkers; } }
        public Tram Tram { get { return tram; } protected set { tram = value; } }
        public DateTime BeginDatum { get { return beginDatum; } protected set { beginDatum = value; } }
        public bool IsGoedgekeurd { get { return isGoedgekeurd; } set { isGoedgekeurd = value; } }

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

        public override string ToString()
        {
            string beurt = "";
            if (this is Schoonmaak)
            {
                beurt = "Soort : Schoonmaak" + " - ";
            }
            else if (this is Onderhoud)
            {
                beurt = "Soort : Onderhoud" + " - ";
            }

            string text = beurt + "beurt ID: "+ this.id + " - Tramnummer: " + this.Tram.Nummer + " - Begindatum: " + this.beginDatum.ToShortDateString() + " - Soort: " + this.soort.ToString() + " - Klaar: " +
                   this.IsKlaar.ToString();

            string medewerker = " - Medewerker: ";
            if (this.medewerkers != null)
                if (this.medewerkers.Count > 0)
                {
                    medewerker += medewerkers[0].Naam;
                    text += medewerker;
                }

            return text;
        }
    }
}
