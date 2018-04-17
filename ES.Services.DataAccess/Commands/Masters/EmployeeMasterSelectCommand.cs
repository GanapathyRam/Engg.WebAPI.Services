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
    class EmployeeMasterSelectCommand : SsDbCommand
    {
        public GetEmployeeMasterQM Execute()
        {
            var response = new GetEmployeeMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetEmployeeMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@RecordCount", SsDbType.Int, ParameterDirection.Output, default(int)));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.EmployeeMasterList = reader.ToList<EmployeeMasterModel>();
                }
                response.RecordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
            }
            return response;
        }
    }
}
