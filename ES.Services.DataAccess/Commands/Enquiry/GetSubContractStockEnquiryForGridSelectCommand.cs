using ES.Services.DataAccess.Model.QueryModel.Enquiry;
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
    public class GetSubContractStockEnquiryForGridSelectCommand : SsDbCommand
    {
        public GetSubContractStockEnquiryQM Execute()
        {
            GetSubContractStockEnquiryQM response = new GetSubContractStockEnquiryQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSubContractStockEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetSubContractStockEnquiryModelList = reader.ToList<GetSubContractStockEnquiryModel>();
                }
            }

            return response;
        }
    }
}
