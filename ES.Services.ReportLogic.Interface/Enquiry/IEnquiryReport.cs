using ES.Services.DataTransferObjects.Request.Enquiry;
using ES.Services.DataTransferObjects.Response.Enquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Enquiry
{
    public interface IEnquiryReport
    {
        void GetStockEnquiry(Int16 Option, string filePath);

        StockEnquiryOptionResponseDto GetStockEnquiryForGrid(Int16 Option);

        DespatchEnquiryOptionResponseDto GetDespatchEnquiryForGrid(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto);

        void GetDespacthEnquiry(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto, string filePath);

        void GetInvoicedEnquiry(string filePath);

        InvoicedEnquiryOptionResponseDto GetInvoicedEnquiryForGrid();

        void GetSerialNoEnquiry(string filePath, string SerialNo);

        SerialNoEnquiryOptionResponseDto GetSerialNoEnquiryForGrid(string SerialNo);

        void GetDeliveryFollowUpEnquiry(string filePath, DateTime FromDate);

        DeliveryFollowUpEnquiryOptionResponseDto GetDeliveryFollowUpEnquiryForGrid(DateTime FromDate);

        void GetSalesEnquiry(string filePath, DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type);

        SalesEnquiryOptionResponseDto GetSalesEnquiryForGrid(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type);

        void GetSubContractStockEnquiry(string filePath);

        void GetDespatchDetailsEnquiry(string filePath, DateTime FromDate, DateTime ToDate);

    }
}
