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
    public class GetDcSerialForInvoiceSerialSelectCommand : SsDbCommand
    {
        public GetDcSerialForInvoiceSerialQM Execute(string DcNumber)
        {
            var response = new GetDcSerialForInvoiceSerialQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDcDetailsForInvoiceDetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DCNumber", SsDbType.NVarChar, ParameterDirection.Input, DcNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetDcSerialForInvoiceSerialQMList = reader.ToList<GetDcSerialForInvoiceSerialQMModel>();
                }
            }
            return response;
        }
    }
}
