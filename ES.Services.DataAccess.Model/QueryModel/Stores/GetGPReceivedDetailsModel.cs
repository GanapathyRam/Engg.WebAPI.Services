using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GetGPReceivedDetailsModel
    {
        public string GPReceiptNumber { get; set; }

        public DateTime GPReceiptDate { get; set; }

        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public string DocumentID { get; set; }

        public DateTime DocumentDate { get; set; }

        public string Remarks { get; set; }

        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public decimal ReceiptQuantity { get; set; }

        public string Description { get; set; }
    }
}
