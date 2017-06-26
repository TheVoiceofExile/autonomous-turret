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
        public BuildQueryStatement(List<string> columns, List<string> tables, List<string> arguments)
        {
            CombineSelectStatement(columns);
            CombineFromStatement(tables);
            CheckWhichWhereStatementToUse(arguments);
        }

        public string BuildQueryString()
        {
            string QueryStatement = SelectStatement + " " + FromStatement + " " + WhereStatement;

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

        private void CheckWhichWhereStatementToUse(List<string> arguments)
        {
            if(arguments.Count == 0)
            {
                WhereStatement = string.Empty;
            }
            else
            {
                CombineWhereStatement(arguments);
            }
        }

        private void CombineWhereStatement(List<string> arguments)
        {
            WhereStatement += "WHERE ";

            for(int i = 0; i < arguments.Count; i++)
            {
                WhereStatement += arguments[i];
                if (i < arguments.Count - 1)
                    WhereStatement += "AND ";
            }
        }
    }
}
