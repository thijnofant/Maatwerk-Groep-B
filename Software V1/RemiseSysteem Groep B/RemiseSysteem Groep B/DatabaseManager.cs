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

        public Tram GetTram(int ID)
        {
            String cmd = "Select t.*, tt.* From TRAM t, TRAMTYPE tt Where t.ID = '" + ID + "' AND t.Tramtype_ID = tt.ID"; //het moet zijn: t."Tramtype_ID", uitzoeken hoe dit moet
            OracleCommand command = new OracleCommand(cmd, connection);
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                OracleDataReader reader = command.ExecuteReader();
                reader.Read();
                string FoundStatus = reader["Status"].ToString();
                string FoundName = reader["Naam"].ToString();
                string FoundDescription = reader["Omschrijving"].ToString();

                //aanvullen
                TramType tramtype = new TramType(FoundDescription, 1);
                Tram tram = new Tram(ID, tramtype);
                TramStatus tramtypeStatus = (TramStatus)Enum.Parse(typeof(TramStatus), FoundDescription, true);
                tram.Status = tramtypeStatus; //is enum, werkt nu niet
                return tram;

                
            }
            catch
            {

            }
            finally
            {
            }
            return null;
        }
    }
}
