using ES.Services.BusinessLogic.Interface.Sales;
using ES.Services.DataAccess.Interface.Sales;
using ES.Services.DataAccess.Model.CommandModel.Sales;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using ES.Services.DataTransferObjects.Request.Sales;
using ES.Services.DataTransferObjects.Response.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Sales
{
    public class BusinessWorkOrder : IBusinessWorkOrder
    {
        private readonly IWorkOrderRepository workOrderRepository;

        public BusinessWorkOrder(IWorkOrderRepository workOrderRepository)
        {
            this.workOrderRepository = workOrderRepository;
        }

        public WorkOrderResponseDto AddWorkOrder(WorkOrderRequestDto workOrderRequestDto)
        {
            var getWorkOrderClientSerialNoQM = new GetWorkOrderClientSerialNoQM();
            string ClientSerialStartName = System.Configuration.ConfigurationManager.AppSettings["ClientStartName"].ToString();
            string CurrentMonth = Constant.GetMonthByAlphabet(System.DateTime.UtcNow.Month);
            string CurrentYear = Constant.GetYearByAlphabet(System.DateTime.UtcNow.Year);
            var clientSerialDigit = ClientSerialStartName + CurrentYear + CurrentMonth;
            getWorkOrderClientSerialNoQM = workOrderRepository.GetWorkOrderClientSerialNo(clientSerialDigit);

            string clientSerialNo = "";
            string clientSerialNumber = "";
            var existingclientSerialDigit = "";
            if (!string.IsNullOrEmpty(getWorkOrderClientSerialNoQM.WorkOrderClientSerialNo))
            {
                clientSerialNumber = getWorkOrderClientSerialNoQM.WorkOrderClientSerialNo.ToString();
                existingclientSerialDigit =getWorkOrderClientSerialNoQM.WorkOrderClientChar;

            }

            #region Section For to save the work order master common details
            workOrderRepository.AddWorkOrderMasterCommon(workOrderRequestDto.WorkOrderType, workOrderRequestDto.WorkOrderNumber, workOrderRequestDto.WorkOrderDate, workOrderRequestDto.VendorCode);
            #endregion

            #region Section For to save the work order masters information & work order details

            foreach (var workOrderMaster in workOrderRequestDto.WorkOrderMasterDetails)
            {
                var workOrderMasterItems = new List<WorkOrderMasterItems>();

                var cModel = new AddWorkOrderCM();
                var workOrderMasterDetails = new WorkOrderMasterItems
                {
                    WorkOrderNumber = workOrderMaster.WorkOrderNumber,
                    WorkOrderSerial = workOrderMaster.WorkOrderSerial,
                    DCNumber = workOrderMaster.DCNumber,
                    DCDate = workOrderMaster.DCDate,
                    DCSerial = workOrderMaster.DCSerial,
                    PONumber = workOrderMaster.PONumber,
                    PODate = workOrderMaster.PODate,
                    POSerial = workOrderMaster.POSerial,
                    DrawingNo = workOrderMaster.DrawingNo,
                    DrawingRev = workOrderMaster.DrawingRev,
                    PartCode = workOrderMaster.PartCode,
                    WOQuantity = workOrderMaster.WOQuantity,
                    Rate = workOrderMaster.Rate,
                    DeliveryDate = workOrderMaster.DeliveryDate,
                    DCQuantity = 0,
                    RejectedQuantity = 0,
                    InvoicedQuantity = 0,
                    SCSentQuantity = 0,
                    SCReceivedQuantity = 0,
                    CreatedBy = workOrderMaster.CreatedBy,
                    CreatedDateTime = workOrderMaster.CreatedDateTime,
                    VendorCode = workOrderMaster.VendorCode,
                    MaterialCode = workOrderMaster.MaterialCode,
                    ItemCode = workOrderMaster.ItemCode,
                    HeatNo = workOrderMaster.HeatNo
                };

                workOrderMasterItems.Add(workOrderMasterDetails);

                cModel.WorkOrderMasterListItems = workOrderMasterItems;

                // Section to add the work order master information
                var response = workOrderRepository.AddWorkOrder(cModel);



                // Section to add the work order details information
                var quantity = cModel.WorkOrderMasterListItems.FirstOrDefault().WOQuantity;
                var heatNo = cModel.WorkOrderMasterListItems.FirstOrDefault().HeatNo;
                var woSerialNo = cModel.WorkOrderMasterListItems.FirstOrDefault().WorkOrderSerial;
                var workOrderNumber = cModel.WorkOrderMasterListItems.FirstOrDefault().WorkOrderNumber;

                if (!string.IsNullOrEmpty(clientSerialNumber))
                {
                    //var existingclientSerialDigit = clientSerialNo.ToString().Substring(0, 3);

                    if (!clientSerialDigit.Equals(existingclientSerialDigit))
                    {
                        string serialNoStarting = "0";
                        clientSerialNo = clientSerialDigit + serialNoStarting;
                    }
                    else
                    {
                        clientSerialNo = existingclientSerialDigit + clientSerialNumber;
                    }
                }
                else
                {
                    string serialNoStarting = "0";
                    clientSerialNo = clientSerialDigit + serialNoStarting;
                }

                for (int i = 0; i < quantity; i++)
                {
           
                        var splitSerialChar = clientSerialNo.ToString().Substring(0, 3);
                        var splitSerialNo = clientSerialNo.ToString().Substring(3);
                        clientSerialNo = splitSerialChar + ((Convert.ToInt64(splitSerialNo) + 1));
                        clientSerialNumber= ((Convert.ToInt64(splitSerialNo) + 1)).ToString();
                        existingclientSerialDigit = splitSerialChar;
                    WorkOrderDetailsCM workOrderDetailsCM = new WorkOrderDetailsCM()
                    {
                        WorkOrderNumber = workOrderNumber,
                        WorkOrderSerial = woSerialNo,
                        SerialNo = clientSerialNo,
                        HeatNo = heatNo,
                        Invoice = false,
                        JTC = false,
                        SubContract = false,
                        DC = false,
                        CreatedDateTime=System.DateTime.UtcNow
                    };
                    workOrderRepository.AddWorkOrderDetails(workOrderDetailsCM);
                }

            }

            #endregion


            return new WorkOrderResponseDto();
        }

        public UpdateWorkOrderResponseDto UpdateWorkOrder(UpdateWorkOrderRequestDto updateWorkOrderRequestDto)
        {
            var getWorkOrderClientSerialNoQM = new GetWorkOrderClientSerialNoQM();
            string ClientSerialStartName = System.Configuration.ConfigurationManager.AppSettings["ClientStartName"].ToString();
            string CurrentMonth = Constant.GetMonthByAlphabet(System.DateTime.UtcNow.Month);
            string CurrentYear = Constant.GetYearByAlphabet(System.DateTime.UtcNow.Year);
            var clientSerialDigit = ClientSerialStartName + CurrentYear + CurrentMonth;
            getWorkOrderClientSerialNoQM = workOrderRepository.GetWorkOrderClientSerialNo(clientSerialDigit);

            string clientSerialNo = "";
            string clientSerialNumber = "";
            var existingclientSerialDigit = "";
            if (!string.IsNullOrEmpty(getWorkOrderClientSerialNoQM.WorkOrderClientSerialNo))
            {
                clientSerialNumber = getWorkOrderClientSerialNoQM.WorkOrderClientSerialNo.ToString();
                existingclientSerialDigit = getWorkOrderClientSerialNoQM.WorkOrderClientChar;

            }

            foreach (var updateWorKOrder in updateWorkOrderRequestDto.WorkOrderMasterDetails)
            {
                if (updateWorKOrder.IsNew)
                {
                    #region Section For to save the work order masters information & work order details

                    //foreach (var workOrderMaster in updateWorKOrder)
                    //{
                    var workOrderMasterItems = new List<WorkOrderMasterItems>();

                    var cModel = new AddWorkOrderCM();
                    var workOrderMasterDetails = new WorkOrderMasterItems
                    {
                        WorkOrderNumber = updateWorKOrder.WorkOrderNumber,
                        WorkOrderSerial = updateWorKOrder.WorkOrderSerial,
                        DCNumber = updateWorKOrder.DCNumber == null ? string.Empty : updateWorKOrder.DCNumber,
                        DCDate = updateWorKOrder.DCDate == null ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.DCDate),
                        DCSerial = updateWorKOrder.DCSerial == null ? string.Empty : updateWorKOrder.DCSerial,
                        PONumber = updateWorKOrder.PONumber == null ? string.Empty : updateWorKOrder.PONumber,
                        PODate = updateWorKOrder.PODate == null ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.PODate),
                        POSerial = updateWorKOrder.POSerial == null ? string.Empty : updateWorKOrder.POSerial,
                        DrawingNo = updateWorKOrder.DrawingNo,
                        DrawingRev = updateWorKOrder.DrawingRev,
                        PartCode = updateWorKOrder.PartCode,
                        WOQuantity = updateWorKOrder.WOQuantity,
                        Rate = updateWorKOrder.Rate,
                        DeliveryDate = updateWorKOrder.DeliveryDate == null  ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.DeliveryDate),
                        DCQuantity = 0,
                        RejectedQuantity = 0,
                        InvoicedQuantity = 0,
                        SCSentQuantity = 0,
                        SCReceivedQuantity = 0,
                        CreatedBy = updateWorKOrder.CreatedBy,
                        CreatedDateTime = updateWorKOrder.CreatedDateTime,
                        VendorCode = updateWorKOrder.VendorCode,
                        MaterialCode = updateWorKOrder.MaterialCode,
                        ItemCode = updateWorKOrder.ItemCode,
                        HeatNo = updateWorKOrder.HeatNo
                    };

                    workOrderMasterItems.Add(workOrderMasterDetails);

                    cModel.WorkOrderMasterListItems = workOrderMasterItems;

                    // Section to add the work order master information
                    var response = workOrderRepository.AddWorkOrder(cModel);

                   

                    // Section to add the work order details information
                    var quantity = cModel.WorkOrderMasterListItems.FirstOrDefault().WOQuantity;
                    var heatNo = cModel.WorkOrderMasterListItems.FirstOrDefault().HeatNo;
                    var woSerialNo = cModel.WorkOrderMasterListItems.FirstOrDefault().WorkOrderSerial;
                    var workOrderNumber = cModel.WorkOrderMasterListItems.FirstOrDefault().WorkOrderNumber;


                    if (!string.IsNullOrEmpty(clientSerialNumber))
                    {
                        //var existingclientSerialDigit = clientSerialNo.ToString().Substring(0, 3);

                        if (!clientSerialDigit.Equals(existingclientSerialDigit))
                        {
                            string serialNoStarting = "0";
                            clientSerialNo = clientSerialDigit + serialNoStarting;
                        }
                        else
                        {
                            clientSerialNo = existingclientSerialDigit + clientSerialNumber;
                        }
                    }
                    else
                    {
                        string serialNoStarting = "0";
                        clientSerialNo = clientSerialDigit + serialNoStarting;
                    }

                    for (int i = 0; i < quantity; i++)
                    {
                        var splitSerialChar = clientSerialNo.ToString().Substring(0, 3);
                        var splitSerialNo = clientSerialNo.ToString().Substring(3);
                        clientSerialNo = splitSerialChar + ((Convert.ToInt64(splitSerialNo) + 1));
                        clientSerialNumber = ((Convert.ToInt64(splitSerialNo) + 1)).ToString();
                        existingclientSerialDigit = splitSerialChar;

                        WorkOrderDetailsCM workOrderDetailsCM = new WorkOrderDetailsCM()
                        {
                            WorkOrderNumber = workOrderNumber,
                            WorkOrderSerial = woSerialNo,
                            SerialNo = clientSerialNo,
                            HeatNo = heatNo,
                            Invoice = false,
                            JTC = false,
                            SubContract = false,
                            DC = false,
                            CreatedDateTime = System.DateTime.UtcNow
                        };
                        workOrderRepository.AddWorkOrderDetails(workOrderDetailsCM);
                    }

                    //}

                    #endregion
                }
                else
                {
                    #region Section For to save the work order masters information & work order details

                    var updateWorkOrderMasterItems = new List<UpdateWorkOrderMasterItems>();

                    var cModel = new UpdateWorkOrderCM();
                    var workOrderMasterDetails = new UpdateWorkOrderMasterItems
                    {
                        WorkOrderNumber = updateWorKOrder.WorkOrderNumber,
                        WorkOrderSerial = updateWorKOrder.WorkOrderSerial,
                        DCNumber = updateWorKOrder.DCNumber == null ? string.Empty : updateWorKOrder.DCNumber,
                        DCDate = updateWorKOrder.DCDate == null ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.DCDate),
                        DCSerial = updateWorKOrder.DCSerial == null ? string.Empty : updateWorKOrder.DCSerial,
                        PONumber = updateWorKOrder.PONumber == null ? string.Empty : updateWorKOrder.PONumber,
                        PODate = updateWorKOrder.PODate == null ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.PODate),
                        POSerial = updateWorKOrder.POSerial == null ? string.Empty : updateWorKOrder.POSerial,
                        DrawingNo = updateWorKOrder.DrawingNo,
                        DrawingRev = updateWorKOrder.DrawingRev,
                        PartCode = updateWorKOrder.PartCode,
                        WOQuantity = updateWorKOrder.WOQuantity,
                        Rate = updateWorKOrder.Rate,
                        DeliveryDate = updateWorKOrder.DeliveryDate == null ? System.DateTime.UtcNow : Convert.ToDateTime(updateWorKOrder.DeliveryDate),
                        DCQuantity = 0,
                        RejectedQuantity = 0,
                        InvoicedQuantity = 0,
                        SCSentQuantity = 0,
                        SCReceivedQuantity = 0,
                        UpdatedBy = updateWorKOrder.UpdatedBy,
                        UpdatedDateTime = updateWorKOrder.UpdatedDateTime,
                        VendorCode = updateWorKOrder.VendorCode,
                        MaterialCode = updateWorKOrder.MaterialCode,
                        ItemCode = updateWorKOrder.ItemCode,
                        HeatNo = updateWorKOrder.HeatNo
                    };

                    updateWorkOrderMasterItems.Add(workOrderMasterDetails);

                    cModel.UpdateWorkOrderMasterListItems = updateWorkOrderMasterItems;

                    // Section to add the work order master information
                    workOrderRepository.UpdateWorkOrder(cModel);

                }

                #endregion
            }

            return new UpdateWorkOrderResponseDto();
        }

        public DeleteWorkOrderResponseDto DeleteWorkOrder(DeleteWorkOrderRequestDto deleteWorkOrderRequestDto)
        {
            // Section to verify, whether the particular order has delivered or not

            GetWorkOrderDetailsStatusQM getWorkOrderDetailsStatusQM = new GetWorkOrderDetailsStatusQM();
            GetWorkOrderDetailsStatusCM getWorkOrderDetailsStatusCM = new GetWorkOrderDetailsStatusCM
            {
                WorkOrderNumber = deleteWorkOrderRequestDto.WorkOrderNumber,
                WorkOrderSerial = deleteWorkOrderRequestDto.WorkOrderSerial
            };

            getWorkOrderDetailsStatusQM = workOrderRepository.GetWorkOrderDetailsStatus(getWorkOrderDetailsStatusCM);

            if (!getWorkOrderDetailsStatusQM.Dc)
            {
                workOrderRepository.DeleteWorkOrder(getWorkOrderDetailsStatusCM);
            }

            return new DeleteWorkOrderResponseDto();
        }
    }
}
