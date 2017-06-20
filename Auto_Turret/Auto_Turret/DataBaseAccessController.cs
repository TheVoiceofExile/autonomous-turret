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
        public int ConnectToDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int response = OpenConnection(connection);

                connection.Close();
                return response;
            }
        }

        public string GetDatabaseString()
        {
            return "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                     + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                     + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public void Query(IQuery q)
        {

        }

        private int OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                return 0;
            }

            return 1;
        }
    }
}
