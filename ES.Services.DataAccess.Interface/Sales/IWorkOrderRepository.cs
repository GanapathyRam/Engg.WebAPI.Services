using ES.Services.DataAccess.Model.CommandModel.Sales;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Sales
{
    public interface IWorkOrderRepository
    {
        GetWorkOrderTypeQM GetWorkOrderType();

        string GetWorkOrderNumber();

        GetWorkOrderClientSerialNoQM GetWorkOrderClientSerialNo();
        GetWorkOrderQM GetWorkOrder();

        AddWorkOrderQM AddWorkOrder(AddWorkOrderCM workOrderCM);
        void UpdateWorkOrder(UpdateWorkOrderCM workOrderCM);
        void AddWorkOrderDetails(WorkOrderDetailsCM workOrderDetailsCM);
        void DeleteWorkOrder(GetWorkOrderDetailsStatusCM deleteWorkOrderCM);
        void AddWorkOrderMasterCommon(string WorkOrderType, string WorkOrderNumber, DateTime WorkOrderDate, Int64 VendorCode);
        GetWorkOrderDetailsStatusQM GetWorkOrderDetailsStatus(GetWorkOrderDetailsStatusCM getWorkOrderDetailsStatusCM);
    }
}
