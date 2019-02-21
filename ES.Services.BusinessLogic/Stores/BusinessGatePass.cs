using ES.ExceptionAttributes;
using ES.Services.BusinessLogic.Interface.Stores;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Stores
{
    public class BusinessGatePass : IBusinessGatePass
    {
        private readonly IGatePassRepository gatePassRepository;

        public BusinessGatePass(IGatePassRepository gatePassRepository)
        {
            this.gatePassRepository = gatePassRepository;
        }

        public GPSendingResponseDto SaveGPSendingDetails(GPSendingRequestDto GPSendingRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            GPSendingResponseDto GPSendingResponseDto = new GPSendingResponseDto();

            #region Section To Save GPMaster

            gatePassRepository.SaveGPSendingMaster(GPSendingRequestDto.GPType, GPSendingRequestDto.GPNumber, GPSendingRequestDto.VendorCode, GPSendingRequestDto.GPDate,
                GPSendingRequestDto.RequestedBy, GPSendingRequestDto.Remarks);

            #endregion

            #region Section To Save GP Details

            foreach (var gpSendingDetails in GPSendingRequestDto.GPSendingDetailsList)
            {
                var GPSendingDetailsListCM = new List<GPSendingDetailsListCM>();

                var cModel = new GPSendingDetailsCM();
                var GPSendingDetail = new GPSendingDetailsListCM
                {
                    GPNumber = gpSendingDetails.GPNumber,
                    GPSerialNo = gpSendingDetails.GPSerialNo,
                    Description = gpSendingDetails.Description,
                    Units = gpSendingDetails.Units,
                    ReceivedQuantity = gpSendingDetails.ReceivedQuantity,
                    SentQuantity = gpSendingDetails.SentQuantity,
                    CreatedBy = createdBy,
                    CreatedDateTime = DateTime.Now
                };

                GPSendingDetailsListCM.Add(GPSendingDetail);

                cModel.GPSendingDetailsListItemsCM = GPSendingDetailsListCM;

                // Section to add the gp sending master details information
                gatePassRepository.SaveGPSendingDetails(cModel);
            }

            #endregion

            return GPSendingResponseDto;
        }

        public DeleteGPSendingResponseDto DeleteGPSendingMasterAndDetails(DeleteGPSendingRequestDto deleteGPSendingRequestDto)
        {
            DeleteGPSendingResponseDto response = new DeleteGPSendingResponseDto();

            var deleteGPSendingDetailsItems = new List<DeleteGPSendingDetailsCM>();

            var deleteGPSendingCM = new DeleteGPSendingCM();
            foreach (var dcItems in deleteGPSendingRequestDto.DeleteGPSendingDetails)
            {
                var deleteDcDetails = new DeleteGPSendingDetailsCM
                {
                    GPNumber = dcItems.GPNumber,
                    GPSerialNo = dcItems.GPSerialNo,
                    UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                    UpdatedDateTime = System.DateTime.UtcNow
                };

                deleteGPSendingDetailsItems.Add(deleteDcDetails);
            }

            deleteGPSendingCM.GPNumber = deleteGPSendingRequestDto.GPNumber;
            deleteGPSendingCM.IsDeleteFrom = deleteGPSendingRequestDto.IsDeleteFrom;
            deleteGPSendingCM.DeleteGPSendingDetailsCM = deleteGPSendingDetailsItems;

            gatePassRepository.DeleteGPSendingMasterAndDetails(deleteGPSendingCM);

            return response;
        }

        public GPReceivingResponseDto SaveGPReceivingtDetails(GPReceivingRequestDto GPReceivingRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            GPReceivingResponseDto GPReceivingResponseDto = new GPReceivingResponseDto();

            #region Section To Save GP Receiving Master

            gatePassRepository.SaveGPReceivingMaster(GPReceivingRequestDto.GPReceiptNumber, GPReceivingRequestDto.GPReceiptDate, GPReceivingRequestDto.VendorCode,
                GPReceivingRequestDto.DocumentID, GPReceivingRequestDto.DocumentDate, GPReceivingRequestDto.Remarks);

            #endregion

            #region Section To Save GP Receiving Details

            foreach (var gpReceivingDetails in GPReceivingRequestDto.GPReceivingDetails)
            {
                var GPReceivingDetailsListCM = new List<GPReceivingDetailsListCM>();

                var cModel = new GPReceivingDetailsCM();
                var GPReceivingDetail = new GPReceivingDetailsListCM
                {
                    GPReceiptNumber = gpReceivingDetails.GPReceiptNumber,
                    GPNumber = gpReceivingDetails.GPNumber,
                    GPSerialNo = gpReceivingDetails.GPSerialNo,
                    ReceivedQuantity = gpReceivingDetails.ReceiptQuantity,
                    CreatedBy = createdBy,
                    CreatedDateTime = DateTime.Now
                };

                GPReceivingDetailsListCM.Add(GPReceivingDetail);

                cModel.GPReceivingDetailsListItemsCM = GPReceivingDetailsListCM;

                // Section to add the gp sending master details information
                gatePassRepository.SaveGPReceivingDetails(cModel);
            }

            #endregion

            return GPReceivingResponseDto;
        }
    }
}
