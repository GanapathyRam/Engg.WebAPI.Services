using ES.Services.DataAccess.Model.CommandModel.Transaction;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class PoMasterInsertCommand : SsDbCommand
    {
        public void Execute(AddPoMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddPOMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PONumber", SsDbType.VarChar, ParameterDirection.Input, model.PONumber));
                sqlCommand.Parameters.Add(AddParameter("@POTypeCode", SsDbType.VarChar, ParameterDirection.Input, model.POTypeCode));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.VarChar, ParameterDirection.Input, model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@PODate", SsDbType.DateTime, ParameterDirection.Input, model.PODate));
                sqlCommand.Parameters.Add(AddParameter("@POAmendNumber", SsDbType.Decimal, ParameterDirection.Input, model.POAmendNumber));
                sqlCommand.Parameters.Add(AddParameter("@POAmendDate", SsDbType.DateTime, ParameterDirection.Input, model.POAmendDate));
                sqlCommand.Parameters.Add(AddParameter("@Reference", SsDbType.VarChar, ParameterDirection.Input, model.Reference));
                sqlCommand.Parameters.Add(AddParameter("@ReferenceDate", SsDbType.DateTime, ParameterDirection.Input, model.ReferenceDate));
                sqlCommand.Parameters.Add(AddParameter("@CGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.CGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@SGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.SGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@IGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.IGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@PaymentTerms", SsDbType.VarChar, ParameterDirection.Input, model.PaymentTerms));
                sqlCommand.Parameters.Add(AddParameter("@DeliveryTerms", SsDbType.VarChar, ParameterDirection.Input, model.DeliveryTerms));
                sqlCommand.Parameters.Add(AddParameter("@Documents", SsDbType.VarChar, ParameterDirection.Input, model.Documents));
                sqlCommand.Parameters.Add(AddParameter("@Transport", SsDbType.VarChar, ParameterDirection.Input, model.Transport));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, Guid.NewGuid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));                

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
