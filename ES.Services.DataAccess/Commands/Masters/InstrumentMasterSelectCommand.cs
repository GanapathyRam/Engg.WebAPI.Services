using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
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

namespace ES.Services.DataAccess.Commands.Masters
{
    public class InstrumentMasterSelectCommand : SsDbCommand
    {
        public GetInstrumentMasterQM Execute()
        {
            var response = new GetInstrumentMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetInstrumentMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@InstrumentCode", SsDbType.BigInt, ParameterDirection.Input, model.InstrumentCode));
                //sqlCommand.Parameters.Add(AddParameter("@PageSize", SsDbType.Int, ParameterDirection.Input, model.PageSize));
                //sqlCommand.Parameters.Add(AddParameter("@PageIndex", SsDbType.Int, ParameterDirection.Input, model.PageIndex));
                sqlCommand.Parameters.Add(AddParameter("@RecordCount", SsDbType.Int, ParameterDirection.Output, default(int)));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetInstrumentMasterList = reader.ToList<InstrumentMasterModel>();
                }
                response.RecordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
            }

            return response;
        }
    }
}
