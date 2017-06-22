using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Turret
{
    class TurretnameEventtypeEventtimeData
    {
        public string TurretName;
        public string EventType;
        public DateTime EventTime;

        public TurretnameEventtypeEventtimeData(string TurretName, string EventType, DateTime EventTime)
        {
            this.TurretName = TurretName;
            this.EventType = EventType;
            this.EventTime = EventTime;
        }
    }
}
