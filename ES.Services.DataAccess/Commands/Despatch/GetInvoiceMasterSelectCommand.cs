using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using System;
using SS.Framework.DataAccess;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetInvoiceMasterSelectCommand : SsDbCommand
    {
        public GetInvoiceMasterQM Execute()
        {
            var response = new GetInvoiceMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetInvoiceMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetInvoiceMasterQMModel = reader.ToList<GetInvoiceMasterQMModel>();
                }
            }
            return response;
        }
    }
}
