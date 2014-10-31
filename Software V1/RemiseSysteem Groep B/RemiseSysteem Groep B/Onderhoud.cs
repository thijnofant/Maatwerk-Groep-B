using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Onderhoud : Beurt
    {
        private DateTime beginDatum;
        private int id;
        private BeurtType soort;
        private bool isKlaar;

        private DateTime tijdsIndicatie;

        private List<Medewerker> medewerkers;

        private Tram tram;

        public DateTime BeginDatum { get; private set; }
        public int ID { get; private set; }
        public BeurtType Soort { get; private set; }
        public bool IsKlaar { get; private set; }

        public DateTime TijdsIndicatie { get; private set; }

        public List<Medewerker> Medewerkers { get; private set; }

        public Tram Tram { get; private set; }

        public Onderhoud(DateTime beginDatum, int id, BeurtType soort, Tram tram)
            :base(beginDatum, id, soort, tram)
        {
            this.beginDatum = beginDatum;
            this.id = id;
            this.soort = soort;
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

        public void TijdsIndicatieWijzigen(DateTime datum)
        {
            this.TijdsIndicatie = datum;
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
