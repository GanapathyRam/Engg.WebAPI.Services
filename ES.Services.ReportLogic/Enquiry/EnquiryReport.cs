using ES.Services.DataAccess.Interface.Enquiry;
using ES.Services.ReportLogic.Enquiry;
using ES.Services.ReportLogic.Interface.Enquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Enquiry
{
    public class EnquiryReport : IEnquiryReport
    {
        private readonly IEnquiryRepository enquiryRepository;

        public EnquiryReport(IEnquiryRepository enquiryRepository)
        {
            this.enquiryRepository = enquiryRepository;
        }

        public string GetStockEnquiry()
        {
            string filePath = string.Empty;
            var model = enquiryRepository.GetStockEnquiry();

            //if (model != null)
            //{
            //    response = DcNumberForInvoiceMapper((List<GetDcNumberForInvoiceModel>)model.GetDcNumberForInvoiceList, response);
            //}

            return filePath;
        }
    }
}
