using ES.Services.DataAccess.Model.CommandModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class OperationMasterInsertCommand : SsDbCommand
    {
        public int Execute(AddOperationMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddOperationMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@OperationName", SsDbType.VarChar, ParameterDirection.Input, model.OperationName));

                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@OperationCode", SsDbType.Decimal, ParameterDirection.Output, default(int)));
                sqlCommand.ExecuteNonQuery();

                return Convert.ToInt32(sqlCommand.Parameters["@OperationCode"].Value);
            }

        }
    }
}
