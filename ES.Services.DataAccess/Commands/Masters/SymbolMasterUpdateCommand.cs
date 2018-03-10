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
    public class SymbolMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateSymbolMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateSymbolMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@Symbol", SsDbType.VarChar, ParameterDirection.Input, model.Symbol));
                sqlCommand.Parameters.Add(AddParameter("@Name", SsDbType.VarChar, ParameterDirection.Input, model.Name));
                sqlCommand.Parameters.Add(AddParameter("@ContentType", SsDbType.VarChar, ParameterDirection.Input, model.ContentType));
                sqlCommand.Parameters.Add(AddParameter("@Data", SsDbType.VarBinary, ParameterDirection.Input, model.Data));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                
                      sqlCommand.Parameters.Add(AddParameter("@isExistingImage", SsDbType.Bit, ParameterDirection.Input, model.isExistingImage));
                sqlCommand.Parameters.Add(AddParameter("@SymbolCode", SsDbType.Decimal, ParameterDirection.Input, model.SymbolCode));
                sqlCommand.ExecuteNonQuery();

             
            }

        }
    }
}
