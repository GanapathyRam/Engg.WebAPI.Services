using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class AddVendorMasterRequestDto
    {
        //   ,@VendorName varchar(40)
        public string VendorName { get; set; }

        //   ,@CategoryCode varchar(1)
        public string CategoryCode { get; set; }
        //   ,@VendorShortName varchar(10)
        public string VendorShortName { get; set; }
        //   ,@Address1 varchar(30)
        public string Address1 { get; set; }
        //   ,@Address2 varchar(30)
        public string Address2 { get; set; }
        //   ,@City varchar(30)
        public string City { get; set; }
        //   ,@PinCode varchar(10)
        public string PinCode { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        //   ,@TNGST varchar(30)
        public string CompanyGST { get; set; }
        //   ,@CST varchar(30)
        //   ,@PaymentDays numeric(3,0)
        public int PaymentDays { get; set; }
        //   ,@Contact1 varchar(30)
        public string Contact1 { get; set; }
        //   ,@Contact2 varchar(30)
        public string Contact2 { get; set; }
        //   ,@Phone varchar(15)
        public string Phone { get; set; }
        //   ,@Fax varchar(15)
        public string Fax { get; set; }
        //   ,@Email varchar(30)
        public string Email { get; set; }
        //   ,@VendorCustomerCode varchar(10)
        public string VendorCustomerCode { get; set; }
        //   ,@AddedDate varchar(50)
        public DateTime? AddedDate { get; set; }
        //   ,@DeletedDate varchar(50)
        public DateTime DeletedDate { get; set; }
        //   ,@CERegisterCode varchar(15)
        public string CERegisterCode { get; set; }   
    
        //   ,@DCto1 varchar(40)
        public string DeliveryChallanTo { get; set; }
        //   ,@Invoiceto1 varchar(40)
        public string InvoiceTo { get; set; }

        //   ,@CreatedBy uniqueidentifier
        public Guid CreatedBy { get; set; }
        //   , @CreatedDateTime datetime
        public DateTime CreatedDateTime { get; set; }
    }
}
