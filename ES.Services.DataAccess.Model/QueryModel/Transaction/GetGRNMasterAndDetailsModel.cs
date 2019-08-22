using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetGRNMasterAndDetailsModel
    {
        public string GRNNumber { get; set; }

        public DateTime GRNDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public decimal GRNSerial { get; set; }

        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal StockQuantity { get; set; }

        public bool IsDeletable { get; set; }
    }
}
