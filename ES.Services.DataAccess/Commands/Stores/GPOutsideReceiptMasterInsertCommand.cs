using ES.Services.DataAccess.Model.CommandModel.Stores;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GPOutsideReceiptMasterInsertCommand : SsDbCommand
    {
        public void Execute(GPOutsideMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPOutsideReceiptMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideType", SsDbType.VarChar, ParameterDirection.Input, model.GPOutsideType));
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReceiptNumber", SsDbType.VarChar, ParameterDirection.Input, model.GPOutsideReceiptNumber));
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReceiptDate", SsDbType.DateTime, ParameterDirection.Input, model.GPOutsideReceiptDate));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input,model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@RecievedBy", SsDbType.VarChar, ParameterDirection.Input, model.RecievedBy));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.VarChar, ParameterDirection.Input, model.CreatedBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, model.CreatedDateTime));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
