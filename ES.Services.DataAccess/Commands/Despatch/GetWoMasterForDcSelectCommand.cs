using ES.Services.DataAccess.Model.QueryModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetWoMasterForDcSelectCommand : SsDbCommand
    {
        public GetWOMasterForDcQM Execute(long vendorCode, string woType)
        {
            var response = new GetWOMasterForDcQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWoFromCustomerCodeWoTypeForDc]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, vendorCode));
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, woType));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetWOMasterForDcModelList = reader.ToList<GetWOMasterForDcModel>();
                }
            }
            return response;
        }
    }
}
