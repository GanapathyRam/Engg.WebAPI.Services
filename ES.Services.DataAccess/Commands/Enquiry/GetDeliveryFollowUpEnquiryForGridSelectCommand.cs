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
    public class GetDeliveryFollowUpEnquiryForGridSelectCommand : SsDbCommand
    {
        public DeliveryFollowUpOptionQM Execute(DateTime FromDate)
        {
            DeliveryFollowUpOptionQM response = new DeliveryFollowUpOptionQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDeliveryFollowUpEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@CutOffDate", SsDbType.DateTime, ParameterDirection.Input, FromDate));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getDeliveryFollowUpOptionModel = reader.ToList<DeliveryFollowUpOptionModel>();
                }
            }

            return response;
        }
    }
}
