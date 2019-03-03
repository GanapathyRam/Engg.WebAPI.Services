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
   public class DepartmentMasterUpdateCommand : SsDbCommand
    {
        public UpdateDepartmentMasterQM Execute(UpdateDepartmentMasterCM model)
        {
            var response = new UpdateDepartmentMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateDepartmentMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DepartmentName", SsDbType.VarChar, ParameterDirection.Input, model.DepartmentName));

                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.VarChar, ParameterDirection.Input, model.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@DepartmentCode", SsDbType.Decimal, ParameterDirection.InputOutput, model.DepartmentCode));
                sqlCommand.ExecuteNonQuery();
                response.DepartmentCode = Convert.ToInt32(sqlCommand.Parameters["@DepartmentCode"].Value);
                return response;
            }

        }

    }
}
