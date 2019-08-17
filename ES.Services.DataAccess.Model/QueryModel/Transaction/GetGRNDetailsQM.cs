using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetGRNDetailsQM
    {
        public IEnumerable<GetGRNDetailsModel> GetGRNDetailsModelList { get; set; }
    }

    public class GetGRNDetailsModel
    {
        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public decimal Itemcode { get; set; }

        public string ItemDescription { get; set; }

        public decimal UOMCode { get; set; }

        public string UOMDescription { get; set; }

        public decimal POQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal BalanceQuantity { get; set; }

        public decimal GRNReceivedQty { get; set; }

    }
}
