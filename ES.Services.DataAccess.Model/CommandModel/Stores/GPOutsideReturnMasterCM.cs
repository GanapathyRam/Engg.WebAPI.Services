using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPOutsideReturnMasterCM
    {
        public string GPOutsideReturnNumber { get; set; }
        public DateTime GPOutsideReturnDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
