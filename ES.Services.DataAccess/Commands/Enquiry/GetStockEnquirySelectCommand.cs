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
    public class GetStockEnquirySelectCommand : SsDbCommand
    {
        public DataSet Execute()
        {
            DataSet ds = new DataSet();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetStockOptionEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, WoType));

                ds = SsDbCommandHelper.ExecuteDataset(sqlCommand);
            }

            return ds;
        }
    }
}
