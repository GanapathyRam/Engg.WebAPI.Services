using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GPOutsideReturnDetailsGridQM
    {
        public IEnumerable<GPOutsideReturnDetailsGridModel> GetGPReceivedDetailsList { get; set; }
    }

    public class GPOutsideReturnDetailsGridModel
    {
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public string UOMDescription { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal SentQuantity { get; set; }
        public decimal BalanceQty { get; set; }
    }
}
