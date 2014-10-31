using System;
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
                tram.Status = tramStatus;
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
                tram.Status = tramStatus;
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
            String cmd = "Select M.ID, M.Naam, F.Naam FROM MEDEWERKER M INNER JOIN FUNCTIE F ON M.FUNCTIEID = F.ID WHERE M.ID =" + id.ToString();
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
    }
}
