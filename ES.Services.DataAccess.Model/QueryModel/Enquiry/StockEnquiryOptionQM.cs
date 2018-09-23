using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Enquiry
{
    public class StockEnquiryOptionQM
    {
        public IEnumerable<GetStockOptionEnquiryForSerialModel> getStockOptionEnquiryForSerialModel { get; set; }

        public IEnumerable<GetStockOptionEnquiryForItemModel> getStockOptionEnquiryForItemModel { get; set; }

    }
}
