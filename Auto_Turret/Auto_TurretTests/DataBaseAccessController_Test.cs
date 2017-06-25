using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Auto_Turret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Auto_Turret.Tests
{
    [TestClass()]
    public class DataBaseAccessController_Test
    {
        [TestMethod]
        [ExpectedException(typeof(SqlException), "Failed To Open Database Connection")]
        public void ConnectToDatabase_Test_Failed_Connection()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();

            dbac.ConnectToDatabase("Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret; "
                      + "Persist Security Info = False; User ID = ironicism; Password =unknown88;"
                      + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }

        [TestMethod]
        public void ConnectToDatabase_Test_Successful_Connection()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();
            dbac.ConnectToDatabase(dbac.GetDatabaseString());

            Assert.AreEqual(true, dbac.IsConnectionOpen());
        }

        [TestMethod]
        public void GetDatabaseString_Test()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();

            StringAssert.Contains(dbac.GetDatabaseString(), "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                    + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                    + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }

        [TestMethod]
        public void GetQueryString()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();

            Assert.AreEqual("SELECT turret_name, eventtype, eventtime FROM dbo.Turrets, dbo.Events WHERE Turrets.turret_id=Events.fk_turret_id", dbac.GetQueryString());
        }
    }
}