using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Stores
{
    public interface IBusinessGatePass
    {
        GPSendingResponseDto SaveGPSendingDetails(GPSendingRequestDto GPSendingRequestDto);

        DeleteGPSendingResponseDto DeleteGPSendingMasterAndDetails(DeleteGPSendingRequestDto deleteGPSendingRequestDto);

        GPReceivingResponseDto SaveGPReceivingtDetails(GPReceivingRequestDto GPReceivingRequestDto);
    }
}
