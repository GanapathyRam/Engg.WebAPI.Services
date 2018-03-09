using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class AddCompanyMasterRequestDto
    {
        public int CategoryCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPincode { get; set; }
        public string CompanyTNGST { get; set; }
        public string CompanyCST { get; set; }
        public string CompanyTIN { get; set; }
        public string PaymentDays { get; set; }
        public string ContactPerson1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyEmail { get; set; }
        public string VendorCustomerCode { get; set; }
        public DateTime AddedDate { get; set; }
        public string ExciseCode { get; set; }
        public string AssesseeCode { get; set; }
        public string EccCode { get; set; }
        public string Commissioner { get; set; }
        public string AreaCode { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        public string DeliveryChallanCTo { get; set; }
        public string InvoiceTo { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
