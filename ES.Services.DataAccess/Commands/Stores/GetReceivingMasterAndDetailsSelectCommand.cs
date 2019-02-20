using ES.Services.DataAccess.Model.QueryModel.Stores;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GetReceivingMasterAndDetailsSelectCommand : SsDbCommand
    {
        public GetGPReceivingResponseQM Execute(long vendorCode)
        {
            var response = new GetGPReceivingResponseQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPReceivingMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, vendorCode));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getGPReceivingResponseModel = reader.ToList<GetGPReceivingResponseModel>();
                }
            }
            return response;
        }
    }
}
