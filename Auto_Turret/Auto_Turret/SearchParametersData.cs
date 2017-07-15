using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Turret
{
    public class SearchParametersData
    {
        public string FromDate;
        public string ToDate;
        public bool SearchWarnings;
        public bool SearchFireEvents;

        public SearchParametersData()
        {
            FromDate = String.Empty;
            ToDate = String.Empty;
            SearchWarnings = true;
            SearchFireEvents = true;
        }
    }
}