using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class DatabaseManager
    {
        #region singleton
        private static DatabaseManager instance;
        private DatabaseManager() 
        {
            this.Pcn = "********";
            this.Password = "********";
            //TODO: Fix
            //connection.ConnectionString = "User Id=" + this.Pcn + ";Password=" + this.Password + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
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
    }
}
