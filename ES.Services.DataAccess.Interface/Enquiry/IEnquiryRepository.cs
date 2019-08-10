using ES.Services.DataAccess.Model.QueryModel.Enquiry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Enquiry
{
    public interface IEnquiryRepository
    {
        DataSet GetStockEnquiry(Int16 Option);

        StockEnquiryOptionQM GetStockEnquiryForGrid(Int16 Option);

        DespatchEnquiryOptionQM GetDespatchEnquiryForGrid(Int16 Option, DateTime? FromDate, DateTime? ToDate);

        DataSet GetDespatchEnquiry(Int16 Option, DateTime? FromDate, DateTime? ToDate);

        DataSet GetInvoicedEnquiry();

        InvoicedEnquiryOptionQM GetInvoicedEnquiryForGrid();

        DataSet GetSerialNoEnquiry(string SerialNo);

        SerialNoEnquiryOptionQM GetSerialNoEnquiryForGrid(string SerialNo);

        DataSet GetDeliveryFollowUpEnquiry(DateTime FromDate);

        DeliveryFollowUpOptionQM GetDeliveryFollowUpEnquiryForGrid(DateTime FromDate);

        DataSet GetSalesEnquiry(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type);

        SalesEnquiryOptionQM GetSalesEnquiryForGrid(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type);

        DataSet GetSubContractStockEnquiry();

        DataSet GetDespatchDetailsEnquiry(DateTime FromDate, DateTime ToDate);

    }
}
