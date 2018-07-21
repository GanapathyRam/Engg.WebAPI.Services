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
                //subContractRepository.AddSubContractMasterDetails(subContractRequestDto.SubContractDcDate, subContractRequestDto.SubContractDcNumber, subContractRequestDto.SubContractSentFor,
                //    subContractRequestDto.Vehicle, subContractRequestDto.VendorCode, subContractRequestDto.Remarks);
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
    }
}
