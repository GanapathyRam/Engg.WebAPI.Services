using ES.Services.DataAccess.Model.QueryModel.Enquiry;
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

namespace ES.Services.DataAccess.Commands.Enquiry
{
    public class GetSalesEnquiryForGridSelectCommand : SsDbCommand
    {
        public SalesEnquiryOptionQM Execute(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type)
        {
            SalesEnquiryOptionQM response = new SalesEnquiryOptionQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSalesEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@FromDate", SsDbType.DateTime, ParameterDirection.Input, FromDate));
                sqlCommand.Parameters.Add(AddParameter("@ToDate", SsDbType.DateTime, ParameterDirection.Input, ToDate));
                sqlCommand.Parameters.Add(AddParameter("@WorkOrderType", SsDbType.SmallInt, ParameterDirection.Input, WorkOrdeType));
                sqlCommand.Parameters.Add(AddParameter("@IsOption", SsDbType.SmallInt, ParameterDirection.Input, Option));
                sqlCommand.Parameters.Add(AddParameter("@Type", SsDbType.NVarChar, ParameterDirection.Input, Type));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getSalesEnquiryOptionModel = reader.ToList<SalesEnquiryOptionModel>();
                }
            }

            return response;
        }
    }
}
