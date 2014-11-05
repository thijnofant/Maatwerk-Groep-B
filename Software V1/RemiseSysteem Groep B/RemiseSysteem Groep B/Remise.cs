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
                }
            return instance;}
        }
        #endregion

        public DatabaseManager Database = DatabaseManager.Instance;

        #region Methodes
        public bool PlaatsToewijzen(Sector sector, int tramNR)
        {
            return(Database.TramVerplaatsen(tramNR, sector));
        }

        public bool PlaatsAutomatischToewijzen(int tramNr, bool onderhoud, bool schoonmaak)
        {
            List<int> SpoorID = null;
            int geserveerdSpoor = Database.GetGereserveerdSpoor(Database.ZoekTram(tramNr).Id);
            if (geserveerdSpoor != 0 && geserveerdSpoor != null)
            {
                SpoorID = new List<int>();
                SpoorID.Add(geserveerdSpoor);
            }

            if (SpoorID == null)
            {
                if (onderhoud || schoonmaak)
                {
                    SpoorID = Database.GetBeurtSporen();
                    if (onderhoud)
                    {
                        Database.OnderhoudInvoeren(new Onderhoud(DateTime.Now, Database.GetInsertID("ID","TRAM_BEURT"), BeurtType.Incident, Database.ZoekTram(tramNr)));
                    }
                    if (schoonmaak)
                    {
                        Database.SchoonmaakInvoeren(new Schoonmaak(DateTime.Now, Database.GetInsertID("ID","TRAM_BEURT"), BeurtType.Incident, Database.ZoekTram(tramNr)));
                    }
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
            return false;
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
