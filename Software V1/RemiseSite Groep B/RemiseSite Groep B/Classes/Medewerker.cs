using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    class Medewerker
    {
        /// <summary>
        /// Deze Property bevat het Type van de Medewerker.
        /// </summary>
        public MedewerkerType MedewerkerType { get; private set; }

        /// <summary>
        /// Deze Property bevat de Database ID van de Medewerker.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Deze Property bevat de Naam van de Medewerker.
        /// </summary>
        public string Naam { get; private set; }

        /// <summary>
        /// Deze Property bevat de Beurten waar de Medewerker aan heeft gewerkt.
        /// </summary>
        public List<Beurt> UitgevoerdeBeurten { get; private set; }

        /// <summary>
        /// Dit is de Constructor van deze Klasse
        /// </summary>
        /// <param name="id">De Database ID van de Medewerker.</param>
        /// <param name="naam">De Naam van de Medewerker.</param>
        /// <param name="medewerkerType">Het Type van de Medewerker.</param>
        public Medewerker(int id, string naam, MedewerkerType medewerkerType)
        {
            this.MedewerkerType = medewerkerType;
            this.Naam = naam;
            this.Id = id;

            if (medewerkerType == MedewerkerType.Schoonmaker || medewerkerType == MedewerkerType.Technicus)
            {
                UitgevoerdeBeurten = new List<Beurt>();
            }
        }

        /// <summary>
        /// Deze Methode geeft een string terug met de balangrijke info over een medewerker.
        /// </summary>
        /// <returns>Een String met de belangrijke info over een Medewerker.</returns>
        public override string ToString()
        {
            return Id + ". " + Naam;
        }
    }
}