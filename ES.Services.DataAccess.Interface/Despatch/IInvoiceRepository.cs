using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;

namespace ES.Services.DataAccess.Interface.Despatch
{
    public interface IInvoiceRepository
    {
        string GetInvoiceNumber(string WoType);

        GetDcNumberForInvoiceQM GetDcNumberForInvoice(long VendorCode, string WoType);

        GetDcDetailsForInvoiceQM GetDcDetailsForInvoice(string DcNumber);

        void AddInvoiceDetails(InvoiceDetailCM InvoiceDetailCM);

        void AddInvoiceMaster(string InvoiceNumber, DateTime InvoiceDate, string DcNumber, string WoType, Int64 VendorCode, string Tariff, string Vehicle, string EWayBill, decimal CGSTPercent,
        decimal SGSTPercent, decimal IGSTPercent, decimal ValueOfGoods, decimal CGSTAmount, decimal SGSTAmount, decimal IGSTAmount, decimal GrandTotal, decimal RoundOff, decimal FineTotal, bool PrintTag);

        void AddInvoiceDetailSerial(InvoiceDetailSerialCM InvoiceDetailSerialCM);

        GetInvoiceMasterQM GetInvoiceMaster();

        GetInvoiceDetailsQM GetInvoiceDetails(string InvoiceNumber);

        void DeleteInvoice(DeleteInvoiceCM deleteInvoiceCM);

        GetDcSerialForInvoiceSerialQM GetDcDetailsSerialForInvoiceSerial(string DcNumber);

        void UpdateInvoiceDetails(InvoiceDetailCM InvoiceDetailCM);

        void UpdateInvoiceMaster(string InvoiceNumber, DateTime InvoiceDate, string DcNumber, string WoType, Int64 VendorCode, string Tariff, string Vehicle, string EWayBill, decimal CGSTPercent,
        decimal SGSTPercent, decimal IGSTPercent, decimal ValueOfGoods, decimal CGSTAmount, decimal SGSTAmount, decimal IGSTAmount, decimal GrandTotal, decimal RoundOff, decimal FineTotal);

        GetDimensionReportQM GetDimensionReport(string InvoiceNumberm, decimal InvoiceSerial, int IsReportFor);

    }
}
