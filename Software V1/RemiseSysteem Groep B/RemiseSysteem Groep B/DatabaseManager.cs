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
            return instance;}
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

        public Tram ZoekTram(int nummer)
        {
            String cmd = "Select t.*, tt.* From TRAM t, TRAMTYPE tt Where t.Nummer = '" + nummer + "' AND t.TramtypeID = tt.ID"; //het moet zijn: t."Tramtype_ID", uitzoeken hoe dit moet
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
                tram.Status = tramStatus; //werkt dit ?
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

        /*public bool SchoonmaakInvoeren(Schoonmaak schoonmaak) 
        {
            try 
            {
                connection.Open();
                string cmd = "INSERT INTO Tram_Beurt(ID, TramID, DatumTijdstip, TypeOnderhoud, BeurtType) VALUES(" + Convert.ToString(schoonmaak.ID) + ")";
            }
            catch 
            {

            }
            finally 
            {
                connection.Close();
            }
        } */
    }
}
