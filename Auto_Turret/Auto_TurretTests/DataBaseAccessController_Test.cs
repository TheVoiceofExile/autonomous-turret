using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Auto_Turret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Turret.Tests
{
    [TestClass()]
    public class DataBaseAccessController_Test
    {
        [TestMethod()]
        public void ConnectToDatabase_Test_Failed_Connection()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();
            int response = dbac.ConnectToDatabase("Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret; "
                      + "Persist Security Info = False; User ID = ironicism; Password =Unknown88;"
                      + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");


            Assert.AreEqual(0, response);
        }

        [TestMethod()]
        public void ConnectToDatabase_Test_Successful_Connection()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();

            Assert.AreEqual(dbac.ConnectToDatabase(dbac.GetDatabaseString()), 1);
        }

        [TestMethod()]
        public void GetDatabaseString_Test()
        {
            DataBaseAccessController dbac = new DataBaseAccessController();

            StringAssert.Contains(dbac.GetDatabaseString(), "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                    + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                    + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}