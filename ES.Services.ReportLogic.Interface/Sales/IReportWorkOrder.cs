using ES.Services.DataTransferObjects.Request.Sales;
using ES.Services.DataTransferObjects.Response.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Sales
{
    public interface IReportWorkOrder
    {
        GetWorkOrderTypeResponseDto GetWorkOrderType();

        GetWorkOrderNumberResponseDto GetWorkOrderNumber();
        //GetWorkOrderClientSerialNoResponseDto GetWorkOrderClientSerialNo();
        GetWorkOrderResponseDto GetWorkOrder();
        GetWorkOrderClientSerialNoResponseDto GetWorkOrderClientSerialNo(string shortCode);
        GetWorkOrderHeatResponseDto GetWorkOrderHeatList(GetWorkOrderHeatRequest getWorkOrderHeatRequest);
        GetWorkOrderNumberForHeatResponseDto GetWorkOrderNumberHeat();
        GetJobCardEntryReportResponseDto GetJobCardEntryReport(GetJobCardEntryReportRequestDto getJobCardEntryReportRequestDto);
    }
}
