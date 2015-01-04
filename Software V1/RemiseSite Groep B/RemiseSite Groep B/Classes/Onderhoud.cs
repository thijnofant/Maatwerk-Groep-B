using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    class Onderhoud : Beurt
    {
        private DateTime tijdsIndicatie;

        /// <summary>
        /// Dit is de Property voor het ophalen en setten van een tijds indicatie van deze Onderhoud.
        /// </summary>
        public DateTime TijdsIndicatie { get { return tijdsIndicatie; } protected set { tijdsIndicatie = value; } }

        /// <summary>
        /// Dit is de Constructor voor het maken van een Onderhoud.
        /// </summary>
        /// <param name="beginDatum">De Datum dat er aan gewerkt mag worden.</param>
        /// <param name="id">De DatabaseID van de Onderhoud.</param>
        /// <param name="soort">Wat voor Soort Onderhoud is het</param>
        /// <param name="tram">Welke Tram Moet Onderhouden worden</param>
        /// <param name="tijdsIndicatie">Waneer er verwacht word dat de tram weer heel is.</param>
        public Onderhoud(DateTime beginDatum, int id, BeurtType soort, Tram tram, DateTime tijdsIndicatie)
            : base(beginDatum, id, soort, tram)
        {
            this.tijdsIndicatie = tijdsIndicatie;
        }

        /// <summary>
        /// Dit is de Constructor voor het maken van een Onderhoud. Deze wordt gebruikt als er nog geen TijdsIndicatie bekend is voor de Onderhoud.
        /// </summary>
        /// <param name="beginDatum">De Datum dat er aan gewerkt mag worden.</param>
        /// <param name="id">De DatabaseID van de Onderhoud.</param>
        /// <param name="soort">Wat voor Soort Onderhoud is het</param>
        /// <param name="tram">Welke Tram Moet Onderhouden worden</param>
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
        /// <param name="medewerker">De medewerker die toegevoegd moet worden.</param>
        public override void VoegMedewerkerToe(Medewerker medewerker)
        {
            this.Medewerkers.Add(medewerker);
        }

        /// <summary>
        /// Verwijdert een medewerker van de onderhoudsbeurt.
        /// </summary>
        /// <param name="medewerker">De medewerker die verwijdert moet worden.</param>
        public override void VerwijderMedewerker(Medewerker medewerker)
        {
            while (this.Medewerkers.Contains(medewerker))
            {
                Medewerkers.Remove(medewerker);
            }
        }

        /// <summary>
        /// Deze Methode geeft een String terug met de belangrijke informatie over een Onderhoud.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " - Tijdsindicatie: " + this.tijdsIndicatie.ToShortDateString();
        }
    }
}