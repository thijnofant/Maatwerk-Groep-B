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
        private Remise() { }
        public static Remise Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Remise();
                }
                return instance;
            }
        }
        #endregion

        public DatabaseManager Database = DatabaseManager.Instance;

        #region Methodes
        public bool PlaatsToewijzen(Sector sector, int tramNR)
        {
            return (Database.TramVerplaatsen(tramNR, sector));
        }

        

        public bool PlaatsAutomatischToewijzen(int tramNr, bool onderhoud, bool schoonmaak)
        {
            List<int> SpoorID = new List<int>();
            if (Database.ZoekTram(tramNr) == null)
            {
                return false;
            }
            int geserveerdSpoor = Database.GetGereserveerdSpoor(Database.ZoekTram(tramNr).Id);
            if (geserveerdSpoor != 0)
            {
                SpoorID = new List<int>();
                SpoorID.Add(geserveerdSpoor);
            }

            if (SpoorID.Count == 0)
            {
                if (onderhoud || schoonmaak)
                {
                    SpoorID = Database.GetBeurtSporen();
                    if (onderhoud)
                    {
                        Database.OnderhoudInvoeren(new Onderhoud(DateTime.Now, Database.GetInsertID("ID", "TRAM_BEURT")+1, BeurtType.Incident, Database.ZoekTram(tramNr)));
                        Tram tram = Database.ZoekTram(tramNr);
                        Database.TramstatusVeranderen(TramStatus.Defect, tram.Id);
                    }
                    if (schoonmaak)
                    {
                        Database.SchoonmaakInvoeren(new Schoonmaak(DateTime.Now, Database.GetInsertID("ID", "TRAM_BEURT")+1, BeurtType.Incident, Database.ZoekTram(tramNr)));
                        Tram tram = Database.ZoekTram(tramNr);
                        Database.TramstatusVeranderen(TramStatus.Schoonmaak, tram.Id);
                    }
                }
                else
                {
                    int TramLijnID = Database.LijnNrOpvragen(tramNr);
                    SpoorID = Database.GetSporenIDByLijnID(TramLijnID);
                }
            }
            int X = 0;
            int N = 0;
            int P = 0;

            while (P < 3)
            {
                int SectorID = Database.GetSectorX(X, SpoorID[N]);
                if (!Database.SectorBezet(SectorID))
                {
                    Database.TramVerplaatsen(tramNr, new Sector(SectorID));
                    Tram tram = Database.ZoekTram(tramNr);
                    Database.TramstatusVeranderen(TramStatus.Remise, tram.Id);
                    return true;
                }
                else
                {
                    if (N < SpoorID.Count)
                    {
                        N++;
                    }
                    else
                    {
                        if (X > 8 && P == 0)
                        {
                            SpoorID = Database.GetSporenIDForFreeSporen();
                            P = 1;
                        }
                        else if (X > 8 && P == 1)
                        {
                            SpoorID.Clear();
                            List<Spoor> tempSpoor = Database.SporenlijstOpvragen();
                            foreach (Spoor s in tempSpoor)
                            {
                                SpoorID.Add(s.Id);
                            }
                            P = 2;
                        }
                        else if (X > 8 && P == 2)
                        {
                            P = 3;
                        }
                        else
                        {
                            N = 0;
                            X++;
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
