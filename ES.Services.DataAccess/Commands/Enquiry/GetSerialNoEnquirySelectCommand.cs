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
    class GetSerialNoEnquirySelectCommand : SsDbCommand
    {
        public DataSet Execute(string SerialNo)
        {
            DataSet ds = new DataSet();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSerialNoEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.NVarChar, ParameterDirection.Input, SerialNo));

                ds = SsDbCommandHelper.ExecuteDataset(sqlCommand);
            }

            return ds;
        }
    }
}
