using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetInventoryMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<InventoryMasterModel> InventoryMasterList { get; set; }
    }

    public class InventoryMasterModel
    {
        public decimal ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal UOMCode { get; set; }
        public string UOMDescription { get; set; }
        public decimal GroupCode { get; set; }
        public string GroupDescription { get; set; }
        public decimal BaseRate { get; set; }
        public decimal ReOrderQuantity { get; set; }
        public decimal MinimumOrderQuantity { get; set; }
        public decimal StockQuantity { get; set; }
    }
}
