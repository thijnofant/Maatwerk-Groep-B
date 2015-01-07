using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemiseSite_Groep_B.Classes
{
    
    /// <summary>
    /// De Klasse die de Controller is voor deze aplicatie. Hier komt alles samen en worden touwtjes aan elkaar verbonden.
    /// </summary>
    /// 
    public class Remise
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

        /// <summary>
        /// Deze Methode wordt Gebruikt om handmatig een Sector toe te wijzen aan een Tram.
        /// </summary>
        /// <param name="sector">De Sector waar de Tram naar toe moet.</param>
        /// <param name="tramNR">Het Nummer van de Tram.</param>
        /// <returns>True als het gelukt is, False als het niet gelukt is.</returns>
        public bool PlaatsToewijzen(Sector sector, int tramNR, int spoorNr)
        {
            return (Database.TramVerplaatsen(tramNR, sector, spoorNr));
        }

        /// <summary>
        /// Deze Methode wordt gebruikt om automatisch een Sector toe te wijzen aan een Tram.
        /// </summary>
        /// <param name="tramNr">Het Nummer van de te plaatsen Tram.</param>
        /// <param name="onderhoud">Heeft de Tram Onderhoud nodig?</param>
        /// <param name="schoonmaak">Heeft de Tram Schoonmaak nodig?</param>
        /// <returns>True als het gelukt is, False als het niet gelukt is.</returns>
        public bool PlaatsAutomatischToewijzen(int tramNr, bool onderhoud, bool schoonmaak)
        {
            List<int> SpoorID = new List<int>();
            if (Database.ZoekTram(tramNr) == null)
            {
                return false;
            }
            if (Database.TramAlInRemise(tramNr) == true)
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
                        Database.OnderhoudInvoeren(new Onderhoud(DateTime.Now, Database.GetInsertID("ID", "TRAM_BEURT") + 1, BeurtType.Incident, Database.ZoekTram(tramNr), DateTime.Now));
                        Tram tram = Database.ZoekTram(tramNr);
                        Database.TramstatusVeranderen(TramStatus.Defect, tram.Id);
                    }
                    if (schoonmaak)
                    {
                        Database.SchoonmaakInvoeren(new Schoonmaak(DateTime.Now, Database.GetInsertID("ID", "TRAM_BEURT") + 1, BeurtType.Incident, Database.ZoekTram(tramNr)));
                        Tram tram = Database.ZoekTram(tramNr);
                        Database.TramstatusVeranderen(TramStatus.Schoonmaak, tram.Id);
                    }
                }
                else
                {

                    SpoorID = Database.GetSporenIDByLijnID(tramNr);
                }
            }
            int X = 0;
            int N = 0;
            int P = 0;

            while (P < 3)
            {
                int SectorID = new int();

                if (SpoorID.Count == 0)
                {
                }
                else if (SpoorID.Count == N)
                {
                    SectorID = Database.GetSectorX(X, SpoorID[N - 1]);
                }
                else
                {
                    SectorID = Database.GetSectorX(X, SpoorID[N]);
                }
                if (!Database.SectorBezet(SectorID,SpoorID[N]))
                {
                    Database.TramVerplaatsen(tramNr, new Sector(SectorID), SpoorID[N]);
                    Tram tram = Database.ZoekTram(tramNr);
                    Database.TramstatusVeranderen(TramStatus.Remise, tram.Nummer);
                    return true;
                }
                else
                {
                    if (N < SpoorID.Count - 1)
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

        #endregion
    }
}