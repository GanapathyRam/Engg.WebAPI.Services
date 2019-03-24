using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetPoResponseModel
    {
        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public string UOMCode { get; set; }

        public string UOMDescription { get; set; }

        public decimal POQuantity { get; set; }

        public decimal PORate { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal ItemRate { get; set; }

        public decimal Amount { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal ShortCloseQuantity { get; set; }
    }
}
