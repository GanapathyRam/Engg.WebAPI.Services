using ES.Services.DataAccess.Model.QueryModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetSerialNoForDcSelectCommand : SsDbCommand
    {
        public GetSerialNoFromWoNumerWoSerialQM Execute(string woNumber, decimal woSerial)
        {
            var response = new GetSerialNoFromWoNumerWoSerialQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSerialNoFromWoNumerWoSerialForDc]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, woNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoSerial", SsDbType.Decimal, ParameterDirection.Input, woSerial));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getSerialNoFromWoNumerWoSerialModel = reader.ToList<GetSerialNoFromWoNumerWoSerialModel>();
                }
            }
            return response;
        }
    }
}
