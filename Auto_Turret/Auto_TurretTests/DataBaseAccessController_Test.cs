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
        SearchParametersData SearchParameters = new SearchParametersData();

        [TestMethod]
        [ExpectedException(typeof(SqlException), "Failed To Open Database Connection")]
        public void ConnectToDatabase_Test_Failed_Connection()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-15-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            DataBaseAccessController dbac = new DataBaseAccessController(SearchParameters);

            dbac.PullFromDatabase("Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret; "
                      + "Persist Security Info = False; User ID = ironicism; Password =unknown88;"
                      + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }


        [TestMethod]
        public void GetDatabaseString_Test()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-15-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            DataBaseAccessController dbac = new DataBaseAccessController(SearchParameters);

            StringAssert.Contains(dbac.GetDatabaseString(), "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                    + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                    + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }

        [TestMethod]
        public void GetQueryString()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-15-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            DataBaseAccessController dbac = new DataBaseAccessController(SearchParameters);

            StringAssert.Contains(dbac.GetQueryString(), "SELECT turret_name, eventtype, eventtime FROM dbo.Turrets, dbo.Events WHERE Turrets.turret_id=Events.fk_turret_id");
        }
    }
}