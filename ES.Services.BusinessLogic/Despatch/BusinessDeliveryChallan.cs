using ES.Services.BusinessLogic.Interface.Despatch;
using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Despatch
{
    public class BusinessDeliveryChallan : IBusinessDeliveryChallan
    {
        private readonly IDeliveryChallanRepository deliveryChallanRepository;

        public BusinessDeliveryChallan(IDeliveryChallanRepository deliveryChallanRepository)
        {
            this.deliveryChallanRepository = deliveryChallanRepository;
        }

        public DeliveryChallanResponseDto AddDeliveryChallan(DeliveryChallanRequestDto deliveryChallanRequestDto)
        {
            DeliveryChallanResponseDto response = new DeliveryChallanResponseDto();
            #region Save DC Master Details

            if (deliveryChallanRequestDto.IsNew == true)
            {
                deliveryChallanRepository.AddDcMasterDetails(deliveryChallanRequestDto.WorkOrderType, deliveryChallanRequestDto.DcDate, deliveryChallanRequestDto.DcNumber,
                    deliveryChallanRequestDto.VendorCode, deliveryChallanRequestDto.DcType, deliveryChallanRequestDto.VehicleNumber, deliveryChallanRequestDto.Billable);
            }
            #endregion

            #region Save DC Details

            foreach (var dcDetails in deliveryChallanRequestDto.DcDetails)
            {
                var DcDetailsList = new List<DcDetails>();
                var DcDetailSerialItems = new List<DcDetailSerialItems>();

                if (dcDetails.IsNew == true && dcDetails.DcDetailSerial.Count() > 0)
                {
                    var DcDetails = new DcDetails
                    {
                        DcNumber = dcDetails.DcNumber,
                        DcSerial = dcDetails.DcSerial,
                        PartCode = dcDetails.PartCode,
                        InvoivedTag = dcDetails.InvoivedTag,
                        Quantity = dcDetails.DcDetailSerial.Count(),
                        Remarks = dcDetails.Remarks,
                        WoNumber = dcDetails.WoNumber,
                        WoSerial = dcDetails.WoSerial
                    };

                    deliveryChallanRepository.AddDcDetails(DcDetails.DcNumber, DcDetails.WoNumber, DcDetails.DcSerial, DcDetails.PartCode, DcDetails.Quantity, DcDetails.Remarks, DcDetails.InvoivedTag, DcDetails.WoSerial);
                }
                else if (dcDetails.IsNew == false && dcDetails.DcDetailSerial.Count() > 0)
                {
                    deliveryChallanRepository.UpdateDcDetails(dcDetails.DcNumber, dcDetails.WoNumber, dcDetails.DcSerial, dcDetails.DcDetailSerial.Count(), dcDetails.WoSerial);
                }
                #endregion

            #region Save DC Serials

                var dcDetailSerialCM = new DcDetailSerialCM();
                foreach (var dcDetailSerialItems in dcDetails.DcDetailSerial)
                {
                    if (dcDetailSerialItems.IsNew == true)
                    {
                        var dcDetailSerial = new DcDetailSerialItems
                        {
                            DcNumber = dcDetailSerialItems.DcNumber,
                            WoNumber = dcDetailSerialItems.WoNumber,
                            DcSerial = dcDetailSerialItems.DcSerial,
                            SerialNo = dcDetailSerialItems.SerialNo,
                            WoSerial = dcDetails.WoSerial,
                            CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                            CreatedDateTime = System.DateTime.UtcNow
                        };

                        DcDetailSerialItems.Add(dcDetailSerial);
                    }
                }

                dcDetailSerialCM.DcDetailSerialItems = DcDetailSerialItems;
                deliveryChallanRepository.AddDcSerial(dcDetailSerialCM);

            }

            #endregion


            return response;
        }

        public DeleteDcResponseDto DeleteDcDetails(DeleteDcRequestDto deleteDcRequestDto)
        {
            DeleteDcResponseDto response = new DeleteDcResponseDto();
            var deleteDcDetailsItems = new List<DeleteDcDetailsItems>();

            var deleteDcResponse = new DeleteDcDetailsCM();
            foreach (var dcItems in deleteDcRequestDto.DcDetailsList)
            {
                var deleteDcDetails = new DeleteDcDetailsItems
                {
                    WoNumber = dcItems.WoNumber,
                    SerialNo = dcItems.SerialNo,
                    WoSerial = dcItems.WoSerial,
                    UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                    UpdatedDateTime = System.DateTime.UtcNow
                };

                deleteDcDetailsItems.Add(deleteDcDetails);
            }

            deleteDcResponse.DcNumer = deleteDcRequestDto.DcNumer;
            deleteDcResponse.WoNumber = deleteDcRequestDto.WoNumber;
            deleteDcResponse.IsDeleteFrom = deleteDcRequestDto.IsDeleteFrom;
            deleteDcResponse.dcDetailsListItems = deleteDcDetailsItems;

            deliveryChallanRepository.DeleteDcDetails(deleteDcResponse);

            return response;
        }
    }
}
