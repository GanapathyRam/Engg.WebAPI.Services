using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class AddCompanyMasterCommandModel
    {
        public int CompanyCode { get; set; }
        //   ,@CompanyName varchar(40)

        public string CompanyName { get; set; }
        //   ,@CompanyAddress1 varchar(40)
        public string CompanyAddress1 { get; set; }
        //   ,@CompanyAddress2 varchar(40)
        public string CompanyAddress2 { get; set; }

        //   ,@CompanyCity varchar(30)
        public string CompanyCity { get; set; }

        //   ,@CompanyPincode varchar(10)
        public string CompanyPincode { get; set; }

        //   ,@CompanyPhone varchar(15)
        public string CompanyPhone { get; set; }

        //   ,@CompanyFax varchar(15)
        public string CompanyFax { get; set; }

        //   ,@CompanyEmail varchar(30)
        public string CompanyEmail { get; set; }

        //   ,@CompanyWeb varchar(30)
        public string CompanyWeb { get; set; }

        //   ,@CompanyTNGST varchar(20)
        public string CompanyTNGST { get; set; }

        //   ,@CompanyCST varchar(20)
        public string CompanyCST { get; set; }
        //   ,@CompanyTIN varchar(20)
        public string CompanyTIN { get; set; }
        //   ,@CompanyIECode varchar(20)
        public string CompanyIECode { get; set; }
        //   ,@CompanyCECode varchar(20)
        public string CompanyCECode { get; set; }
        //   ,@PFLimit numeric(6,0)
        public int PFLimit { get; set; }
        //   ,@ESILimit numeric(6,0)
        public int ESILimit { get; set; }
        //   ,@PFPercent numeric(5,2)
        public int PFPercent { get; set; }
        //   ,@EPFPercent numeric(5,2)
        public int EPFPercent { get; set; }
        //   ,@FPFPercent numeric(5,2)
        public int FPFPercent { get; set; }
        //   ,@ESIPercent numeric(5,2)
        public int ESIPercent { get; set; }
        //   ,@ESIPercent_Employer numeric(5,2)
        public int ESIPercent_Employer { get; set; }
        //   ,@EDPercent numeric(5,2)
        public int EDPercent { get; set; }
        //   ,@Cess1Percent numeric(5,2)
        public int Cess1Percent { get; set; }
        //   ,@Cess2Percent numeric(5,2)
        public int Cess2Percent { get; set; }
        //   ,@VatPercent numeric(5,2)
        public int VatPercent { get; set; }
        //   ,@CreatedBy uniqueidentifier
        public Guid CreatedBy { get; set; }
        //   , @CreatedDateTime datetime
        public DateTime CreatedDateTime { get; set; }
    }
}
