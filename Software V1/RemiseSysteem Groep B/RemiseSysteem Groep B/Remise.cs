﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Remise
    {
        #region singleton
        private static Remise instance;
        private Remise() {}
        public static Remise Instance
        {
            get 
            { 
                if (instance == null)
                {
                    instance = new Remise();
                    instance.Lijnen = new List<Lijn>();
                    instance.Sporen = new List<Spoor>();
                    instance.Medewerkers = new List<Medewerker>();
                    instance.Beurten = new List<Beurt>();
                    instance.AanwezigeTrams = new List<Tram>();
                }
            return instance;}
        }
        #endregion

        #region Atributes + Properties
        public DatabaseManager Database = DatabaseManager.Instance;
        public List<Lijn> Lijnen { get; private set; }
        public List<Spoor> Sporen { get; private set; }
        public Medewerker IngelogdeMedewerker { get; private set; }
        public List<Medewerker> Medewerkers { get; private set; }
        public List<Beurt> Beurten { get; private set; }
        public List<Tram> AanwezigeTrams { get; private set; }
        #endregion

        #region Methodes
        public bool PlaatsToewijzen(Sector sector, Tram tram)
        {
            if (sector.TramToevoegen(tram))
            {
                foreach (Spoor spoor in Sporen)
                {
                    foreach (Sector sect in spoor.Sectoren)
                    {
                        if (sect.Tram.Id == tram.Id)
                        {
                            sect.TramVerwijderen();
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PlaatsAutomatischToewijzen(Tram tram)
        {
            throw new NotImplementedException();
        }
        public bool SchoonmaakOpgeven(Schoonmaak schoonmaak)
        {
            int schoonmaakOpDatum = 0;
            int aantalSchoonmakers = 0;

            //Aantal schoonmaakbeurten op dezelfde datum tellen en opslaan.
            foreach(Schoonmaak s in Beurten)
            {
                if (s.BeginDatum == schoonmaak.BeginDatum) 
                {
                    schoonmaakOpDatum += 1;
                }
            }

            //Aantal schoonmakers beschikbaar.
            foreach(Medewerker m in Medewerkers)
            {
                if(m.MedewerkerType == MedewerkerType.Schoonmaker)
                {
                    aantalSchoonmakers += 1;
                }
            }

            //Als er meer beurten op een dag zijn dan schoonmakers, wordt de beurt geweigerd.
            if (schoonmaakOpDatum >= aantalSchoonmakers) 
            {
                return false;
            }
            Beurten.Add(schoonmaak);
            return true;
        }
        public bool OnderhoudOpgeven(Onderhoud onderhoud)
        {
            int onderhoudOpDatum = 0;
            int aantalTechnici = 0;

            //Aantal onderhoudsbeurten op dezelfde datum tellen en opslaan.
            foreach (Onderhoud s in Beurten) {
                if (s.BeginDatum == onderhoud.BeginDatum) {
                    onderhoudOpDatum += 1;
                }
            }

            //Aantal technici beschikbaar.
            foreach (Medewerker m in Medewerkers) {
                if (m.MedewerkerType == MedewerkerType.Technicus) {
                    aantalTechnici += 1;
                }
            }

            //Als er meer beurten op een dag zijn dan technici, wordt de beurt geweigerd.
            if (onderhoudOpDatum >= aantalTechnici) {
                return false;
            }
            Beurten.Add(onderhoud);
            return true;
        }
        public List<Schoonmaak> SchoonmaakOpvragen()
        {
            throw new NotImplementedException();
        }
        public List<Onderhoud> OnderhoudOpvragen()
        {
            throw new NotImplementedException();
        }
        public void BeurtVoltooien()
        {

        }
        public bool Inloggen(string naam, string wachtwoord)
        {
            return this.Database.Inloggen(naam, wachtwoord);
        }
        #endregion
    }
}
