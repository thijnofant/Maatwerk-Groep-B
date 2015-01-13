using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OracleClient;


namespace RemiseUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public OracleConnection conn = new OracleConnection("User Id=dbi292195;Password=kd1qoIM98M;Data Source=" + "//192.168.15.50:1521/fhictora;");

        [TestMethod]
        public void TestInloggen()
        {
            
            OracleCommand comm = new OracleCommand("insert into medewerker (id,functieid,naam,username,password) values(99,1,'test','test1','test')", conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            RemiseSite_Groep_B.DatabaseManager dbmanager = new RemiseSite_Groep_B.DatabaseManager();
            Assert.AreEqual(dbmanager.Inloggen("test1", "test"), 1);
            comm.CommandText = "Delete from medewerker where id = 99";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            Assert.Equals(dbmanager.Inloggen("test1", "test"), 0);

        }

        [TestMethod]
        public void TestIsSectorBezet()
        {
            OracleCommand comm = new OracleCommand("insert into spoor Values(1,999,0,'N','N')", conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            comm.CommandText = "insert into sector Values(1,999,'Y','N')";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            comm.CommandText = "insert into tram Values(1,9999,'N','N','Y','N')";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            comm.CommandText = "insert into tram_sector Values(9999,999,1,sysdate,sysdate)";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            RemiseSite_Groep_B.DatabaseManager dbmanager = new RemiseSite_Groep_B.DatabaseManager();
            Assert.IsTrue(dbmanager.SectorBezet(1,999));

            comm.CommandText = "delete from tram_sector where spoornr = 999 and sectornr = 1";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            Assert.IsFalse(dbmanager.SectorBezet(1, 999));

            comm.CommandText = "delete from spoor where  nummer = 999)";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            comm.CommandText = "delete from sector where nummer = 1 and spoornr = 999";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            comm.CommandText = "delete from tram where tramtypeid = 1 and nummer 9999";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
