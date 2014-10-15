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
        public void SchoonmaakOpgeven(Schoonmaak schoonmaak)
        { 

        }
        public void OnderhoudOpgeven(Onderhoud onderhoud)
        {

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
