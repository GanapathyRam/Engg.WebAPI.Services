using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
   public class GPOutsideReturnDetailsCM
    {
        public IEnumerable<GPOutsideReturnDetailsModel> GPOutsideReturnDetailsList { get; set; }
    }

    public class GPOutsideReturnDetailsModel
    {
        public string GPOutsideReturnNumber { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public decimal SentQuantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
