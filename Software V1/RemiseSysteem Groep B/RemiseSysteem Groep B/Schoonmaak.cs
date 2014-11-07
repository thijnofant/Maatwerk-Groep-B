using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// Dit is de Klasse voor een Schoonmaak.
    /// </summary>
    class Schoonmaak : Beurt
    {
        /// <summary>
        /// Dit is de Constructor voor deze Klasse. Deze klasse inherit all zijn properties van Beurt.
        /// </summary>
        /// <param name="beginDatum">De beginDatum van de Schoonmaak.</param>
        /// <param name="id">De DatabaseID van de Schoonmaak</param>
        /// <param name="soort">De Soort Schoonmaak die gedaan moet worden.</param>
        /// <param name="tram">De Tram die schoongemaakt moet worden.</param>
        public Schoonmaak(DateTime beginDatum, int id, BeurtType soort, Tram tram)
            :base(beginDatum, id, soort, tram)
        {
        }

        /// <summary>
        /// Het opvragen van de medewerkers.
        /// </summary>
        /// <returns>Lijst van medewerkers.</returns>
        public override List<Medewerker> MedewerkersOpvragen()
        {
            return this.Medewerkers;
        }

        /// <summary>
        /// Wijzigt de datum van de schoonmaak beurt.
        /// </summary>
        /// <param name="nieuweDatum">De Nieuwe Begindatum.</param>
        public void DatumWijzigen(DateTime nieuweDatum)
        {
            this.BeginDatum = nieuweDatum;
        }

        /// <summary>
        /// Voegt een medewerker toe aan de onderhoudsbeurt.
        /// </summary>
        /// <param name="medewerker">De Medewerker die wordt toegevoegt.</param>
        public override void VoegMedewerkerToe(Medewerker medewerker)
        {
            this.Medewerkers.Add(medewerker);
        }

        /// <summary>
        /// Verwijdert een medewerker van de onderhoudsbeurt.
        /// </summary>
        /// <param name="medewerker">De Medewerker die verwijdert moet worden van deze SchoonmaakBeurt.</param>
        public override void VerwijderMedewerker(Medewerker medewerker)
        {
            while (this.Medewerkers.Contains(medewerker))
            {
                Medewerkers.Remove(medewerker);
            }
        }
        
        /// <summary>
        /// Deze Methode geeft een String terug met daarin alle belangrijke Info van Schoonmaak.
        /// </summary>
        /// <returns>Een String die alle belangrijke info bevat van deze Schoonmaak.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
