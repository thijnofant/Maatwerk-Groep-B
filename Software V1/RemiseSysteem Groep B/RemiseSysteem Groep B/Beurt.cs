using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// 
    /// </summary>
    abstract class Beurt
    {
        private int id;
        private BeurtType soort;
        private bool isKlaar;
        private List<Medewerker> medewerkers;
        private Tram tram;
        private DateTime beginDatum;
        private bool isGoedgekeurd;

        /// <summary>
        /// 
        /// </summary>
        public int ID { get { return id; } }

        /// <summary>
        /// 
        /// </summary>
        public BeurtType Soort { get { return soort; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsKlaar { get { return isKlaar; } }

        /// <summary>
        /// 
        /// </summary>
        public List<Medewerker> Medewerkers { get { return medewerkers; } }

        /// <summary>
        /// 
        /// </summary>
        public Tram Tram { get { return tram; } protected set { tram = value; } }

        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginDatum { get { return beginDatum; } protected set { beginDatum = value; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGoedgekeurd { get { return isGoedgekeurd; } set { isGoedgekeurd = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDatum"></param>
        /// <param name="id"></param>
        /// <param name="soort"></param>
        /// <param name="tram"></param>
        public Beurt(DateTime beginDatum, int id, BeurtType soort, Tram tram)
        {
            this.tram = tram;
            this.beginDatum = beginDatum;
            this.id = id;
            this.soort = soort;
            medewerkers = new List<Medewerker>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract List<Medewerker> MedewerkersOpvragen();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medewerker"></param>
        public abstract void VoegMedewerkerToe(Medewerker medewerker);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medewerker"></param>
        public abstract void VerwijderMedewerker(Medewerker medewerker);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
