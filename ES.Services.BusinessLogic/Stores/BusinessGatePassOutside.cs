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
    public class BusinessGatePassOutside : IBusinessGatePassOutside
    {
        private readonly IGatePassOutsideRepository gatePassOutsideRepository;

        public BusinessGatePassOutside(IGatePassOutsideRepository gatePassOutsideRepository)
        {
            this.gatePassOutsideRepository = gatePassOutsideRepository;
        }
        public DeleteGPOutsideReceiptResponseDto DeletPOutsideReceiptMasterAndDetails(DeleteGPOutsideReceiptRequestDto deleteGPOutsideReceiptRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            DeleteGPOutsideReceiptResponseDto response = new DeleteGPOutsideReceiptResponseDto();

            var deleteGPSendingDetailsItems = new List<DeleteGPOutsideReceiptDetailsCM>();

            var deleteGPSendingCM = new DeleteGPOutsideReceiptCM();
            foreach (var dcItems in deleteGPOutsideReceiptRequestDto.DeleteGPOutsideReceiptDetailList)
            {
                var deleteDcDetails = new DeleteGPOutsideReceiptDetailsCM
                {
                    GPOutsideReceiptNumber = dcItems.GPOutsideReceiptNumber,
                    GPOutsideSerialNo = dcItems.GPOutsideSerialNo,
                    UpdatedBy = createdBy, //Later needs to be remove
                    UpdatedDateTime = System.DateTime.UtcNow
                };

                deleteGPSendingDetailsItems.Add(deleteDcDetails);
            }

            deleteGPSendingCM.GPOutsideReceiptNumber = deleteGPOutsideReceiptRequestDto.GPOutsideReceiptNumber;
            deleteGPSendingCM.IsDeleteFrom = deleteGPOutsideReceiptRequestDto.IsDeleteFrom;
            deleteGPSendingCM.DeleteGPOutsideReceiptDetailList = deleteGPSendingDetailsItems;

            gatePassOutsideRepository.DeleteGPOutsideReceiptMasterAndDetails(deleteGPSendingCM);

            return response;
        }

        public GPOutsideReceiptResponseDto SaveGPOutsideReceipt(GPOutsideReceiptRequestDto gPOutsideReceiptRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            GPOutsideReceiptResponseDto GPSendingResponseDto = new GPOutsideReceiptResponseDto();

            #region Section To Save GP Outside Receiving Master
            GPOutsideMasterCM masterSave = new GPOutsideMasterCM()
            {
                VendorCode = gPOutsideReceiptRequestDto.VendorCode,
                GPOutsideReceiptNumber = gPOutsideReceiptRequestDto.GPOutsideReceiptNumber,
                GPOutsideReceiptDate = gPOutsideReceiptRequestDto.GPOutsideReceiptDate,
                GPOutsideType = gPOutsideReceiptRequestDto.GPOutsideType,
                RecievedBy = gPOutsideReceiptRequestDto.RecievedBy,
                Remarks = gPOutsideReceiptRequestDto.Remarks,
                CreatedBy = createdBy,
                CreatedDateTime = DateTime.Now

            };
            gatePassOutsideRepository.SaveGPOutsideReceiptMaster(masterSave);

            #endregion


            #region Section To Save GP Receiving Details

            foreach (var gpReceivingDetails in gPOutsideReceiptRequestDto.GPOutsideReceiptDetailsList)
            {
                var GPReceivingDetailsListCM = new List<GPOutsideReceiptDetailsModel>();

                var cModel = new GPOutsideReceiptDetailsCM();
                var GPReceivingDetail = new GPOutsideReceiptDetailsModel
                {
                    GPOutsideReceiptNumber = gpReceivingDetails.GPOutsideReceiptNumber,
                    GPOutsideSerialNo = gpReceivingDetails.GPOutsideSerialNo,
                    ReceivedQuantity = gpReceivingDetails.ReceivedQuantity,
                    SentQuantity = gpReceivingDetails.SentQuantity,
                    Units = gpReceivingDetails.Units,
                    Description = gpReceivingDetails.Description,
                    CreatedBy = createdBy,
                    CreatedDateTime = DateTime.Now
                };

                GPReceivingDetailsListCM.Add(GPReceivingDetail);

                cModel.GPOutsideReceiptDetailsList = GPReceivingDetailsListCM;

                // Section to add the gp sending master details information
                gatePassOutsideRepository.SaveGPOutsideReceiptDetails(cModel);
            }

            #endregion


            return GPSendingResponseDto;
        }

        public GetGPOutsideReturnResponseDto SaveGPOutsideReturn(GPOutsideReturnRequestDto gpOutsideReturnRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            GetGPOutsideReturnResponseDto GPOutsideReturnResponseDto = new GetGPOutsideReturnResponseDto();
            #region Section To Save GP Outside Return Master
            GPOutsideReturnMasterCM masterSave = new GPOutsideReturnMasterCM()
            {
                VendorCode = gpOutsideReturnRequestDto.VendorCode,
                GPOutsideReturnNumber = gpOutsideReturnRequestDto.GPOutsideReturnNumber,
                GPOutsideReturnDate = gpOutsideReturnRequestDto.GPOutsideReturnDate,
                Remarks = gpOutsideReturnRequestDto.Remarks,
                CreatedBy = createdBy,
                CreatedDateTime = DateTime.Now

            };
            gatePassOutsideRepository.SaveGPOutsideReturnMaster(masterSave);

            #endregion


            #region Section To Save GP Return Details

            foreach (var gpReceivingDetails in gpOutsideReturnRequestDto.GPOutsideReturnDetailsList)
            {
                var GPReceivingDetailsListCM = new List<GPOutsideReturnDetailsModel>();

                var cModel = new GPOutsideReturnDetailsCM();
                var GPReceivingDetail = new GPOutsideReturnDetailsModel
                {
                    GPOutsideReturnNumber= gpReceivingDetails.GPOutsideReturnNumber,
                    GPOutsideReceiptNumber = gpReceivingDetails.GPOutsideReceiptNumber,
                    GPOutsideSerialNo = gpReceivingDetails.GPOutsideSerialNo,
                    SentQuantity = gpReceivingDetails.SentQuantity,
                    CreatedBy = createdBy,
                    CreatedDateTime = DateTime.Now
                };

                GPReceivingDetailsListCM.Add(GPReceivingDetail);

                cModel.GPOutsideReturnDetailsList = GPReceivingDetailsListCM;

                // Section to add the gp sending master details information
                gatePassOutsideRepository.SaveGPOutsideReturnDetails(cModel);
            }

            #endregion


            return GPOutsideReturnResponseDto;
        }
    }
}
