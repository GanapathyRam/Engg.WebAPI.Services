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
   public class VendorTermsMasterDeleteCommand : SsDbCommand
    {
        public DeleteVendorTermsMasterQM Execute(DeleteVendorTermsMasterCM model)
        {
            var response = new DeleteVendorTermsMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteVendorTermsMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
             
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.InputOutput, model.VendorCode));
                sqlCommand.ExecuteNonQuery();
                response.VendorCode = Convert.ToInt32(sqlCommand.Parameters["@VendorCode"].Value);
                return response;
            }

        }
    }
}
