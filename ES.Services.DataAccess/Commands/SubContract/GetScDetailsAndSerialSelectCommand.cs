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
    public class GetScDetailsAndSerialSelectCommand : SsDbCommand
    {
        public GetScDetailsAndSerialsQM Execute(long vendorCode, string DcNumber)
        {
            var response = new GetScDetailsAndSerialsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSubContractDetailAndSerials]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, vendorCode));
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getScDetailsAndSerialsModel = reader.ToList<GetScDetailsAndSerialsModel>();
                }
            }
            return response;
        }
    }
}
