using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Despatch
{
    public interface IBusinessDeliveryChallan
    {
        DeliveryChallanResponseDto AddDeliveryChallan(DeliveryChallanRequestDto deliveryChallanRequestDto);

        DeleteDcResponseDto DeleteDcDetails(DeleteDcRequestDto deleteDcRequestDto);
    }
}
