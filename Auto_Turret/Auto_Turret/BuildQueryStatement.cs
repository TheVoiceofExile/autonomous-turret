using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Auto_Turret
{
    public class BuildQueryStatement : IQuery
    {
        public string SelectStatement = string.Empty;
        public string FromStatement = string.Empty;
        public string WhereStatement = string.Empty;
        public BuildQueryStatement(List<string> columns, List<string> tables, SearchParametersData arguments)
        {
            CombineSelectStatement(columns);
            CombineFromStatement(tables);
            CombineWhereStatement(arguments);
        }

        public string BuildQueryString()
        {
            string QueryStatement = SelectStatement + " " + FromStatement + " " + WhereStatement;
            Console.WriteLine(QueryStatement);
            return QueryStatement;
        }

        private void CombineSelectStatement(List<string> columns)
        {
            SelectStatement += "SELECT ";

            for (int i = 0; i < columns.Count; i++)
            {
                SelectStatement += columns[i];
                if (i < columns.Count-1)
                    SelectStatement += ", ";
            }
        }

        private void CombineFromStatement(List<string> tables)
        {
            FromStatement += "FROM ";
            
            for(int i = 0; i < tables.Count; i++)
            {
                FromStatement += tables[i];
                if(i < tables.Count-1)
                    FromStatement += ", ";
            }
        }

        private void CombineWhereStatement(SearchParametersData arguments)
        {
            WhereStatement += "WHERE ";

            AddFromDateToWhereStatement(arguments.FromDate);
            AddToDateToWhereStatement(arguments.ToDate);
            AddEventTypesToWhereStatement(arguments);
        }

        private void AddFromDateToWhereStatement(string fromDate)
        {
            WhereStatement += "Events.eventtime >= " + "Convert(datetime, '" + fromDate + "') AND ";
        }

        private void AddToDateToWhereStatement(string toDate)
        {
            WhereStatement += "Events.eventtime < " + "Convert(datetime, '" + toDate + "')";
        }

        private void AddEventTypesToWhereStatement(SearchParametersData arguments)
        {
            if(AreSelectedEventTypesNotEqual(arguments))
            {
                AddEventToWhereStatement(arguments);
            }
        }

        private bool AreSelectedEventTypesNotEqual(SearchParametersData arguments)
        {
            if(arguments.SearchFireEvents != arguments.SearchWarnings)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddEventToWhereStatement(SearchParametersData arguments)
        {
            if (arguments.SearchFireEvents)
            {
                WhereStatement += @" AND Events.event_type = ""shots fired""";
            }
            else
            {
                WhereStatement += @" AND Events.event_type = ""warning""";
            }
        }
    }
}
