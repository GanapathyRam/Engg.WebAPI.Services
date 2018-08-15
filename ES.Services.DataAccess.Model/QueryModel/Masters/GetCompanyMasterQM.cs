using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetCompanyMasterQM
    {
        public IEnumerable<GetCompanyMasterModel> GetCompanyMasterModelList { get; set; }
    }

    public class GetCompanyMasterModel
    {
        public decimal CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPincode { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWeb { get; set; }
        public string CompanyTNGST { get; set; }
        public string CompanyCST { get; set; }
        public string CompanyTIN { get; set; }
        public decimal CGSTPercent { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal IGSTPercent { get; set; }
    }
}
