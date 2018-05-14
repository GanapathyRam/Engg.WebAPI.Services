using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetInvoiceMasterQM
    {
        public IEnumerable<GetInvoiceMasterQMModel> GetInvoiceMasterQMModel { get; set; }
    }

    public class GetInvoiceMasterQMModel
    {
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string DcNumber { get; set; }

        public string Tariff { get; set; }

        public string Vehicle { get; set; }

        public string EWayBill { get; set; }

        public decimal CGSTPercent { get; set; }

        public decimal SGSTPercent { get; set; }

        public decimal IGSTPercent { get; set; }

        public string WoType { get; set; }

        public string WoTypeDescription { get; set; }

        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }
    }   
}
