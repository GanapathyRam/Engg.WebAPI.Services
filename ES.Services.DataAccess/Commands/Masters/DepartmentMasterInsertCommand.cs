using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
   public class DepartmentMasterInsertCommand : SsDbCommand
    {
        public AddDepartmentMasterQM Execute(AddDepartmentMasterCM model)
        {
            var response = new AddDepartmentMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddDepartmentMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DepartmentName", SsDbType.VarChar, ParameterDirection.Input, model.DepartmentName));

                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.VarChar, ParameterDirection.Input, model.CreatedBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@DepartmentCode", SsDbType.Decimal, ParameterDirection.Output, default(int)));
                sqlCommand.ExecuteNonQuery();
                response.DepartmentCode = Convert.ToInt32(sqlCommand.Parameters["@DepartmentCode"].Value);
                return response;
            }

        }

    }
}
