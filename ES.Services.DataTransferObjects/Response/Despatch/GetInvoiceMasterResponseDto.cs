using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetInvoiceMasterResponseDto : BaseResponse
    {
        public IEnumerable<GetInvoiceMasterResponseModel> GetInvoiceMasterResponseModel { get; set; }
    }

    public class GetInvoiceMasterResponseModel
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
    }
}
