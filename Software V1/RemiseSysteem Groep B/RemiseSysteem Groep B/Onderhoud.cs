using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Onderhoud : Beurt
    {
        private DateTime tijdsIndicatie;

        public DateTime TijdsIndicatie { get { return tijdsIndicatie; } protected set { tijdsIndicatie = value; } }

        public Onderhoud(DateTime beginDatum, int id, BeurtType soort, Tram tram, DateTime tijdsIndicatie)
            : base(beginDatum, id, soort, tram)
        {
            this.tijdsIndicatie = tijdsIndicatie;
        }

        public Onderhoud(DateTime beginDatum, int id, BeurtType soort, Tram tram)
            : base(beginDatum, id, soort, tram)
        {

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
