using ES.Services.DataAccess.Model.QueryModel.Stores;
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
    public class GetGPOutsideReceiptSelectCommand : SsDbCommand
    {
        public GetGPOutsideReceiptQM Execute()
        {
            var response = new GetGPOutsideReceiptQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPOutsideReceiptMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getGPOutsideReceiptList = reader.ToList<GetGPOutsideReceiptModel>();
                }
            }
            return response;
        }
    }
}
