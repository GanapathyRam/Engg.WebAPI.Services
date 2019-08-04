using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GetGPReceivingResponseModel
    {
        public string GPNumber { get; set; }

        public string GPType { get; set; }

        public DateTime GPDate { get; set; }

        public string VendorName { get; set; }

        public string RequestedBy { get; set; }

        public int GPSerialNo { get; set; }

        public string Description { get; set; }

        public decimal Units { get; set; }

        public string UnitsDescription { get; set; }

        public decimal SentQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal BalanceQty { get; set; }
    }
}
