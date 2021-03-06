﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

using Auto_Turret;
using Moq;

using MoqRepository;

namespace Auto_TurretTests
{
    /// <summary>
    /// Summary description for QueryDataBase_TurretEvents_Test
    /// </summary>
    ///



    [TestClass]
    public class BuildQueryStatement_Tests
    {


        public BuildQueryStatement_Tests()
        {

            List<Users_Table> users = new List<Users_Table>
            {
                new Users_Table { user_id = 1, twitter = "ironicism.twitter.com" },
                new Users_Table { user_id = 2, twitter = "placeholder.twitter.com" }
            };
            List<Events_Table> events = new List<Events_Table>
                {
                    new Events_Table { events_id = 1, eventType = "warning", eventTime = new DateTime(2017, 6, 17, 14, 24, 33), fk_turret_id = 001 },
                    new Events_Table { events_id = 2, eventType = "warning", eventTime = new DateTime(2017, 6, 17, 14, 27, 33), fk_turret_id = 001 },
                    new Events_Table { events_id = 3, eventType = "shot", eventTime = new DateTime(2017, 6, 17, 14, 34, 33), fk_turret_id = 001 },
                    new Events_Table { events_id = 4, eventType = "warning", eventTime = new DateTime(2017, 6, 17, 14, 24, 33), fk_turret_id = 002 },
                    new Events_Table { events_id = 5, eventType = "shot", eventTime = new DateTime(2017, 6, 17, 14, 24, 43), fk_turret_id = 002 }
                };
            List<Turrets_Table> turrets = new List<Turrets_Table>
                {
                    new Turrets_Table { turret_id = 1, turret_name = "bedroom turret", onoff = 0, fk_user_id = 1 },
                    new Turrets_Table { turret_id = 2, turret_name = "family turret", onoff = 1, fk_user_id = 1 },
                    new Turrets_Table { turret_id = 3, turret_name = "home_turret", onoff = 0, fk_user_id = 2 }
                };

            Mock<ITurretEventsRepository> mockTurretEventsRepository = new Mock<ITurretEventsRepository>();

            mockTurretEventsRepository.Setup(foo => foo.FindAllUsers()).Returns(users);
            mockTurretEventsRepository.Setup(foo => foo.FindAllTurrets()).Returns(turrets);
            mockTurretEventsRepository.Setup(foo => foo.FindAllEvents()).Returns(events);

            mockTurretEventsRepository.Setup(foo => foo.FindByUserID(It.IsAny<int>())).Returns((int i) => users.Find(x => x.user_id == i));
            mockTurretEventsRepository.Setup(foo => foo.FindByTurretID(It.IsAny<int>())).Returns((int i) => turrets.Find(x => x.turret_id == i));
            mockTurretEventsRepository.Setup(foo => foo.FindByEventID(It.IsAny<int>())).Returns((int i) => events.Find(x => x.events_id == i));

            this.MockTurretEventsRepository = mockTurretEventsRepository.Object;
        }

        private TestContext testContextInstance;

        private ITurretEventsRepository MockTurretEventsRepository;

        private List<Turrets_Table> Turrets = new List<Turrets_Table>();

        List<string> columns = new List<string> { "turret_name", "eventtype", "eventtime" };
        List<string> tables = new List<string> { "dbo.Turrets", "dbo.Events" };
        SearchParametersData SearchParameters = new SearchParametersData();
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        //
        //Test methods for BuildQueryStatement CombineSelectStatement() method
        //
        [TestMethod]
        public void IQuery_BuildQueryStatement_TurretEvents_CombineSelectStatement_1LessCommaThanListCount_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            List<string> columns = new List<string> { "turretname" };
            BuildQueryStatement foo = new BuildQueryStatement(columns, this.tables, this.SearchParameters);

            Assert.AreEqual(false, foo.SelectStatement.Contains(","));
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_TurretEvents_CombineSelectStatement_Complete_String_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            Assert.AreEqual("SELECT turret_name, eventtype, eventtime", foo.SelectStatement);
        }
        //
        //Test methods for BuildQueryStatement CombineFromStatement() method
        //
        [TestMethod]
        public void IQuery_BuildQueryStatement_TurretEvents_FromStatementVariable_NotVoid()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            Assert.AreNotEqual(string.Empty, foo.FromStatement);
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_TurretEvents_CombineFromStatement_1LessCommaThanListCount_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            List<string> tables = new List<string> { "dbo.Turrets" };
            BuildQueryStatement foo = new BuildQueryStatement(this.columns, tables, this.SearchParameters);


            Assert.AreEqual(false, foo.FromStatement.Contains(","));
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_TurretEvents_CombineFromStatement_Complete_String_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            Assert.AreEqual("FROM dbo.Turrets, dbo.Events", foo.FromStatement);
        }
        //
        //Test methods for BuildQueryStatement CombineWhereStatement() method
        //
        [TestMethod]
        public void IQuery_BuildQueryStatement_CombineWhereStatement_1LessAndThanParameters_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            int count = Regex.Matches(foo.WhereStatement, "AND").Count;

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_CombineWhereStatement_AddTurretToWhereStatement_Test()
        {
            this.SearchParameters.FromDate = "";
            this.SearchParameters.ToDate = "";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            StringAssert.Contains(foo.WhereStatement, "Turrets.turret_id=Events.fk_turret_id");
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_CombineWhereStatement_AddFromDateToWhereStatement_Test()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-16-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            string subString = "Events.eventtime >= " + "Convert(datetime, '2017-15-7') AND ";

            StringAssert.Contains(foo.WhereStatement, subString);
        }

        [TestMethod]
        public void IQuery_BuildQuieryStatement_CombineWhereStatement_AddToDateToWhereStatement_Test()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-16-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = false;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);

            string subString = "Events.eventtime < " + "Convert(datetime, '2017-16-7') AND ";

            StringAssert.Contains(foo.WhereStatement, subString);
        }

        [TestMethod]
        public void IQuery_BuildQueryStatement_CombineWhereStatement_Complete_String_Test()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-15-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);
            string actual = "WHERE Turrets.turret_id=Events.fk_turret_id AND " + "Events.eventtime >= " + "Convert(datetime, '2017-15-7') AND Events.eventtime < " + "Convert(datetime, '2017-15-7')";
            Assert.AreEqual(actual, foo.WhereStatement);
        }
        //
        // Tests methods for BuildQueryStatement BuildQueryStatement() method
        //
        [TestMethod]
        public void IQuery_BuildQueryStatement_BuildQueryString_ReturnsFullStatement()
        {
            this.SearchParameters.FromDate = "2017-15-7";
            this.SearchParameters.ToDate = "2017-15-7";
            this.SearchParameters.SearchFireEvents = true;
            this.SearchParameters.SearchWarnings = true;

            BuildQueryStatement foo = new BuildQueryStatement(this.columns, this.tables, this.SearchParameters);
            string actual = "SELECT turret_name, eventtype, eventtime FROM dbo.Turrets, dbo.Events WHERE Turrets.turret_id=Events.fk_turret_id AND " + "Events.eventtime >= " + "Convert(datetime, '2017-15-7') AND Events.eventtime < " + "Convert(datetime, '2017-15-7')";

            Assert.AreEqual(actual, foo.BuildQueryString());


            
        }
    }
}
