using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Auto_Turret
{
    public class DataBaseAccessController
    {
        public List<TurretnameEventtypeEventtimeData> TurretEvents = new List<TurretnameEventtypeEventtimeData>();

        public int ConnectToDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int response = OpenConnection(connection);

                string statement = GetQueryString();

                SqlDataReader reader = ExecuteQuery(connection, statement);
                InterpretSqlReader(reader);
                CloseConnection(connection);
                
                return response;
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

            BuildQueryStatement statement = new BuildQueryStatement(select, from, where);

            return statement.BuildQueryString();
        }

        private int OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection Failed To Open");
                return 0;
            }

            return 1;
        }

        private int CloseConnection(SqlConnection connection)
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
