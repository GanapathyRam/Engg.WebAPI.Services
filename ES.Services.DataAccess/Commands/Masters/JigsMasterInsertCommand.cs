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
    public class JigsMasterInsertCommand : SsDbCommand
    {
        public int Execute(AddJigsMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddJigsMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@Description", SsDbType.VarChar, ParameterDirection.Input, model.Description));

                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@JigsCode", SsDbType.Decimal, ParameterDirection.Output, default(int)));
                sqlCommand.ExecuteNonQuery();

                return Convert.ToInt32(sqlCommand.Parameters["@JigsCode"].Value);
            }

        }
    }
}
