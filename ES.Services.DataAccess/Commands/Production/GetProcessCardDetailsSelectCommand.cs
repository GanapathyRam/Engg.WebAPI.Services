using ES.Services.DataAccess.Model.QueryModel.Production;
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

namespace ES.Services.DataAccess.Commands.Production
{
    public class GetProcessCardDetailsSelectCommand : SsDbCommand
    {
        public GetProcessCardDetailsQM Execute(decimal PartCode, decimal SequenceNumber)
        {
            var response = new GetProcessCardDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetProcessCardDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));
                sqlCommand.Parameters.Add(AddParameter("@SequenceNumber", SsDbType.Decimal, ParameterDirection.Input, SequenceNumber));
                //sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.Decimal, ParameterDirection.Input, SerialNo));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetProcessCardDetailsQMModelList = reader.ToList<GetProcessCardDetailsQMModel>();
                }
            }
            return response;
        }
    }
}
