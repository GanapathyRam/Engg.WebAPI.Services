using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDCNumberSelectCommand : SsDbCommand
    {
        public string Execute(string WoType)
        {
            //var response = new GetWorkOrderTypeQM();
            string WorkOrderNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDCNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, WoType));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        WorkOrderNumber = Convert.ToString(reader["DCNumber"]);
                    }
                }
            }
            return WorkOrderNumber;
        }
    }
}
