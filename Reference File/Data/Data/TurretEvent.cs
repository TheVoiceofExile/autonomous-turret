using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class TurretEvent
    {
        private int turret_id;
        private int event_id;
        private string twitter;
        private string eventtype;
        

        public TurretEvent(int turret_id, int event_id, string twitter, string eventtype)
        {
            this.turret_id = turret_id;
            this.event_id = event_id;
            this.twitter = twitter;
            this.eventtype = eventtype;
        }
    }
}
