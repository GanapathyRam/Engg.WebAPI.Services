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
   public class RateMasterUpdateCommand : SsDbCommand
    {
        public UpdateRateMasterQM Execute(UpdateRateMasterCM model)
        {
            var response = new UpdateRateMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateRateMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ItemCode", SsDbType.BigInt, ParameterDirection.InputOutput, model.ItemCode));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@Rate", SsDbType.Decimal, ParameterDirection.Input, model.Rate));
                sqlCommand.Parameters.Add(AddParameter("@Discount", SsDbType.Decimal, ParameterDirection.Input, model.Discount));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.VarChar, ParameterDirection.Input, model.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));


                sqlCommand.ExecuteNonQuery();
                response.ItemCode = Convert.ToInt32(sqlCommand.Parameters["@ItemCode"].Value);
                return response;
            }

        }

    }
}
