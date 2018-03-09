using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Despatch
{
    public interface IReportDeliveryChallan 
    {
        GetDcTypeResponseDto GetDCType();

        GetWOMasterForDcResponseDto GetWoMasterForDc(GetWOMasterForDcRequestDto getWOMasterForDcRequestDto);

        GetDCNumberResponseDto GetDCNumber(string WoType);

        GetDcMasterResponseDto GetDcMaster();
    }
}
