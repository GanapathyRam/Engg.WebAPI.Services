using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Enquiry
{
    public class GetDespatchEnquirySelectCommand : SsDbCommand
    {
        public DataSet Execute(Int16 Option, DateTime? fromDate, DateTime? ToDate)
        {
            DataSet ds = new DataSet();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDespatchEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@FromDate", SsDbType.DateTime, ParameterDirection.Input, fromDate));
                sqlCommand.Parameters.Add(AddParameter("@ToDate", SsDbType.DateTime, ParameterDirection.Input, ToDate));
                sqlCommand.Parameters.Add(AddParameter("@IsOption", SsDbType.SmallInt, ParameterDirection.Input, Option));

                ds = SsDbCommandHelper.ExecuteDataset(sqlCommand);
            }

            return ds;
        }
    }
}
