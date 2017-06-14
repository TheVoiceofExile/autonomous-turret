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
        public int ConnectToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(GetDatabaseString()))
            {
                connection.Open();
                //do some stuff
                //likely call an query interface class that
                //directly interacts with the database and the
                //concrete class queries will implement that
                connection.Close();
                return 1;
            }

            return 0;
        }

        public string GetDatabaseString()
        {
            return "Server = tcp:softdev.database.windows.net,1433; Initial Catalog = AutoTurret;"
                     + "Persist Security Info = False; User ID = ironicism; Password =Unknown8*;"
                     + "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }
    }
}
