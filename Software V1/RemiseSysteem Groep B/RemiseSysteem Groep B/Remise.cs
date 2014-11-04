using System;
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

        public DatabaseManager Database = DatabaseManager.Instance;

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

        public bool PlaatsAutomatischToewijzen(int tramNr, bool onderhoud, bool schoonmaak)
        {
            int geserveerdSpoor = Database.GetGereserveerdSpoor(Database.ZoekTram(tramNr).Id);


            List<int> SpoorID;
            if (onderhoud || schoonmaak)
            {
                SpoorID = Database.GetBeurtSporen();
            }
            else
            {
                int TramLijnID = Database.LijnNrOpvragen(tramNr);
                SpoorID = Database.GetSporenIDByLijnID(TramLijnID);
            }

            int X = 0;
            int N = 0;

            while (true)
            {
                int SectorID = Database.GetSectorX(X, SpoorID[N]);
                if (Database.SectorBezet(SectorID))
                {
                    Database.TramVerplaatsen(tramNr, new Sector(SectorID));
                    break;
                }
                else
                {
                    if (N < SpoorID.Count)
                    {
                        N++;
                    }
                    else
                    {
                        if (X > 8)
                        {
                            SpoorID = Database.GetSporenIDForFreeSporen();
                        }
                        else
                        {
                            N = 0;
                            X++;
                        }
                    }
                }
            }
        }
        public bool SchoonmaakOpgevenAlsBeheerder(Schoonmaak schoonmaak)
        {
            int aantalgroot = 0;
            int aantalklein = 0;
            DateTime datum = schoonmaak.BeginDatum;
            //List<Beurt> allebeurten = 

            return false;
        }
        public bool OnderhoudOpgeven(Onderhoud onderhoud)
        {
            return false;
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
