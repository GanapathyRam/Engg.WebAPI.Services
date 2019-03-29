using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GetGPOutsideReceiptResponseDto : BaseResponse
    {
        public List<GPOutsideReceiptMaster> GetGPOutsideReceiptResponse { get; set; }

    }

    public class GPOutsideReceiptMaster
    {
        public string GPOutsideType { get; set; }
        public string GPDescription { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public DateTime GPOutsideReceiptDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public string RecievedBy { get; set; }
        public string RecievedName { get; set; }
        public string Remarks { get; set; }
        public bool IsDeletable { get; set; }
        public List<GPOutsideReceiptDetailsRModel> GPOutsideReceiptDetailsList { get; set; }
    }

    public class GPOutsideReceiptDetailsRModel
    {
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public string UnitsDescription { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal SentQuantity { get; set; }
    }
}
