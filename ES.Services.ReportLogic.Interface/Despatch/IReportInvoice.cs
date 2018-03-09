using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Despatch
{
    public interface IReportInvoice
    {
        GetInvoiceNumberResponseDto GetInvoiceNumber(string WoType);

        GetDcNumberForInvoiceResponseDto GetDcNumberForInvoice(GetInvoiceNumberRequestDto getInvoiceNumberRequestDto);

        GetDcDetailsForInvoiceResponseDto GetDcDetailsForInvoice(string DcNumber);

        GetInvoiceMasterResponseDto GetInvoiceMaster();

        GetInvoiceDetailsResponseDto GetInvoiceDetails(GetInvoiceDetailsRequestDto getInvoiceDetailsRequestDto);
    }
}
