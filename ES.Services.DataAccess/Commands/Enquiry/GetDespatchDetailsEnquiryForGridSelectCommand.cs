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
    class GetDespatchDetailsEnquiryForGridSelectCommand : SsDbCommand
    {
        public GetDespatchDetailsEnquiryQM Execute(DateTime FromDate, DateTime ToDate)
        {
            GetDespatchDetailsEnquiryQM response = new GetDespatchDetailsEnquiryQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDespatchDetailsEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@FromDate", SsDbType.DateTime, ParameterDirection.Input, FromDate));
                sqlCommand.Parameters.Add(AddParameter("@ToDate", SsDbType.DateTime, ParameterDirection.Input, ToDate));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetDespatchDetailsEnquiryModelList = reader.ToList<GetDespatchDetailsEnquiryModel>();
                }
            }

            return response;
        }
    }
}
