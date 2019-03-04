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
    public class VendorTermsMasterInsertCommand : SsDbCommand
    {
        public AddVendorTermsMasterQM Execute(AddVendorTermsMasterCM model)
        {
            var response = new AddVendorTermsMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddVendorTermsMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeliveryTerms", SsDbType.VarChar, ParameterDirection.Input, model.DeliveryTerms));
                sqlCommand.Parameters.Add(AddParameter("@Documents", SsDbType.VarChar, ParameterDirection.Input, model.Documents));
                sqlCommand.Parameters.Add(AddParameter("@PaymentTerms", SsDbType.VarChar, ParameterDirection.Input, model.PaymentTerms));
                sqlCommand.Parameters.Add(AddParameter("@Transport", SsDbType.VarChar, ParameterDirection.Input, model.Transport));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@IGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.IGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@CGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.CGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@SGSTPercent", SsDbType.Decimal, ParameterDirection.Input, model.SGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.VarChar, ParameterDirection.Input, model.CreatedBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.InputOutput, model.VendorCode));
                sqlCommand.ExecuteNonQuery();
                response.VendorCode = Convert.ToInt32(sqlCommand.Parameters["@VendorCode"].Value);
                return response;
            }

        }

    }
}
