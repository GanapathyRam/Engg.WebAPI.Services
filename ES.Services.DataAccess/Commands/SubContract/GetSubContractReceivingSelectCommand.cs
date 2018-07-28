using ES.Services.DataAccess.Model.QueryModel.SubContract;
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

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class GetSubContractReceivingSelectCommand : SsDbCommand
    {
        public GetSubContractReceivingResponseQM Execute(Int64 VendorCode)
        {
            var response = new GetSubContractReceivingResponseQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetScReceivingDetails]";
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getSubContractReceivingResponseModel = reader.ToList<GetSubContractReceivingResponseModel>();
                }
            }
            return response;
        }
    }
}
