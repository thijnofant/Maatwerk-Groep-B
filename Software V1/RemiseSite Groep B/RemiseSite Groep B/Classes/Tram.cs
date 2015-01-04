using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    class Tram: IEquatable<Tram>
    {
        /// <summary>
        /// Dit is de Status van een Tram.
        /// </summary>
        private TramStatus status;

        /// <summary>
        /// Dit is de Property waarmee de Status van een Tram kan worden opgehaald.
        /// </summary>
        public TramStatus Status { get { return status; } private set { status = value; } }

        /// <summary>
        /// Dit is het TramNummer dat een Tram heeft.
        /// </summary>
        private int nummer;

        /// <summary>
        /// Dit is de ID die een Tram heeft in de Database.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Dit is Het Type dat deze Tram is.
        /// </summary>
        public TramType Type { get; private set; }

        /// <summary>
        /// Dit is de sector waar deze tram op staat.
        /// </summary>
        public Sector StaatOpSector { get; private set; }

        /// <summary>
        /// De Property voor het ophalen van een TramNummer.
        /// </summary>
        public int Nummer
        {
            get { return nummer; }
            set { nummer = value; }
        }

        /// <summary>
        /// Dit is de Constructor voor het aanmaken van een Tram.
        /// </summary>
        /// <param name="id">De Database ID van de Tram.</param>
        /// <param name="type">Het TramType van de Tram</param>
        /// <param name="nummer">Het Tram Nummer van de Tram</param>
        public Tram(int id, TramType type, int nummer)
        {
            this.Id = id;
            this.Type = type;
            this.Nummer = nummer;
        }

        /// <summary>
        /// Dit is de 2e Constructor voor het aanmaken van een Tram.
        /// </summary>
        /// <param name="id">De Database ID van de Tram.</param>
        /// <param name="type">Het TramType van de Tram.</param>
        public Tram(int id, TramType type)
        {
            this.Id = id;
            this.Type = type;
        }

        /// <summary>
        /// Verandert de huidige Status van de Tram naar een nieuwe opgegeven Status.
        /// </summary>
        /// <param name="nieuweStatus">De nieuwe TramStatus voor de Tram.</param>
        public void StatusWijzigen(TramStatus nieuweStatus)
        {
            this.Status = nieuweStatus;
        }

        /// <summary>
        /// Deze Metode word gebruikt om te controleren of 2 Trams hetzelfde zijn door naar hun Database ID te kijken.
        /// </summary>
        /// <param name="other">De Tram die vergeleken wordt met deze Tram.</param>
        /// <returns></returns>
        public bool Equals(Tram other)
        {
            return this.Id == other.Id;
        }

        /// <summary>
        /// Deze Methode maakt een String aan met hierin alle belangrijke info over deze Tram.
        /// </summary>
        /// <returns>Een String die alle belangrijke info Bevat van deze Tram</returns>
        public override string ToString()
        {
            string text = "ID: " + this.Id + " - Nummer: " + this.nummer + " - Type: " + this.Type.Naam + " - Status: " + this.status.ToString();
            if (this.StaatOpSector != null)
            {
                text += " - Spoor & Sector: " +
                        this.StaatOpSector.SpoorID + "." + this.StaatOpSector.Id;
            }
            return text;
        }
    }
}