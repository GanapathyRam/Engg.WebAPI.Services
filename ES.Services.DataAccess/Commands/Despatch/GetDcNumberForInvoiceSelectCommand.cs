using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using System;
using SS.Framework.DataAccess;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDcNumberForInvoiceSelectCommand : SsDbCommand
    {
        public GetDcNumberForInvoiceQM Execute(Int64 VendorCode, string WoType)
        {
            var response = new GetDcNumberForInvoiceQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDcNumberForInvoice]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.NVarChar, ParameterDirection.Input, WoType));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetDcNumberForInvoiceList = reader.ToList<GetDcNumberForInvoiceModel>();
                }
            }
            return response;
        }
    }
}
