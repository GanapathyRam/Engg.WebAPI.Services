using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPOutsideReceiptDetailsCM
    {
        public IEnumerable<GPOutsideReceiptDetailsModel> GPOutsideReceiptDetailsList { get; set; }
    }
    public class GPOutsideReceiptDetailsModel
    {
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal SentQuantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
