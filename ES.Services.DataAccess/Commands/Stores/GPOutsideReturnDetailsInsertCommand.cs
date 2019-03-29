using ES.Services.DataAccess.Model.CommandModel.Stores;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GPOutsideReturnDetailsInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForGPOutsideReturnDetails, GPOutsideReturnDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPOutsideReturnDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReturnDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForGPOutsideReturnDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
