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
    public class GetDeliveryFollowUpEnquirySelectCommand : SsDbCommand
    {
        public DataSet Execute(DateTime FromDate)
        {
            DataSet ds = new DataSet();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDeliveryFollowUpEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@CutOffDate", SsDbType.DateTime, ParameterDirection.Input, FromDate));

                ds = SsDbCommandHelper.ExecuteDataset(sqlCommand);
            }

            return ds;
        }
    }
}
