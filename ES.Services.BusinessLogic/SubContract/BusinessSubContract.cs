using ES.Services.BusinessLogic.Interface.SubContract;
using ES.Services.DataAccess.Interface.SubContract;
using ES.Services.DataAccess.Model.CommandModel.SubContract;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.SubContract
{
    public class BusinessSubContract : IBusinessSubContract
    {
        private readonly ISubContractRepository subContractRepository;

        public BusinessSubContract(ISubContractRepository subContractRepository)
        {
            this.subContractRepository = subContractRepository;
        }

        public SubContractResponseDto AddSubContractSending(SubContractRequestDto subContractRequestDto)
        {
            SubContractResponseDto response = new SubContractResponseDto();

            #region SubContract Master

            if (subContractRequestDto.IsNew == true)
            {
                subContractRepository.AddSubContractMasterDetails(subContractRequestDto.SubContractDcDate, subContractRequestDto.SubContractDcNumber, subContractRequestDto.SubContractSentFor,
                    subContractRequestDto.Vehicle, subContractRequestDto.VendorCode, subContractRequestDto.Remarks);
            }

            #endregion

            #region SubContract Details

            foreach (var ScDetails in subContractRequestDto.SubContractDetails)
            {
                var scDetailsList = new List<SubContractDetails>();
                var scDetailsSerial = new List<ScDetailSerialItems>();

                if (ScDetails.IsNew == true && ScDetails.SubContractDetailsSerial.Count() > 0)
                {
                    var scDetails = new SubContractDetails
                    {
                        PartCode = ScDetails.PartCode,
                        ProcessDescription = ScDetails.ProcessDescription,
                        SubContractDcNumber = ScDetails.SubContractDcNumber,
                        WoNumber = ScDetails.WoNumber,
                        WoSerial = ScDetails.WoSerial
                    };

                    subContractRepository.AddScDetails(scDetails.SubContractDcNumber, scDetails.WoNumber, scDetails.WoSerial, scDetails.PartCode);
                    //Insert
                    //scDetailsList.Add(ScDetails);
                }
                else if (ScDetails.IsNew == false && ScDetails.SubContractDetailsSerial.Count > 0)
                {
                    //subContractRepository.UpdateScDetails(ScDetails.SubContractDcNumber, ScDetails.WoNumber, ScDetails.WoSerial, ScDetails.PartCode);
                }

                #endregion

            #region SubContract Detail Serial

                var scDetailSerialCM = new ScDetailSerialCM();
                foreach (var scDetailSerialItems in ScDetails.SubContractDetailsSerial)
                {
                    if (scDetailSerialItems.IsNew == true)
                    {
                        var scDetailSerial = new ScDetailSerialItems
                        {
                            WoNumber = scDetailSerialItems.WoNumber,
                            ScNumber = scDetailSerialItems.SubContractDcNumber,
                            SerialNo = scDetailSerialItems.SerialNo,
                            WoSerial = ScDetails.WoSerial,
                            CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                            CreatedDateTime = System.DateTime.UtcNow
                        };

                        scDetailsSerial.Add(scDetailSerial);
                    }
                }

                scDetailSerialCM.ScDetailSerialItems = scDetailsSerial;
                subContractRepository.AddScSerial(scDetailSerialCM);

            }

            #endregion

            return response;
        }

        public DeleteScSendingResponseDto DeleteScSendingDetails(DeleteScSendingRequestDto deleteScSendingRequestDto)
        {
            DeleteScSendingResponseDto response = new DeleteScSendingResponseDto();
            var deleteDcDetailsItems = new List<DeleteScDetailsItems>();

            var deleteScResponse = new DeleteScDetailsCM();
            foreach (var dcItems in deleteScSendingRequestDto.ScSendingDetailsList)
            {
                var deleteDcDetails = new DeleteScDetailsItems
                {
                    WoNumber = dcItems.WoNumber,
                    SerialNo = dcItems.SerialNo,
                    WoSerial = dcItems.WoSerial,
                    UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                    UpdatedDateTime = System.DateTime.UtcNow
                };

                deleteDcDetailsItems.Add(deleteDcDetails);
            }

            deleteScResponse.ScNumer = deleteScSendingRequestDto.ScDcNumer;
            deleteScResponse.WoNumber = deleteScSendingRequestDto.WoNumber;
            deleteScResponse.IsDeleteFrom = deleteScSendingRequestDto.IsDeleteFrom;
            deleteScResponse.scDetailsListItems = deleteDcDetailsItems;

            subContractRepository.DeleteScSendingDetails(deleteScResponse);

            return response;
        }


        public SubContractReceivingResponseDto AddSubContractReceiving(SubContractReceivingRequestDto subContractReceivingRequestDto)
        {
            SubContractReceivingResponseDto response = new SubContractReceivingResponseDto();

            #region SubContract Master

            if (subContractReceivingRequestDto.IsNew == true)
            {
                subContractRepository.AddSubContractReceiveMasterDetails(subContractReceivingRequestDto.ScReceivingDcDate, subContractReceivingRequestDto.ScReceivingDcNumber,
                    subContractReceivingRequestDto.VendorCode, subContractReceivingRequestDto.VendorDCNumber, subContractReceivingRequestDto.ScReceivingVendorDate, subContractReceivingRequestDto.Vehicle, subContractReceivingRequestDto.Remarks);
            }

            #endregion

            #region SubContract Details

            foreach (var ScDetails in subContractReceivingRequestDto.SubContractReceivingDetails)
            {
                var scReceivingDetailsList = new List<SubContractReceivingDetails>();
                var scReceivingDetailsSerial = new List<ScReceivingDetailSerialItems>();

                if (ScDetails.IsNew == true && ScDetails.SubContractReceivingDetailsSerial.Count() > 0)
                {
                    var subContractReceivingDetails = new SubContractReceivingDetails
                    {
                        PartCode = ScDetails.PartCode,
                        ProcessDescription = ScDetails.ProcessDescription,
                        ScReceivingDcNumber = ScDetails.ScReceivingDcNumber,
                        WoNumber = ScDetails.WoNumber,
                        WoSerial = ScDetails.WoSerial
                    };

                    subContractRepository.AddScReceivingDetails(subContractReceivingDetails.ScReceivingDcNumber, subContractReceivingDetails.WoNumber, subContractReceivingDetails.WoSerial, subContractReceivingDetails.PartCode);
                    //Insert
                    //scDetailsList.Add(ScDetails);
                }
                else if (ScDetails.IsNew == false && ScDetails.SubContractReceivingDetailsSerial.Count > 0)
                {
                }

                #endregion

                #region SubContract Detail Serial

                var scReceivingDetailSerialCM = new ScReceivingDetailSerialCM();
                foreach (var scDetailSerialItems in ScDetails.SubContractReceivingDetailsSerial)
                {
                    if (scDetailSerialItems.IsNew == true)
                    {
                        var scReceivingDetailSerialItems = new ScReceivingDetailSerialItems
                        {
                            WoNumber = scDetailSerialItems.WoNumber,
                            ScReceivingNumber = scDetailSerialItems.ScReceivingDcNumber,
                            SerialNo = scDetailSerialItems.SerialNo,
                            WoSerial = ScDetails.WoSerial,
                            CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                            CreatedDateTime = System.DateTime.UtcNow
                        };

                        scReceivingDetailsSerial.Add(scReceivingDetailSerialItems);
                    }
                }

                scReceivingDetailSerialCM.ScReceivingDetailSerialItems = scReceivingDetailsSerial;
                subContractRepository.AddScReceivingSerial(scReceivingDetailSerialCM);

            }

            #endregion

            return response;
        }
    }
}
