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

        private List<Medewerker> Medewerkers;

        private Tram Tram;

        public Onderhoud(DateTime beginDatum, int id, BeurtType soort)
            :base(beginDatum, id, soort)
        {
            this.BeginDatum = beginDatum;
            this.ID = id;
            this.Soort = soort;
        }

        /// <summary>
        /// Het opvragen van de medewerkers.
        /// </summary>
        /// <returns>Lijst van medewerkers</returns>
        public override List<Medewerker> MedewerkersOpvragen()
        {
            return this.Medewerkers;
        }

        /// <summary>
        /// Vraagt de tijdsindicatie op voor deze onderhoudsbeurt.
        /// </summary>
        public DateTime TijdsIndicatieOpvragen()
        {
            return this.TijdsIndicatie;
        }

        /// <summary>
        /// Voegt een medewerker toe aan de onderhoudsbeurt.
        /// </summary>
        /// <param name="medewerker"></param>
        public override void VoegMedewerkerToe(Medewerker medewerker)
        {
            this.Medewerkers.Add(medewerker);
        }

        /// <summary>
        /// Verwijdert een medewerker van de onderhoudsbeurt.
        /// </summary>
        /// <param name="medewerker"></param>
        public override void VerwijderMedewerker(Medewerker medewerker)
        {
            while(this.Medewerkers.Contains(medewerker))
            {
                Medewerkers.Remove(medewerker);
            }
        }
    }
}
