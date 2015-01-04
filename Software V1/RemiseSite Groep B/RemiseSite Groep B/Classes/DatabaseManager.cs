﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RemiseSite_Groep_B
{
    public class DatabaseManager
    {
        #region singleton
        private static DatabaseManager instance;
        int ReserveringIdIn;

        private DatabaseManager()
        {
            /*
             this.Pcn = "dbi292195";
             this.Password = "kd1qoIM98M";
             connection.ConnectionString = "User Id=" + this.Pcn + ";Password=" + this.Password + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
             */
            this.Pcn = "Proftaak";
            this.Password = "proftaak";
            connection.ConnectionString = "User Id=" + this.Pcn + "; Password=" + this.Password + ";Data Source =" + "//localhost:1521";
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

        public OracleConnection connection = new OracleConnection();

        /// <summary>
        /// Deze Methode Haalt alle Onderhouds Medewerkers op.
        /// </summary>
        /// <returns>Een List met alle Onderhouds Medewerkers</returns>
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
        /// Deze Methode Haalt alle Schoonmaak Medewerkers op.
        /// </summary>
        /// <returns>Een List met alle Schoonmaak Medewerkers</returns>
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
        /// Deze Methode haalt de Id van een medewerker op die aan een tram werkt
        /// </summary>
        /// <param name="onderhoud">Onderhoud met Medewerkers</param>
        /// <returns>Id van de medewerkers</returns>
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
        /// Deze Methode haalt de Id van een medewerker op die aan een tram werkt
        /// </summary>
        /// <param name="onderhoud">Schoonmaak met Medewerkers</param>
        /// <returns>Id van de medewerkers</returns>
        public int MedewerkerOpvragen(Schoonmaak schoonmaak)
        {
            int medewerkerID = -1;

            String cmd = "SELECT * FROM TRAM_BEURT WHERE ID = " + schoonmaak.ID;
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
        /// Inloggen
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="wachtwoord">password</param>
        /// <returns>gelukt (True, false)</returns>
        public bool Inloggen(string username, string wachtwoord)
        {
            //TODO: LogIn
            throw new NotImplementedException();
        }

        /// <summary>
        /// Haalt de lijst met alle Reparatie die niet nog niet af zijn.
        /// </summary>
        /// <returns>Lijst Onderhoud die nog niet Klaar zijn.</returns>
        public List<Onderhoud> OnderhoudOpvragen()
        {
            List<Tram> trams = AlleTrams();

            List<Onderhoud> returnList = new List<Onderhoud>();

            String cmd = "SELECT ID, MedewerkerID, TramID, DatumTijdstip, BeschikbaarDatum, BeurtType FROM TRAM_BEURT WHERE TypeOnderhoud = 'Onderhoud'";
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

                    if (Convert.ToString(reader["BeschikbaarDatum"]) != "")
                    {
                        /*startTijd, OnderhoudID, tempEnum, tempTram*/
                        Onderhoud tempSchoon = new Onderhoud(startTijd, OnderhoudID, tempEnum, trams.Find(x => x.Id == tramId), Convert.ToDateTime(reader["BeschikbaarDatum"]));
                        returnList.Add(tempSchoon);
                    }
                    else
                    {
                        Onderhoud tempSchoon = new Onderhoud(startTijd, OnderhoudID, tempEnum, trams.Find(x => x.Id == tramId));
                        returnList.Add(tempSchoon);
                    }
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
        /// Haalt de lijst met alle Schoonmaak die niet nog niet af zijn.
        /// </summary>
        /// <returns>Lijst Onderhoud die nog niet Klaar zijn.</returns>
        public List<Schoonmaak> SchoonmaakOpvragen()
        {
            List<Tram> trams = AlleTrams();

            List<Schoonmaak> returnList = new List<Schoonmaak>();

            String cmd = "SELECT ID, MedewerkerID, TramID, DatumTijdstip, BeurtType FROM TRAM_BEURT WHERE TypeOnderhoud = 'Schoonmaak'";
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
                    Schoonmaak tempSchoon = new Schoonmaak(startTijd, OnderhoudID, tempEnum, trams.Find(x => x.Id == tramId));
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
        /// Deze Method Controleert of een Onderhoud Klaar is.
        /// </summary>
        /// <param name="onderhoud">Onderhoud</param>
        /// <returns>True,false</returns>
        public bool IsKlaar(Onderhoud onderhoud)
        {
            string cmd = "SELECT Klaar FROM TRAM_BEURT WHERE ID = " + onderhoud.ID;
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (Convert.ToString(reader["Klaar"]) == "Y")
                {
                    return true;
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// Deze Method Controleert of een Schoonmaak Klaar is.
        /// </summary>
        /// <param name="schoonmaak">Schoonmaak</param>
        /// <returns>True, False</returns>
        public bool IsKlaar(Schoonmaak schoonmaak)
        {
            string cmd = "SELECT Klaar FROM TRAM_BEURT WHERE ID = " + schoonmaak.ID;
            OracleCommand comm = new OracleCommand(cmd, connection);
            try
            {
                connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (Convert.ToString(reader["Klaar"]) == "Y")
                {
                    return true;
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// Deze Method Maakt een Onderhoud Klaar als hij dit niet is en een Onderhoud Niet Klaar als hij dit wel is.
        /// </summary>
        /// <param name="onderhoud">onderhoud</param>
        /// <param name="klaar">is hij klaar?</param>
        /// <returns>gelukt</returns>
        public bool WijzigKlaar(Onderhoud onderhoud, bool klaar)
        {
            string cmd = "";
            if (klaar)
            {
                cmd = "UPDATE TRAM_BEURT SET Klaar = 'Y' WHERE ID = " + onderhoud.ID;
            }
            else
            {
                cmd = "UPDATE TRAM_BEURT SET Klaar = 'N' WHERE ID = " + onderhoud.ID;
            }
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
        /// Deze Method Maakt een Onderhoud Klaar als hij dit niet is en een Onderhoud Niet Klaar als hij dit wel is.
        /// </summary>
        /// <param name="schoonmaak">Schoonmaak</param>
        /// <param name="klaar">is hij klaar?</param>
        /// <returns>gelukt</returns>
        public bool WijzigKlaar(Schoonmaak schoonmaak, bool klaar)
        {
            string cmd = "";
            if (klaar)
            {
                cmd = "UPDATE TRAM_BEURT SET Klaar = 'Y' WHERE ID = " + schoonmaak.ID;
            }
            else
            {
                cmd = "UPDATE TRAM_BEURT SET Klaar = 'N' WHERE ID = " + schoonmaak.ID;
            }
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
        /// Deze Methode Voegt een Medewerker toe aan een Onderhoud in de database.
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
        /// Deze Methode Verwijdert een Medewerker van een Onderhoud in de database.
        /// </summary>
        /// <param name="onderhoud"></param>
        /// <returns>gelukt?</returns>
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
        /// Deze Methode wijzigd een TijdsIndicatie van een onderhoud.
        /// </summary>
        /// <param name="datum">nieuwe Tijds indicatie</param>
        /// <param name="onderhoud">onderhoud</param>
        /// <returns>gelukt?</returns>
        public bool WijzigTijdsIndicatieOnderhoud(DateTime datum, Onderhoud onderhoud)
        {
            string cmd = "UPDATE TRAM_BEURT SET BeschikbaarDatum = TO_DATE('" + datum + "', 'DD-MM-YYYY HH24:MI:SS') WHERE ID = " + onderhoud.ID;
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
        /// Deze Methode Haalt een Lijst op uit de database met alle sporen.
        /// </summary>
        /// <returns>Een Lijst met alle sporen die bestaan in de database.</returns>
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

                try
                {
                    TramStatus tramStatus = (TramStatus)Enum.Parse(typeof(TramStatus), GevondenStatus, true);
                    tram.StatusWijzigen(tramStatus);
                }
                catch (Exception)
                {

                }

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
        /// Deze Methode Haalt een medewerker uit de Database aan de hand van de ID
        /// </summary>
        /// <param name="id">Medewerker ID</param>
        /// <returns>Medewerker die bij de ID hoort.</returns>
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
        /// Met deze Methode is het mogenlijk om een Beurt goed te keuren of af te keuren.
        /// </summary>
        /// <param name="beurtid">BeurtID</param>
        /// <param name="isGoedgekeurd">is hij goedgekeurt?</param>
        /// <returns>Gelukt?</returns>
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
                OracleCommand command = new OracleCommand(cmd, connection);
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
        /// Deze Methode Haalt een Lijst op uit de database met alle Beurten.
        /// </summary>
        /// <returns>Lijst Met alle beurten</returns>
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
                    { }
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

                    if (type == "Schoonmaak")
                    {
                        Schoonmaak schoonmaak = new Schoonmaak(datum, beurtid, (BeurtType)Enum.Parse(typeof(BeurtType), beurttype, true), trams.Find(x => x.Id == tramid));
                        schoonmaak.IsGoedgekeurd = goedgekeurd;
                        beurten.Add(schoonmaak);
                    }
                    if (type == "Onderhoud")
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
        /// Deze Methode Maakt een nieuwe Schoonmaak aan in de database.
        /// </summary>
        /// <param name="schoonmaak">Schoonmaak om in te voeren</param>
        /// <returns>Gelukt?</returns>
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
        /// Deze Methode Maakt een nieuwe Schoonmaak aan in de database.
        /// </summary>
        /// <param name="schoonmaak">Schoonmaak om in te voeren</param>
        /// <param name="medewerkerID">Medewerker die schoonmaak doet</param>
        /// <returns>Gelukt?</returns>
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
        /// verwijdert specifieke beurt van database;
        /// </summary>
        /// <param name="onderhoud">onderhoudsbeurt</param>
        /// <returns></returns>
        public bool BeurtVerwijderen(Beurt beurt)
        {
            try
            {
                connection.Open();
                string cmd = "Delete From tram_beurt where id = :id";
                OracleCommand command = new OracleCommand(cmd, connection);
                command.Parameters.Add("id", beurt.ID);
                command.CommandType = System.Data.CommandType.Text;
                int resultaat = command.ExecuteNonQuery();
                if (resultaat > 0)
                {
                    return true;
                }

            }
            catch
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
        /// Deze Methode Maakt een nieuwe Schoonmaak aan in de database.
        /// </summary>
        /// <param name="onderhoud">Schoonmaak om in te voeren</param>
        /// <returns>Gelukt?</returns>
        public bool OnderhoudInvoeren(Onderhoud onderhoud)
        {
            try
            {
                connection.Open();
                string cmd = "INSERT INTO Tram_Beurt(ID, TramID, DatumTijdstip, TypeOnderhoud, BeurtType) VALUES(" + Convert.ToString(onderhoud.ID) + ", " + Convert.ToString(onderhoud.Tram.Id) + ", " + "TO_DATE('" + Convert.ToString(onderhoud.BeginDatum.Date).Substring(0, 10) + "', 'DD-MM-YYYY'), 'Onderhoud', '" + Convert.ToString(onderhoud.Soort) + "')";
                OracleCommand command = new OracleCommand(cmd, connection);
                command.CommandType = System.Data.CommandType.Text;
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
        /// Deze Method Veranderd de status van de tram waarvan de ID wordt ingegeven
        /// </summary>
        /// <param name="nieuwStatus">Nieuwe status</param>
        /// <param name="tramid">DatabaseID van aan te passen Tram</param>
        /// <returns>Gelukt?</returns>
        public bool TramstatusVeranderen(TramStatus nieuwStatus, int tramid)
        {
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand("Update tram set status = :status where id = :id", connection);
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
        /// Deze Methode Zorgt dat de Tram Niet meer op een sector staat
        /// </summary>
        /// <param name="tramNr">Nummer van de te verwijderen Tram</param>
        /// <returns>Gelukt?</returns>
        public bool TramRijdUitRemise(int tramNr)
        {
            Tram tempTram = ZoekTram(tramNr);
            if (tempTram != null)
            {
                string cmd = "UPDATE sector set tramid = null where tramid = :tramid";
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(cmd, connection);
                    command.Parameters.Add("tramid", tempTram.Id);
                    int resultaat = command.ExecuteNonQuery();
                    if (resultaat > 0)
                    {
                        return true;
                    }
                }
                catch (OracleException oex)
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
        /// Deze Methode kan een Tram Plaatsen die nog niet in de Remise staat en een tram verplaatsen die er al wel instaat.
        /// </summary>
        /// <param name="tramNr">NR van de Tram.</param>
        /// <param name="sect">Sector Waar Tram naar toe moet.</param>
        /// <returns></returns>
        public bool TramVerplaatsen(int tramNr, Sector sect)
        {
            List<Sector> tempSectoren = GetSectorenVoorBlokkade();
            try
            {
                foreach (Sector s in tempSectoren)
                {
                    if (s.Id == sect.Id && (s.IsGeblokkeerd || s.Tram != null))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            Tram tempTram = ZoekTram(tramNr);
            String cmd = "UPDATE SECTOR SET TramID =" + tempTram.Id + " WHERE ID =" + sect.Id;
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
        /// Deze Method kan alle trams met status X vinden.
        /// </summary>
        /// <param name="status">De status waar de trams aan moeten voldeon.</param>
        /// <returns></returns>
        public List<Tram> AlleTramsMetStatus(TramStatus status)
        {
            List<Tram> tramlist = new List<Tram>();
            string cmd = "SELECT t.ID, t.Nummer, tt.Omschrijving, tt.Lengte FROM Tram t, TramType tt WHERE t.TramtypeID = tt.ID and t.status = :status";
            OracleCommand command = new OracleCommand(cmd, connection);
            command.Parameters.Add("status", status.ToString().ToLower());
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
        /// Deze Method Returned alle Trams
        /// </summary>
        /// <returns>Lijst Met alle trams</returns>
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
                while (reader.Read())
                {
                    int tramid = reader.GetInt32(0);
                    int tramnummer = reader.GetInt32(1);
                    TramStatus status = (TramStatus)Enum.Parse(typeof(TramStatus), reader.GetString(2), true);
                    string typenaam = reader.GetString(3);
                    double lengte = reader.GetDouble(4);

                    TramType type = new TramType(typenaam, lengte);
                    Tram tram = new Tram(tramid, type, tramnummer);
                    tram.StatusWijzigen(status);
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
        /// Deze Method Kan een Spoor Reserveren voor een Tram
        /// </summary>
        /// <param name="tramnummer">TramNR</param>
        /// <param name="spoornummer">SpoorNR</param>
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
        /// Met deze Method kun je de Hoogste ID uit een Tabel halen
        /// </summary>
        /// <param name="ID">Naam van ID kollom</param>
        /// <param name="tabelnaam">Naam van Tabel</param>
        /// <returns>De hoogste ID</returns>
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
            catch (InvalidOperationException)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Deze Methode Haalt alle Sporen Op uit de database die zijn gereserveerd voor beurten.
        /// </summary>
        /// <returns>Lijst met beurtSporen</returns>
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
        /// Deze Methode word gebruikt om te controleren welke sporen en bij een lijn horen.
        /// </summary>
        /// <param name="lijnID">De DatabaseID van een Lijn.</param>
        /// <returns>De lijst met de DatabaseId's van de sporen die bij de Lijn horen.</returns>
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
        /// Deze Methode haalt alle sporen op die niet bij een lijn horen en ook geen Beurt Sporen zijn.
        /// </summary>
        /// <returns>List Id's voor Vrije Sporen</returns>
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
        /// Deze Methode haalt Sector X op van een spoor.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="spoorID">welk spoor</param>
        /// <returns>de id van de sector</returns>
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
        /// Deze Methode kijk of de Sector bezet of geblokeerd is.
        /// </summary>
        /// <param name="SectorID">SectorID</param>
        /// <returns>True als bezet. false bij niet bezet.</returns>
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
        /// Deze Methode word gebruikt om De sectoren op te halen uit de database die geblokeerd moeten worden als het spoor geblokeerd word.
        /// </summary>
        /// <returns>Lijst met Sectoren die geblokeerd moeten worden.</returns>
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
                    catch { }
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
        /// Deze Methode Geeft De Database ID terug van de Lijn die gekoppelt zit aan de Tram.
        /// </summary>
        /// <param name="tramNr">het nummer van de Tram</param>
        /// <returns>ID van de Lijn die bij de Tram hoort</returns>
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
        /// Deze Methode Haalt het gereserveerde Spoor op die bij een tram horen als deze er zijn.
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
        /// Deze Methode Haalt uit de database op welk Spoor een Tram op staat.
        /// </summary>
        /// <param name="tramID">Welke Tram</param>
        /// <returns>ID van spoor</returns>
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
        /// Deze Methode Zoekt in de Database naar de Count van beurten die in de database staan die aan bepaalde criteria voldoen.
        /// </summary>
        /// <param name="kleingroot"></param>
        /// <param name="OnderhoudOfSchoonmaak"></param>
        /// <param name="datum"></param>
        /// <param name="tramID"></param>
        /// <returns>aantal beurten met die criteria</returns>
        public int GetAantalBeurten(string kleingroot, string OnderhoudOfSchoonmaak, DateTime datum, int tramID)
        {
            string test = Convert.ToString(datum).Substring(0, 10);
            String cmd = "SELECT count(*) FROM tram_beurt WHERE BeurtType = '" + kleingroot + "' AND Typeonderhoud = '" + OnderhoudOfSchoonmaak + "' and DatumTijdstip = '" + Convert.ToString(datum).Substring(0, 10) + "' AND TramID = '" + tramID + "' ";
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
        /// Met deze Methode worden Sectoren opgehaalt die bij een spoor horen.
        /// </summary>
        /// <param name="spoorNR">welk spoor</param>
        /// <returns>lijst sectoren.</returns>
        public List<Sector> GetSectorenFromSpoorNR(int spoorNR)
        {
            String cmd = "SELECT * FROM Sector WHERE SpoorID = (SELECT ID FROM SPOOR WHERE nummer =" + spoorNR + ")";
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
        /// Deze Methode blokeert een Sector
        /// </summary>
        /// <param name="sectorID">SectorID</param>
        /// <returns>Gelukt?</returns>
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
        /// Deze Methode De-Blokeert een Sector
        /// </summary>
        /// <param name="sectorID">SectorID</param>
        /// <returns>Gelukt?</returns>
        public bool DeblokkeerSector(string sectorID)
        {
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
        /// Deze Methode Blokeert alle sectoren in een spoor
        /// </summary>
        /// <param name="spoorID">Id van het spoor dat je wilt blokeren</param>
        /// <returns>Gelukt?</returns>
        public bool BlokkeerSpoor(string spoorID)
        {
            string cmd = "UPDATE Sector SET Blokkade = 'y' WHERE SpoorID = '" + spoorID + "' AND TramID IS NULL";
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
        /// Deze Methode De-Blokeert alle sectoren in een spoor
        /// </summary>
        /// <param name="spoorID">Id van het spoor dat je wilt de-blokeren</param>
        /// <returns>Gelukt?</returns>
        public bool DeblokkeerSpoor(string spoorID)
        {
            string cmd = "UPDATE Sector SET Blokkade = 'n' WHERE SpoorID = '" + spoorID + "' AND TramID IS NULL";
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
        /// Deze methode haalt alle sectoren op uit de database en 
        /// </summary>
        /// <returns>Een Array met daarin Informatie over de Sporen</returns>
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
        public int GetSpoorIDByNr(int spoorNr)
        {
            String cmd = "SELECT ID FROM SPOOR WHERE NUMMER =" + spoorNr;
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                this.connection.Open();

                int reint = 0;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reint = reader.GetInt32(0);
                }
                return reint;
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
    }
}