using ES.Services.DataAccess.Model.CommandModel.Stores;
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
    public class GPOutsideReturnDetailsGridSelectCommand : SsDbCommand
    {
        public GPOutsideReturnDetailsGridQM Execute(Int64 VendorCode)
        {
            var response = new GPOutsideReturnDetailsGridQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPOutsideReturnDetailsGrid]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetGPReceivedDetailsList = reader.ToList<GPOutsideReturnDetailsGridModel>();
                }
            }
            return response;
        }
    }
}
