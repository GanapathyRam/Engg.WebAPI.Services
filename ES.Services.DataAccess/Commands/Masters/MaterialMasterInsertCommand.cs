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
    public class MaterialMasterInsertCommand : SsDbCommand
    {
        public int Execute(AddMaterialMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddMaterialMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@MaterialDescription", SsDbType.VarChar, ParameterDirection.Input, model.MaterialDescription));
                sqlCommand.Parameters.Add(AddParameter("@MaterialShortDescription", SsDbType.VarChar, ParameterDirection.Input, model.MaterialShortDescription));
                               
                //sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, model.CreatedBy));
                //sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, model.CreatedDateTime));

                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@MaterialCode", SsDbType.Decimal, ParameterDirection.Output, default(int)));
                sqlCommand.ExecuteNonQuery();

                return Convert.ToInt32(sqlCommand.Parameters["@MaterialCode"].Value);
            }

        }
    }
}
