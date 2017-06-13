using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class TurretOwner
    {
        int user_id;
        int turret_id;
        string twitter = "null";

        public TurretOwner(int user_id, int turret_id, string twitter)
        {
            this.user_id = user_id;
            this.turret_id = turret_id;
            this.twitter = twitter;
        }

        public int getUser_ID()
        {
            return this.user_id;
        }

        public int getTurret_ID()
        {
            return this.turret_id;
        }

        public string getTwitter()
        {
            return this.twitter;
        }
    }
}
