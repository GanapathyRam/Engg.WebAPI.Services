using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class UpdatePoDetailsCM
    {
        public IEnumerable<UpdatePoDetailsCMItems> UpdatePoDetailsCMItems { get; set; }
    }

    public class UpdatePoDetailsCMItems
    {
        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public decimal POAmendNumber { get; set; }

        public string ItemCode { get; set; }

        public string UOMCode { get; set; }

        public decimal POQuantity { get; set; }

        public decimal PORate { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal ItemRate { get; set; }

        public decimal Amount { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal ShortCloseQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
