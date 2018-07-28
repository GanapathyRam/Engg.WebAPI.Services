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
    public class GetScReceivingDetailsAndSerialSelectCommand : SsDbCommand
    {
        public GetScReceivingDetailsAndSerialsQM Execute(long vendorCode, string DcNumber)
        {
            var response = new GetScReceivingDetailsAndSerialsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetScReceivingDetailAndSerials]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, vendorCode));
                sqlCommand.Parameters.Add(AddParameter("@ReceivingDCNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getScReceivingDetailsAndSerialsModel = reader.ToList<GetScReceivingDetailsAndSerialsModel>();
                }
            }
            return response;
        }
    }
}
