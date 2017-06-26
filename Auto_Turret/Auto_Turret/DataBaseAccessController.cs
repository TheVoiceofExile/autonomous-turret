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
        List<string> additionalArgs;
        public DataBaseAccessController(List<string> additionalArgs)
        {
            this.additionalArgs = additionalArgs;
        }
        public void ConnectToDatabase(string connectionString)
        {
            connection = new SqlConnection(connectionString);

            OpenConnection();
            if (IsConnectionOpen())
            {
                string statement = GetQueryString();

                SqlDataReader reader = ExecuteQuery(connection, statement);
                InterpretSqlReader(reader);
            }
            CloseConnection();
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

            for(int i=0; i< additionalArgs.Count; i++)
            {
                where.Add(additionalArgs[i]);
            }
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
                throw;
            }
        }

        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine("Connection Failed to close" + e.ToString());
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

        public bool IsConnectionOpen()
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
