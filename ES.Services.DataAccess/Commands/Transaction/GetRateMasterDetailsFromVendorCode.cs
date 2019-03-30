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
    public class GetRateMasterDetailsFromVendorCode : SsDbCommand
    {
        public GetRateMasterDetailsFromVendorCodeQM Execute(Int64 VendorCode, decimal ItemCode)
        {
            var response = new GetRateMasterDetailsFromVendorCodeQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetRateMasterDetailsFromVendorCode]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@ItemCode", SsDbType.Decimal, ParameterDirection.Input, ItemCode  ));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        response.Rate = Convert.ToDecimal(reader["Rate"]);

                        response.Discount = Convert.ToDecimal(reader["Discount"]);
                    }
                }
            }

            return response;
        }
    }
}
