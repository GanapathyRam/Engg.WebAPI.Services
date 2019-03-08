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
    public class RateMasterDeleteCommand: SsDbCommand
    {
        public DeleteRateMasterQM Execute(DeleteRateMasterCM model)
        {
            var response = new DeleteRateMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteRateMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ItemCode", SsDbType.BigInt, ParameterDirection.InputOutput, model.ItemCode));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, model.VendorCode));
                sqlCommand.ExecuteNonQuery();
                response.ItemCode = Convert.ToInt32(sqlCommand.Parameters["@ItemCode"].Value);
                return response;
            }

        }

    }
}
