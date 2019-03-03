using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
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
   public class UnitMasterUpdateCommand : SsDbCommand
    {
        public UpdateUnitMasterQM Execute(UpdateUnitMasterCM model)
        {
            var response = new UpdateUnitMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateUnitMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@UOMDescription", SsDbType.VarChar, ParameterDirection.Input, model.UOMDescription));

                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.VarChar, ParameterDirection.Input, model.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@UOMCode", SsDbType.Decimal, ParameterDirection.InputOutput, model.UOMCode));
                sqlCommand.ExecuteNonQuery();
                response.UOMCode = Convert.ToInt32(sqlCommand.Parameters["@UOMCode"].Value);
                return response;
            }

        }

    }
}
