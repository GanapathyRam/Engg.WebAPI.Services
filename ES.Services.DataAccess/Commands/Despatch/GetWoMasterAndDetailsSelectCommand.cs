using ES.Services.DataAccess.Model.QueryModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetWoMasterAndDetailsSelectCommand : SsDbCommand
    {
        public GetWoMasterAndDetailsFromCustomerCodeTypeQM Execute(long vendorCode, string woType, string DcNumber, bool Invoiced)
        {
            var response = new GetWoMasterAndDetailsFromCustomerCodeTypeQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWoMasterAndDetailsFromCustomerCodeWoTypeForDc]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, vendorCode));
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, woType));
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@Invoiced", SsDbType.Bit, ParameterDirection.Input, Invoiced));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getWoMasterAndDetailsFromCustomerCodeType = reader.ToList<GetWoMasterAndDetailsFromCustomerCodeTypeModel>();
                }
            }
            return response;
        }
    }
}
