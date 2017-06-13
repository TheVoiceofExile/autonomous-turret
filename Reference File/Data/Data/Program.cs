using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenSQLConnection();
        }

        private static void OpenSQLConnection()
        {
            string connectionString = GetConnectionString();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                

                /*
                for(int i = 0; i < 3; i++)
                {
                    InsertRowToUsers(connection, 10000 + i, "something.twitter.com");
                }

                for (int i = 0; i < 3; i++)
                {
                    InsertRowToTurrets(connection, i, 0, 10001);
                }
                */
                

                List<TurretOwner> TOlist = new List<TurretOwner>();
                SqlDataReader reader = GetTurretOwnersTwitter(connection);

                while(reader.Read())
                {
                    TOlist.Add(new TurretOwner(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                }

                for(int i = 0; i< TOlist.Count; i++)
                {
                    Console.WriteLine("User ID: " + TOlist[i].getUser_ID() + "\t\tTurret ID: " + TOlist[i].getTurret_ID() + "\t\tTwitter: " +TOlist[i].getTwitter());
                }

                //Console.WriteLine("State: {0}", connection.State);
                //Console.WriteLine("Connection String: {0}", connection.ConnectionString);
                connection.Close();
            }
            Console.In.ReadLine();
        }

        static private string GetConnectionString()
        {
            return "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                    + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                    + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        static private void InsertRowToUsers(SqlConnection connection, int user_id, string twitter)
        {
            String query = "INSERT INTO dbo.Users (user_id, twitter) VALUES(@user_id, @twitter)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@twitter", twitter);

            command.ExecuteNonQuery();
        }

        static private void InsertRowToTurrets(SqlConnection connection, int turret_id, int onoff, int user_id)
        {
            String query = "INSERT INTO dbo.Turrets (turret_id, onoff, user_id) VALUES(@turret_id, @onoff, @user_id)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@turret_id", turret_id);
            command.Parameters.AddWithValue("@onoff", onoff);
            command.Parameters.AddWithValue("@user_id", user_id);

            command.ExecuteNonQuery();
        }

        static private SqlDataReader GetTurretOwnersTwitter(SqlConnection connection)
        {
            String query = "SELECT user_id, turret_id, twitter FROM dbo.Users, dbo.Turrets WHERE Users.user_id = Turrets.fk_user_id";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            reader = command.ExecuteReader();

            return reader;
        }

    }
}
