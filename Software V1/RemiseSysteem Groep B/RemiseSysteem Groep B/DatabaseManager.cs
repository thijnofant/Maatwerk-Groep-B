﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace RemiseSysteem_Groep_B
{
    class DatabaseManager
    {
        #region singleton
        private static DatabaseManager instance;
        int ReserveringIdIn;

        private DatabaseManager()
        {
            this.connection = new OracleConnection();
            this.Pcn = "dbi292195";
            this.Password = "kd1qoIM98M";
            connection.ConnectionString = "User Id=" + this.Pcn + ";Password=" + this.Password + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
        }
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }
        #endregion

        //TODO: Fix
        //private OracleConnection connection = new OracleConnection();
        public string Pcn { get; private set; }
        public string Password { get; private set; }

        public OracleConnection connection;

        public bool Test()
        {
            try
            {
                connection.Open();

                return true;
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public List<Medewerker> MedewerkersOpvragen()
        {
            List<Medewerker> medewerkers = new List<Medewerker>();

            //TODO: SQL

            return medewerkers;
        }

        public List<Medewerker> MedewerkersOpvragen(Onderhoud onderhoud)
        {
            List<Medewerker> medewerkers = new List<Medewerker>();

            //TODO: SQL

            return medewerkers;
        }

        public bool Inloggen(string username, string wachtwoord)
        {
            //TODO: LogIn
            throw new NotImplementedException();
        }

        public List<Onderhoud> OnderhoudsBeurtenOpvragen()
        {
            List<Onderhoud> onderhoudsBeurten = new List<Onderhoud>();

            //TODO: SQL

            return onderhoudsBeurten;
        }

        /// <summary>
        /// NOG TESTEN
        /// 
        /// Haalt de lijst met alle schoonmaak die niet nog niet af zijn.
        /// </summary>
        /// <returns></returns>
        public List<Schoonmaak> SchoonmaakOpvragen()
        {
            List<Schoonmaak> returnList = new List<Schoonmaak>();

            String cmd = "SELECT ID, MedewerkerID, TramID, DatumTijdstip, BeurtType FROM TRAM_BEURT WHERE Klaar = 'N' AND TypeOnderhoud = 'Schoonmaak'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int SchoonmaakID = reader.GetInt32(0);
                    int MedewerkerId = reader.GetInt32(1);
                    int tramId = reader.GetInt32(2);
                    DateTime startTijd = reader.GetDateTime(3);
                    string beurtType = reader["BeurtType"].ToString();

                    BeurtType tempEnum = BeurtType.Groot;

                    switch (beurtType)
                    {
                        case "Klein":
                            tempEnum = BeurtType.Klein;
                            break;
                        case "Groot":
                            tempEnum = BeurtType.Groot;  
                            break;
                        case "Incident":
                            tempEnum = BeurtType.Incident;
                            break;
                    }

                    Tram tempTram = ZoekTramOpID(tramId);
                    Medewerker tempMed = ZoekMedewerkerOpID(MedewerkerId);
                    
                    Schoonmaak tempSchoon = new Schoonmaak(startTijd, SchoonmaakID, tempEnum, tempTram);
                    if (tempMed != null)
                    {
                        tempSchoon.VoegMedewerkerToe(tempMed);
                    }
                    returnList.Add(tempSchoon);
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return returnList;
        }

        /// <summary>
        /// NOG TESTEN
        /// 
        /// Haalt de lijst met alle Reparatie die niet nog niet af zijn.
        /// </summary>
        /// <returns></returns>
        public List<Onderhoud> OnderhoudOpvragen()
        {
            List<Onderhoud> returnList = new List<Onderhoud>();

            String cmd = "SELECT ID, MedewerkerID, TramID, DatumTijdstip, BeurtType, BeschikbaarDatum FROM TRAM_BEURT WHERE Klaar = 'N' AND TypeOnderhoud = 'Onderhoud';";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int OnderhoudID = reader.GetInt32(0);
                    int MedewerkerId = reader.GetInt32(1);
                    int tramId = reader.GetInt32(2);
                    DateTime startTijd = reader.GetDateTime(3);
                    string beurtType = reader["BeurtType"].ToString();
                    DateTime estTime = reader.GetDateTime(6);

                    BeurtType tempEnum = BeurtType.Groot;

                    switch (beurtType)
                    {
                        case "Klein":
                            tempEnum = BeurtType.Klein;
                            break;
                        case "Groot":
                            tempEnum = BeurtType.Groot;
                            break;
                        case "Incident":
                            tempEnum = BeurtType.Incident;
                            break;
                    }

                    Tram tempTram = ZoekTramOpID(tramId);
                    Medewerker tempMed = ZoekMedewerkerOpID(MedewerkerId);
                    /*startTijd, OnderhoudID, tempEnum, tempTram*/
                    Onderhoud tempSchoon = new Onderhoud(startTijd, OnderhoudID, tempEnum, tempTram, estTime);
                    if (tempMed != null)
                    {
                        tempSchoon.VoegMedewerkerToe(tempMed);
                    }
                    returnList.Add(tempSchoon);
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return returnList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable SporenOpvragen()
        {
            DataTable sporenlijst = new DataTable();


            //TODO: SQL
            return sporenlijst;
        }

        public List<Spoor> SporenlijstOpvragen()
        {
            List<Spoor> sporen = new List<Spoor>();
            string cmd = "Select id, nummer from spoor";
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int spoorid = reader.GetInt32(0);
                    int spoornummer = reader.GetInt32(1);
                    string cmdSector = "Select id from sector where spoorid = " + spoorid;
                    OracleCommand commSector = new OracleCommand(cmdSector, connection);
                    OracleDataReader readerSector = commSector.ExecuteReader();
                    List<Sector> sectoren = new List<Sector>();
                    List<Lijn> lijnen = new List<Lijn>();
                    while (readerSector.Read())
                    {
                        Sector sector = new Sector(reader.GetInt32(0));
                        sectoren.Add(sector);
                    }
                    Spoor spoor = new Spoor(spoorid, sectoren, lijnen);
                    spoor.Nummer = spoornummer;
                    sporen.Add(spoor);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return sporen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable LijnenOpvragen()
        {
            DataTable lijnenlijst = new DataTable();
            //TODO: SQL
            return lijnenlijst;
        }

        /// <summary>
        /// Methode om een tram uit de db te zoeken aan de hand van een tram nummer
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns></returns>
        public Tram ZoekTram(int nummer)
        {
            String cmd = "Select t.*, tt.* From TRAM t, TRAMTYPE tt Where t.Nummer = '" + nummer + "' AND t.TramtypeID = tt.ID";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                string GevondenStatus = reader["Status"].ToString();
                string GevondenDescription = reader["Omschrijving"].ToString();

                //aanvullen
                TramType tramtype = new TramType(GevondenDescription, 1);
                Tram tram = new Tram(nummer, tramtype);
                TramStatus tramStatus = (TramStatus)Enum.Parse(typeof(TramStatus), GevondenStatus, true);
                tram.StatusWijzigen(tramStatus);
                return tram;


            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }

        public Tram ZoekTramOpID(int id)
        {
            String cmd = "Select t.*, tt.* From TRAM t, TRAMTYPE tt Where t.ID = '" + id + "' AND t.TramtypeID = tt.ID";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                string GevondenStatus = reader["Status"].ToString();
                string GevondenDescription = reader["Omschrijving"].ToString();

                //aanvullen
                TramType tramtype = new TramType(GevondenDescription, 1);
                Tram tram = new Tram(id, tramtype);
                TramStatus tramStatus = (TramStatus)Enum.Parse(typeof(TramStatus), GevondenStatus, true);
                tram.StatusWijzigen(tramStatus);
                return tram; 
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }

        public Medewerker ZoekMedewerkerOpID(int id)
        {
            String cmd =
                "Select M.ID, M.Naam, F.Naam FROM MEDEWERKER M INNER JOIN FUNCTIE F ON M.FUNCTIEID = F.ID WHERE M.ID =" +
                id.ToString();
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int medewerkerID = reader.GetInt32(0);
                string medewerkerNaam = reader["M.Naam"].ToString();
                string funtieNaam = reader["F.Naam"].ToString();

                MedewerkerType temp = MedewerkerType.Bestuurder;
                switch (funtieNaam)
                {
                    case "Beheerder":
                        temp = MedewerkerType.Beheerder;
                        break;
                    case "Bestuurder":
                        temp = MedewerkerType.Bestuurder;
                        break;
                    case "Schoonmaker":
                        temp = MedewerkerType.Schoonmaker;
                        break;
                    case "Technicus":
                        temp = MedewerkerType.Technicus;
                        break;
                }
                Medewerker returnmed = new Medewerker(medewerkerID, medewerkerNaam, temp);
                return returnmed;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }

        public List<Beurt> GetAlleBeurten() 
        {

        }

        public bool SchoonmaakInvoeren(Schoonmaak schoonmaak) 
        {
            try 
            {
                connection.Open();
                string cmd = "INSERT INTO Tram_Beurt(ID, TramID, DatumTijdstip, TypeOnderhoud, BeurtType) VALUES(" + Convert.ToString(schoonmaak.ID) + ", " + Convert.ToString(schoonmaak.Tram.Id) + ", " + "TO_DATE('" + Convert.ToString(schoonmaak.BeginDatum.Date).Substring(0, 10) + "', 'DD-MM-YYYY'), 'Schoonmaak', '" + Convert.ToString(schoonmaak.Soort) + "')";
                OracleCommand command = new OracleCommand(cmd, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteReader();
                return true;
            }
            catch 
            {
                return false;
            }
            finally 
            {
                connection.Close();
            }
        } 

        public bool TramVerplaatsen(int tramNr, Sector sect)
        {
            Tram tempTram = ZoekTram(tramNr);
            String cmd = " UPDATE SECTOR SET TramID = null WHERE TramID ="+tempTram.Id+"; UPDATE SECTOR SET TramID =" + tempTram.Id + " WHERE ID =" +sect.Id;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public List<Tram> AlleTrams() 
        {
            List<Tram> tramlist = new List<Tram>();
            string cmd = "SELECT t.ID, t.Nummer, t.Status, tt.Omschrijving, tt.Lengte FROM Tram t, TramType tt WHERE t.TramtypeID = tt.ID";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int tramid = reader.GetInt32(0);
                    int tramnummer = reader.GetInt32(1);
                    TramStatus status = (TramStatus)Enum.Parse(typeof(TramStatus), reader.GetString(2), true);
                    string typenaam = reader.GetString(3);
                    double lengte = reader.GetDouble(4);

                    TramType type = new TramType(typenaam, lengte);
                    Tram tram = new Tram(tramid, type, tramnummer);
                    tramlist.Add(tram);
                }
                return tramlist;
            }
            catch
            {
                return tramlist;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool TramReserveren(int tramnummer, int spoornummer)
        {
            ReserveringIdIn = GetInsertID("ID", "RESERVERING");
            ReserveringIdIn++;
            string sql = "INSERT INTO RESERVERING (ID, TRAMID, SPOORID ) VALUES (" + ReserveringIdIn + "," + tramnummer + ", " + spoornummer + ")";
            OracleCommand command = new OracleCommand(sql, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public int GetInsertID(string ID, string tabelnaam)
        {
            string insertID = "Select Max(" + ID + ") From " + tabelnaam;

            OracleCommand commandID = new OracleCommand(insertID, connection);
            commandID.CommandType = System.Data.CommandType.Text;

            try
            {
                connection.Open();
                OracleDataReader readerMat = commandID.ExecuteReader();
                readerMat.Read();
                int id = readerMat.GetInt32(0);
                return id;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<int> GetBeurtSporen()
        {
            String cmd = "SELECT ID FROM Spoor S Where ((Nummer BETWEEN 12 AND 21) OR (Nummer BETWEEN 74 AND 77));";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                List<int> reList = new List<int>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int SpoorNR = reader.GetInt32(0);

                    reList.Add(SpoorNR);
                }
                return reList;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }

        public List<int> GetSporenIDByLijnID(int lijnID)
        {
            String cmd = "SELECT ID FROM SPOOR WHERE ID In (SELECT SpoorID FROM LIJN_SPOOR WHERE LijnID =" + lijnID + ")";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                List<int> reList = new List<int>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int SpoorNR = reader.GetInt32(0);

                    reList.Add(SpoorNR);
                }
                return reList;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }

        public List<int> GetSporenIDForFreeSporen()
        {
            String cmd = "SELECT ID FROM SPOOR WHERE ID NOT IN (SELECT SpoorID FROM Lijn_Spoor) AND NOT(Nummer BETWEEN 12 AND 21) AND NOT(Nummer NOT BETWEEN 74 AND 77)";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                List<int> reList = new List<int>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int SpoorNR = reader.GetInt32(0);

                    reList.Add(SpoorNR);
                }
                return reList;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return null;
        }
        public int GetSectorX(int X, int spoorID)
        {
            String cmd = "SELECT * FROM SECTOR WHERE SpoorID =" + spoorID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                List<int> reList = new List<int>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int SpoorNR = reader.GetInt32(0);

                    reList.Add(SpoorNR);
                }

                return reList[X];
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return 0;
        }

        public bool SectorBezet(int SectorID)
        {
            String cmd = "SELECT TramId FROM SECTOR WHERE ID =" + SectorID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();


                int TramID = reader.GetInt32(0);
                if (TramID != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public int LijnNrOpvragen(int tramNr)
        {
            Tram tempTram = ZoekTram(tramNr);
            String cmd = "SELECT Nummer FROM Lijn WHERE ID IN (SELECT LIJNID FROM TRAM_LIJN WHERE TramID =" + tempTram.Id + ")";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                int LijnNR = reader.GetInt32(0);
                return LijnNR;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return 0;
        }
        public int GetGereserveerdSpoor(int tramID)
        {
            String cmd = "SELECT SpoorID FROM RESERVERING WHERE TRAMID =" + tramID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                int SpoorID = reader.GetInt32(0);
                return SpoorID;
            }
            catch
            {

            }
            finally
            {
                this.connection.Close();
            }
            return 0;
        }
    }
}
