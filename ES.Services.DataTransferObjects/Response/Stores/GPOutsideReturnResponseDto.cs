using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GPOutsideReturnResponseDto : BaseResponse
    {
        public List<GPOutsideReturnMaster> GetGPOutsideReturnResponse { get; set; }
    }
    public class GPOutsideReturnMaster
    {
        public string GPOutsideReturnNumber { get; set; }
        public DateTime GPOutsideReturnDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Remarks { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }
        public List<GPOutsideReturnDetailsRes> GPOutsideReturnDetailsList { get; set; }
    }

    public class GPOutsideReturnDetailsRes
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
