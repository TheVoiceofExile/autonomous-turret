using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqRepository
{
    public class Events_Table
    {
        public int events_id;
        public string eventType;
        public DateTime eventTime;
        public int fk_turret_id;
    }
}
