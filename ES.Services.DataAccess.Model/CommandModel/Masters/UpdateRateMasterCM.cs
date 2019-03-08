using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class UpdateRateMasterCM
    {
        public decimal ItemCode { get; set; }
        public decimal VendorCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public string UpdatedBy { get; set; }
    }
}
