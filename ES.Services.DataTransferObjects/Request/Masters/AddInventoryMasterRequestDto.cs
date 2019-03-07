using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
   public class AddInventoryMasterRequestDto
    {
        public string ItemDescription { get; set; }
        public decimal UOMCode { get; set; }
        public decimal GroupCode { get; set; }
        public decimal BaseRate { get; set; }
        public decimal ReOrderQuantity { get; set; }
        public decimal MinimumOrderQuantity { get; set; }
        public decimal StockQuantity { get; set; }
    }
}
