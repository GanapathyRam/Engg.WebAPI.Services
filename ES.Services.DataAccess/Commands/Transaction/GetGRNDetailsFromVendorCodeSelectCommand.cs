using ES.Services.DataAccess.Model.QueryModel.Transaction;
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

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class GetGRNDetailsFromVendorCodeSelectCommand : SsDbCommand
    {
        public GetGRNDetailsQM Execute(Int64 VendorCode)
        {
            var response = new GetGRNDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGRNDetailsFromVendorCode]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetGRNDetailsModelList = reader.ToList<GetGRNDetailsModel>();
                }
            }

            return response;
        }
    }
}
