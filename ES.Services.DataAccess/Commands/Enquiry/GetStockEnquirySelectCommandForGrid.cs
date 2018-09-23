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
    public class GetStockEnquirySelectCommandForGrid : SsDbCommand
    {
        public StockEnquiryOptionQM Execute(Int16 Option)
        {
            StockEnquiryOptionQM response = new StockEnquiryOptionQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetStockOptionEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@Option", SsDbType.SmallInt, ParameterDirection.Input, Option));

                if (Option == 0)
                {
                    using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                    {
                        response.getStockOptionEnquiryForSerialModel = reader.ToList<GetStockOptionEnquiryForSerialModel>();
                    }
                }
                else
                {
                    using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                    {
                        response.getStockOptionEnquiryForItemModel = reader.ToList<GetStockOptionEnquiryForItemModel>();
                    }
                }
            }

            return response;
        }
    }
}
