using ES.Services.DataTransferObjects.Request.Sales;
using ES.Services.DataTransferObjects.Response.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Sales
{
    public interface IBusinessWorkOrder
    {
        WorkOrderResponseDto AddWorkOrder(WorkOrderRequestDto workOrderRequestDto);

        UpdateWorkOrderResponseDto UpdateWorkOrder(UpdateWorkOrderRequestDto updateWorkOrderRequestDto);

        DeleteWorkOrderResponseDto DeleteWorkOrder(DeleteWorkOrderRequestDto deleteWorkOrderRequestDto);
    }
}
