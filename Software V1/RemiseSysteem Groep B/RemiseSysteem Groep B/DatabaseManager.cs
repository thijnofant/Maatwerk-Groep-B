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

        public string Pcn { get; private set; }
        public string Password { get; private set; }

        public OracleConnection connection;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Medewerker> OnderhoudsMedewerkersOpvragen()
        {
            List<Medewerker> medewerkers = new List<Medewerker>();

            String cmd = "SELECT M.ID, M.FunctieID, M.Naam FROM Medewerker M, Functie F WHERE F.ID = M.FunctieID AND F.Naam = 'Technicus'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;

            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Medewerker mw = new Medewerker(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Naam"]), MedewerkerType.Technicus);
                    medewerkers.Add(mw);
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return medewerkers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Medewerker> SchoonmaakMedewerkersOpvragen()
        {
            List<Medewerker> schoonmaakmedewerkers = new List<Medewerker>();
            String cmd = "SELECT M.ID, M.Naam FROM Medewerker M, Functie F WHERE F.ID = M.FunctieID AND F.Naam = 'Schoonmaker'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;

            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int foundID = Convert.ToInt32(reader["ID"]);
                    string foundNaam = reader["Naam"].ToString();
                    Medewerker m = new Medewerker(foundID, foundNaam, MedewerkerType.Schoonmaker);
                    schoonmaakmedewerkers.Add(m);
                }
            }
            catch 
            {

            }
            finally
            {
                connection.Close();
            }

            return schoonmaakmedewerkers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoud"></param>
        /// <returns></returns>
        public int MedewerkerOpvragen(Onderhoud onderhoud)
        {
            int medewerkerID = -1;

            String cmd = "SELECT * FROM TRAM_BEURT WHERE ID = " + onderhoud.ID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;

            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MedewerkerID"] != "")
                    {
                        medewerkerID = Convert.ToInt32(reader["MedewerkerID"]);
                    }
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return medewerkerID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool Inloggen(string username, string wachtwoord)
        {
            //TODO: LogIn
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOG TESTEN
        /// 
        /// Haalt de lijst met alle Reparatie die niet nog niet af zijn.
        /// </summary>
        /// <returns></returns>
        public List<Onderhoud> OnderhoudOpvragen()
        {
            List<Tram> trams = AlleTrams();

            List<Onderhoud> returnList = new List<Onderhoud>();

            String cmd = "SELECT ID, MedewerkerID, TramID, DatumTijdstip, BeschikbaarDatum BeurtType, BeschikbaarDatum FROM TRAM_BEURT WHERE Klaar = 'N' AND TypeOnderhoud = 'Onderhoud'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int OnderhoudID = reader.GetInt32(0);
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

                    /*startTijd, OnderhoudID, tempEnum, tempTram*/
                    Onderhoud tempSchoon = new Onderhoud(startTijd, OnderhoudID, tempEnum, trams.Find(x => x.Id == tramId), Convert.ToDateTime(reader["BeschikbaarDatum"]));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medewerker"></param>
        /// <param name="onderhoud"></param>
        /// <returns></returns>
        public bool VoegMedewerkerToeAanOnderhoud(Medewerker medewerker, Onderhoud onderhoud)
        {
            string cmd = "UPDATE TRAM_BEURT SET MedewerkerID = " + medewerker.Id + " WHERE ID = " + onderhoud.ID;
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                comm.ExecuteNonQuery();
                return true;
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoud"></param>
        /// <returns></returns>
        public bool VerwijderMedewerkerVanOnderhoud(Onderhoud onderhoud)
        {
            string cmd = "UPDATE TRAM_BEURT SET MedewerkerID = null WHERE ID = " + onderhoud.ID;
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                comm.ExecuteNonQuery();
                return true;
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="onderhoud"></param>
        /// <returns></returns>
        public bool WijzigTijdsIndicatieOnderhoud(DateTime datum, Onderhoud onderhoud)
        {
            string cmd = "UPDATE TRAM_BEURT SET BeschikbaarDatum = '" + datum + "' WHERE ID = " + onderhoud.ID;
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                comm.ExecuteNonQuery();
                return true;
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                int GevondenID = Convert.ToInt32(reader["ID"]);
                string GevondenDescription = reader["Omschrijving"].ToString();

                //aanvullen
                TramType tramtype = new TramType(GevondenDescription, 1);
                Tram tram = new Tram(GevondenID, tramtype);
                TramStatus tramStatus = (TramStatus)Enum.Parse(typeof(TramStatus), GevondenStatus, true);
                tram.StatusWijzigen(tramStatus);
                tram.Nummer = nummer;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Medewerker ZoekMedewerkerOpID(int id)
        {
            String cmd = "Select M.Naam AS MNaam, F.Naam AS FNaam FROM MEDEWERKER M, FUNCTIE F WHERE M.FunctieID = F.ID AND M.ID = " + id.ToString();
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                string medewerkerNaam = reader["MNaam"].ToString();
                string funtieNaam = reader["FNaam"].ToString();

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
                Medewerker returnmed = new Medewerker(id, medewerkerNaam, temp);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beurtid"></param>
        /// <param name="isGoedgekeurd"></param>
        /// <returns></returns>
        public bool BeurtGoedkeurenAfkeuren(int beurtid, bool isGoedgekeurd)
        {
            try
            {
                string goedgekeurdString = "";
                if (isGoedgekeurd)
                {
                    goedgekeurdString = "Y";
                }
                else
                {
                    goedgekeurdString = "N";
                }

                string cmd = "Update tram_beurt set goedgekeurd = :goedgekeurd where id = :beurtid";
                OracleCommand command = new OracleCommand(cmd,connection);
                connection.Open();
                command.Parameters.Add("beurtid", beurtid);
                command.Parameters.Add("goedgekeurd", goedgekeurdString);
                int resultaat = command.ExecuteNonQuery();
                if (resultaat > 0)
                {
                    return true;
                }
            }
            catch (OracleException oex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Beurt> ZoekAlleBeurten() 
        {
            List<Tram> trams = AlleTrams();
            List<Beurt> beurten = new List<Beurt>();
            string cmd = "SELECT ID, TramID, DatumTijdstip, BeschikbaarDatum, TypeOnderhoud, BeurtType, goedgekeurd FROM Tram_Beurt";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try 
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    int beurtid = reader.GetInt32(0);
                    int tramid = reader.GetInt32(1);
                    DateTime datum = reader.GetDateTime(2);
                    try 
                    {
                        DateTime tijdsindicatie = reader.GetDateTime(3);
                    }
                    catch 
                    {}
                    string type = reader.GetString(4);
                    string beurttype = reader.GetString(5);
                    string goedgekeurdstring = reader.GetString(6);
                    bool goedgekeurd = false;
                    if (goedgekeurdstring.ToLower() == "y")
                    {
                        goedgekeurd = true;
                    }
                    else if (goedgekeurdstring.ToLower() == "n")
                    {
                        goedgekeurd = false;
                    }

                    if(type == "Schoonmaak")
                    {
                        Schoonmaak schoonmaak = new Schoonmaak(datum, beurtid, (BeurtType)Enum.Parse(typeof(BeurtType), beurttype, true), trams.Find(x => x.Id == tramid));
                        schoonmaak.IsGoedgekeurd = goedgekeurd;
                        beurten.Add(schoonmaak);
                    }
                    if(type == "Onderhoud") 
                    {
                        Onderhoud onderhoud = new Onderhoud(datum, beurtid, (BeurtType)Enum.Parse(typeof(BeurtType), beurttype, true), trams.Find(x => x.Id == tramid));
                        onderhoud.IsGoedgekeurd = goedgekeurd;
                        beurten.Add(onderhoud);
                    }
                }
                return beurten;
            }
            catch 
            {
                return beurten;
            }    
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoonmaak"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schoonmaak"></param>
        /// <param name="medewerkerID"></param>
        /// <returns></returns>
        public bool SchoonmaakInvoeren(Schoonmaak schoonmaak, int medewerkerID)
        {
            try
            {
                connection.Open();
                string cmd = "INSERT INTO Tram_Beurt(ID, MedewerkerID, TramID, DatumTijdstip, TypeOnderhoud, BeurtType) VALUES(" + Convert.ToString(schoonmaak.ID) + ", " + medewerkerID + " , " + Convert.ToString(schoonmaak.Tram.Id) + ", " + "TO_DATE('" + Convert.ToString(schoonmaak.BeginDatum.Date).Substring(0, 10) + "', 'DD-MM-YYYY'), 'Schoonmaak', '" + Convert.ToString(schoonmaak.Soort) + "')";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoud"></param>
        /// <returns></returns>
        public bool OnderhoudInvoeren(Onderhoud onderhoud) 
        {
            try 
            {
                connection.Open();
                string cmd = "INSERT INTO Tram_Beurt(ID, TramID, DatumTijdstip, TypeOnderhoud, BeurtType) VALUES(" + Convert.ToString(onderhoud.ID) + ", " + Convert.ToString(onderhoud.Tram.Id) + ", " + "TO_DATE('" + Convert.ToString(onderhoud.BeginDatum.Date).Substring(0, 10) + "', 'DD-MM-YYYY'), 'Onderhoud', '" + Convert.ToString(onderhoud.Soort) + "')";
                OracleCommand command = new OracleCommand(cmd, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteReader();
                return true;
            }
            catch {
                return false;
            }
            finally {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nieuwStatus"></param>
        /// <param name="tramid"></param>
        /// <returns></returns>
        public bool TramstatusVeranderen(TramStatus nieuwStatus, int tramid)
        {
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand("Update tram set status = :status where id = :id",connection);
                command.Parameters.Add("status", nieuwStatus.ToString().ToLower());
                command.Parameters.Add("id", tramid);
                int resultaat = command.ExecuteNonQuery();
                if (resultaat > 0)
                    return true;
            }
            catch (OracleException oex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramNr"></param>
        /// <returns></returns>
        public bool TramRijdUitRemise(int tramNr)
        {
            Tram tempTram = ZoekTram(tramNr);
            if (tempTram != null)
            {
                string cmd = "UPDATE sector set tramid = null where tramid = :tramid";
                try
                {
                    OracleCommand command = new OracleCommand(cmd, connection);
                    command.Parameters.Add("tramid", tempTram.Id);
                    int resultaat = command.ExecuteNonQuery();
                    if (resultaat > 0)
                    {
                        return true;
                    }
                }
                catch(OracleException oex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramNr"></param>
        /// <param name="sect"></param>
        /// <returns></returns>
        public bool TramVerplaatsen(int tramNr, Sector sect)
        {
            List<Sector> tempSectoren= GetSectorenVoorBlokkade();
            foreach (Sector s in tempSectoren)
            {
                if (s.Id == sect.Id && (s.IsGeblokkeerd || s.Tram != null))
                {
                    return false;
                }
            }

            Tram tempTram = ZoekTram(tramNr);
            String cmd = "UPDATE SECTOR SET TramID =" + tempTram.Id + " WHERE ID =" +sect.Id;
            String cmd2 = "UPDATE SECTOR SET TramID = null where tramID = " + tempTram.Id;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            OracleCommand command2 = new OracleCommand(cmd2, connection);
            command2.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                command2.ExecuteNonQuery();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Tram> AlleTramsMetStatus(TramStatus status)
        {
            List<Tram> tramlist = new List<Tram>();
            string cmd = "SELECT t.ID, t.Nummer, tt.Omschrijving, tt.Lengte FROM Tram t, TramType tt WHERE t.TramtypeID = tt.ID and t.status = :status";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.Parameters.Add("status",status.ToString().ToLower());
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int tramid = reader.GetInt32(0);
                    int tramnummer = reader.GetInt32(1);
                    string typenaam = reader.GetString(2);
                    double lengte = reader.GetDouble(3);

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramnummer"></param>
        /// <param name="spoornummer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="tabelnaam"></param>
        /// <returns></returns>
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
            catch(InvalidOperationException)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> GetBeurtSporen()
        {
            String cmd = "SELECT ID FROM Spoor S Where ((Nummer BETWEEN 12 AND 21) OR (Nummer BETWEEN 74 AND 77))";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lijnID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="spoorID"></param>
        /// <returns></returns>
        public int GetSectorX(int X, int spoorID)
        {
            String cmd = "SELECT * FROM SECTOR WHERE SpoorID =" + spoorID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            List<int> reList = new List<int>();
            try
            {
                this.connection.Open();
               

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SectorID"></param>
        /// <returns></returns>
        public bool SectorBezet(int SectorID)
        {
            String cmd = "SELECT TramId FROM SECTOR WHERE ID =" + SectorID + "OR Blokkade = 'y' OR Blokkade = 'Y'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                int TramID = reader.GetInt32(0);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Sector> GetSectorenVoorBlokkade() 
        {
            List<Sector> sectoren = new List<Sector>();
            string cmd = "SELECT ID, SpoorID, TramID, Blokkade FROM Sector";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try 
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    int sectorid = reader.GetInt32(0);
                    int spoorid = reader.GetInt32(1);
                    int tramid = -1;
                    try 
                    {
                        tramid = reader.GetInt32(2);
                    }
                    catch {}
                    string blokkade = reader.GetString(3);
                    bool geblokkeerd = false;
                    if (blokkade == "y")
                        geblokkeerd = true;

                    Sector sector = new Sector(sectorid);
                    sector.IsGeblokkeerd = geblokkeerd;
                    sector.SpoorID = spoorid;
                    if (tramid != -1)
                        sector.Tram = new Tram(1, new TramType("dummy", 0));
                    sectoren.Add(sector);
                    
                }
                return sectoren;
            }
            catch 
            {
                return null;
            }
            finally 
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramNr"></param>
        /// <returns></returns>
        public int LijnNrOpvragen(int tramNr)
        {
            Tram tempTram = ZoekTram(tramNr);
            String cmd = "SELECT ID FROM Lijn WHERE ID IN (SELECT LIJNID FROM TRAM_LIJN WHERE TramID =" + tempTram.Id + ")";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramID"></param>
        /// <returns></returns>
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
                return 0;
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tramID"></param>
        /// <returns></returns>
        public int GetToegewezenSpoor(int tramID)
        {
            String cmd = "SELECT sp.Nummer FROM spoor sp, sector se  WHERE se.SpoorID = sp.ID and TramID = '" + tramID + "'";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                int SpoorID = Convert.ToInt32(reader["Nummer"]);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kleingroot"></param>
        /// <param name="OnderhoudOfSchoonmaak"></param>
        /// <param name="datum"></param>
        /// <param name="tramID"></param>
        /// <returns></returns>
        public int GetAantalBeurten(string kleingroot, string OnderhoudOfSchoonmaak, DateTime datum, int tramID)
        {
            string test = Convert.ToString(datum).Substring(0, 10);
            String cmd = "SELECT count(*) FROM tram_beurt WHERE BeurtType = '" + kleingroot + "' AND Typeonderhoud = '" + OnderhoudOfSchoonmaak + "' and DatumTijdstip = '" + Convert.ToString(datum).Substring(0, 10) +  "' AND TramID = '" + tramID + "' ";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                OracleDataReader reader = command.ExecuteReader();
                reader.Read();

                int aantal = reader.GetInt32(0);
                return aantal;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="spoorID"></param>
        /// <returns></returns>
        public Sector SectorXfromSpoor(int X, int spoorID)
        {
            String cmd = "SELECT * FROM SECTOR WHERE SpoorID =" + spoorID;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                List<Sector> reList = new List<Sector>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int SpoorNR = reader.GetInt32(0);
                    Sector temp = new Sector(SpoorNR);
                    reList.Add(temp);
                }

                return reList[X - 1];
            }
            catch
            {
                return null;
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SectorID"></param>
        /// <returns></returns>
        public int tramNRFromSectorID(int SectorID)
        {
            String cmd = "SELECT Nummer FROM TRAM WHERE ID = (SELECT TramID FROM SECTOR WHERE ID =" + SectorID + ")";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                int TramNR = 0;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TramNR = reader.GetInt32(0);
                }

                return TramNR;
            }
            catch
            {
                return 0;
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spoorNR"></param>
        /// <returns></returns>
        public List<Sector>GetSectorenFromSpoorNR(int spoorNR)
        {
            String cmd = "SELECT * FROM Sector WHERE SpoorID = (SELECT ID FROM SPOOR WHERE nummer ="+spoorNR+")";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                int SectorID = 0;
                List<Sector> retList = new List<Sector>();

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SectorID = reader.GetInt32(0);
                    Sector temp = new Sector(SectorID);
                    retList.Add(temp);
                }

                return retList;
            }
            catch
            {
                return null;
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectorID"></param>
        /// <returns></returns>
        public bool BlokkeerSector(string sectorID) 
        {
            string cmd = "UPDATE Sector SET Blokkade = 'y' WHERE ID = '" + sectorID + "' AND TramID IS NULL";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try 
            {
                connection.Open();
                command.ExecuteNonQuery();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectorID"></param>
        /// <returns></returns>
        public bool DeblokkeerSector(string sectorID) {
            string cmd = "UPDATE Sector SET Blokkade = 'n' WHERE ID = '" + sectorID + "' AND TramID IS NULL";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try 
            {
                connection.Open();
                command.ExecuteNonQuery();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spoorID"></param>
        /// <returns></returns>
        public bool BlokkeerSpoor(string spoorID) 
        {
            string cmd = "UPDATE Sector SET Blokkade = 'y' WHERE SpoorID = '" + spoorID + "' AND TramID IS NULL";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch {
            return false;
        }
            finally {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spoorID"></param>
        /// <returns></returns>
        public bool DeblokkeerSpoor(string spoorID) 
        {
            string cmd = "UPDATE Sector SET Blokkade = 'n' WHERE SpoorID = '" + spoorID + "' AND TramID IS NULL";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch {
            return false;
        }
            finally {
                connection.Close();
            }
        }

        /// <summary>
        /// Deze methode haalt alle sectoren op uit de database en 
        /// </summary>
        /// <returns></returns>
        public string[] SpoorSectorArray()
        {
            String cmd = "SELECT T.NUMMER, SE.ID, SE.Blokkade FROM TRAM T Right JOIN Sector SE ON T.ID = SE.TramId ORDER BY SE.ID";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();
                string[] tempArray = new string[1000];

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string restring;
                    try
                    {
                        restring = reader.GetInt32(0).ToString();
                    }
                    catch
                    {
                        restring = "0";
                    }
                    int SectorID = reader.GetInt32(1);
                    if (reader.GetString(2) == "y")
                    {
                        restring = "X";
                    }

                    tempArray[SectorID] = restring;
                }

                return tempArray;
            }
            catch
            {
                return null;
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
