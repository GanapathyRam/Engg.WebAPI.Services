using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class VendorMasterModel
    {
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }        
        public string VendorShortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }
        public decimal? PaymentDays { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string VendorCustomerCode { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CERegisterCode { get; set; }
        public string DeliveryChallanTo { get; set; }
        public string InvoiceTo { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
