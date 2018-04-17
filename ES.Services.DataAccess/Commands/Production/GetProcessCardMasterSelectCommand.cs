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
    public class GetProcessCardMasterSelectCommand : SsDbCommand
    {
        public GetProcessCardMasterQM Execute(decimal PartCode)
        {
            var response = new GetProcessCardMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetProcessCardMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));
                //sqlCommand.Parameters.Add(AddParameter("@SequenceNumber", SsDbType.Decimal, ParameterDirection.Input, SequenceNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetProcessCardMasterModelList = reader.ToList<GetProcessCardMasterQMModel>();
                }
            }
            return response;
        }
    }
}
