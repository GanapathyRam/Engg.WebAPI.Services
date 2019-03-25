using ES.Services.DataAccess.Model.CommandModel.Stores;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GPOutsideReturnMasterInsertCommand : SsDbCommand
    {
        public void Execute(GPOutsideReturnMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPOutsideReturnMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReturnNumber", SsDbType.VarChar, ParameterDirection.Input, model.GPOutsideReturnNumber));
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReturnDate", SsDbType.DateTime, ParameterDirection.Input, model.GPOutsideReturnDate));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.VarChar, ParameterDirection.Input, model.CreatedBy));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
