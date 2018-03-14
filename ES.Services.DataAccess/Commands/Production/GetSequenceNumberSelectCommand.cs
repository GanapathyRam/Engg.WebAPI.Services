using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Production;
using SS.Framework.DataAccess;

namespace ES.Services.DataAccess.Commands.Production
{
    public class GetSequenceNumberSelectCommand : SsDbCommand
    {
        public GetSequenceNumberQM Execute(decimal PartCode)
        {
            var response = new GetSequenceNumberQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSequenceNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.SequenceNumberList = reader.ToList<GetSequenceNumberModel>();
                }
            }
            return response;
        }
    }
}
