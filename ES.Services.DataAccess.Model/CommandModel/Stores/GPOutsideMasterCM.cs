using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPOutsideMasterCM
    {
        public string GPOutsideType { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public DateTime GPOutsideReceiptDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string RecievedBy { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
