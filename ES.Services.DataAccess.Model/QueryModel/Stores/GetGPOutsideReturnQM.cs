using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GetGPOutsideReturnQM
    {
        public IEnumerable<GetGPOutsideReturnModel> getGPOutsideReturnList { get; set; }
    }
    public class GetGPOutsideReturnModel
    {
        public string GPOutsideReturnNumber { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public DateTime GPOutsideReturnDate { get; set; }
        public string Remarks { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public string UnitsDescription { get; set; }
        public decimal SentQuantity { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }

    }
}
