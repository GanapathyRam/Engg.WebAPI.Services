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
    public class GetJobCardMaintanceSelectCommand : SsDbCommand
    {
        public GetJobCardMaintanceQM Execute(string SerialNo)
        {
            var response = new GetJobCardMaintanceQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetJobCardMaintance]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.NVarChar, ParameterDirection.Input, SerialNo));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getJobCardMaintanceQMModelList = reader.ToList<GetJobCardMaintanceQMModel>();
                }
            }
            return response;
        }
    }
}
