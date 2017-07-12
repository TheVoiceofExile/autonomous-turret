using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Turret
{
    class SearchParametersData
    {
        public DateTime FromDate;
        public DateTime ToDate;
        public bool SearchWarnings;
        public bool SearchFireEvents;

        public SearchParametersData()
        {
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            SearchWarnings = true;
            SearchFireEvents = true;
        }
    }
}