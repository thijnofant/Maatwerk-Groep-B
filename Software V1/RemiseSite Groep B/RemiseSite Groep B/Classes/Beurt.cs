using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    public class Beurt
    {
        private int id;
        private BeurtType soort;
        private bool isKlaar;
        private List<Medewerker> medewerkers;
        private Tram tram;
        private DateTime beginDatum;
        private bool isGoedgekeurd;

        /// <summary>
        /// De Property voor de DatabaseID van een Beurt.
        /// </summary>
        public int ID { get { return id; } }

        /// <summary>
        /// De Property voor de Soort Beurt
        /// </summary>
        public BeurtType Soort { get { return soort; } }

        /// <summary>
        /// De Property die aangeeft of een Beurt Klaar is of niet.
        /// </summary>
        public bool IsKlaar { get { return isKlaar; } }

        /// <summary>
        /// De Property die de Medewerkers die aan een beurt werken bevat.
        /// </summary>
        public List<Medewerker> Medewerkers { get { return medewerkers; } }

        /// <summary>
        /// De Property die bevat welke Tram bij de Beurt hoort.
        /// </summary>
        public Tram Tram { get { return tram; } protected set { tram = value; } }

        /// <summary>
        /// De Property die bevat welke Begindatum bij de Beurt hoort.
        /// </summary>
        public DateTime BeginDatum { get { return beginDatum; } protected set { beginDatum = value; } }

        /// <summary>
        /// De Property die bevat of de Beurt is Goedgekeurt of niet.
        /// </summary>
        public bool IsGoedgekeurd { get { return isGoedgekeurd; } set { isGoedgekeurd = value; } }

        /// <summary>
        /// Dit is de Constructor voor deze klasse.
        /// </summary>
        /// <param name="beginDatum">De begindatum van een Beurt</param>
        /// <param name="id">De DatabaseID van een Beurt.</param>
        /// <param name="soort">De Soort Beurt</param>
        /// <param name="tram">De Tram die hieraan gekoppeld zit.</param>
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

            string text = beurt + "beurt ID: " + this.id + " - Tramnummer: " + this.Tram.Nummer + " - Begindatum: " + this.beginDatum.ToShortDateString() + " - Soort: " + this.soort.ToString() + " - Klaar: " +
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