using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Auto_Turret
{
    public class DataBaseAccessController
    {
        public List<TurretnameEventtypeEventtimeData> TurretEvents = new List<TurretnameEventtypeEventtimeData>();
        private SqlConnection connection;
        public int ConnectToDatabase(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            int response=1;
            OpenConnection();

            string statement = GetQueryString();

            SqlDataReader reader = ExecuteQuery(connection, statement);
            InterpretSqlReader(reader);
            CloseConnection();

            return response;
        }

        public string GetDatabaseString()
        {
            return "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                     + "Persist Security Info = False; User ID = ironicism1; Password =Unknown8*;"
                     + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public string GetQueryString()
        {
            List<string> select = new List<string> { "turret_name", "eventtype", "eventtime" };
            List<string> from = new List<string> { "dbo.Turrets", "dbo.Events" };
            List<string> where = new List<string> { "Turrets.turret_id=Events.fk_turret_id" };

            BuildQueryStatement statement = new BuildQueryStatement(select, from, where);

            return statement.BuildQueryString();
        }

        private void OpenConnection()
        {
            try
            {
                connection.Open();
                Debug.WriteLine("Connection opened");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection Failed To Open: " + e.ToString());
            }
        }

        private int CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch(SqlException)
            {
                return 0;
            }
            return 1;
        }

        private SqlDataReader ExecuteQuery(SqlConnection connection, string statement)
        {
            SqlCommand command = new SqlCommand(statement, connection);
            SqlDataReader reader;

            command.CommandText = statement;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            reader = command.ExecuteReader();

            return reader;
        }

        private void InterpretSqlReader(SqlDataReader reader)
        {
            while(reader.Read())
            {
                TurretEvents.Add(new TurretnameEventtypeEventtimeData(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2)));
            }
        }
    }
}
