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

        List<string> additionalArgs;
        public DataBaseAccessController(List<string> additionalArgs)
        {
            this.additionalArgs = additionalArgs;
        }
        public void ConnectToDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                OpenConnection(connection);
                if (IsConnectionOpen(connection))
                {
                    string statement = GetQueryString();

                    SqlDataReader reader = ExecuteQuery(connection, statement);
                    InterpretSqlReader(reader);
                }
                CloseConnection(connection);
            }
        }

        public string GetDatabaseString()
        {
            return "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                     + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                     + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public string GetQueryString()
        {
            List<string> select = new List<string> { "turret_name", "eventtype", "eventtime" };
            List<string> from = new List<string> { "dbo.Turrets", "dbo.Events" };
            List<string> where = new List<string> { "Turrets.turret_id=Events.fk_turret_id" };
            if(additionalArgs.Count == 0)
            {

            }
            else if (additionalArgs[0] == additionalArgs[1])
            {
                where.Add("Events.eventtime >= " + "Convert(datetime, '" + additionalArgs[0] + "')");
            }
            else
            {
                where.Add("Events.eventtime >= " + "Convert(datetime, '" + additionalArgs[0] + "')");
                where.Add("Events.eventtime < " + "Convert(datetime, '" + additionalArgs[1] + "')");
            }

            BuildQueryStatement statement = new BuildQueryStatement(select, from, where);

            return statement.BuildQueryString();
        }

        private void OpenConnection(SqlConnection connection)
        {

            try
            {
                connection.Open();
                Debug.WriteLine("Connection opened");
            }
            catch (SqlException e)
            {
                Debug.WriteLine("Connection Failed To Open: " + e.ToString());
                throw;
            }
        }

        private void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
                Debug.WriteLine("Connection closed");
            }
            catch(SqlException e)
            {
                Debug.WriteLine("Connection Failed to close" + e.ToString());
                throw;
            }
        }

        private SqlDataReader ExecuteQuery(SqlConnection connection, string statement)
        {
            SqlCommand command = new SqlCommand(statement, connection);
            SqlDataReader reader;

            command.CommandText = statement;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch(InvalidOperationException e)
            {
                Debug.WriteLine("Reader Requires Open Connection, Error is: " + e);
            }

            return null;

        }

        private void InterpretSqlReader(SqlDataReader reader)
        {
            while(reader.Read())
            {
                TurretEvents.Add(new TurretnameEventtypeEventtimeData(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2)));
            }
        }

        private bool IsConnectionOpen(SqlConnection connection)
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                return true;   
            }
            else
            {
                return false;
            }
        }
    }
}
