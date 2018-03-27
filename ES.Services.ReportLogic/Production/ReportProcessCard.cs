using ES.Services.DataAccess.Interface.Production;
using ES.Services.ReportLogic.Interface.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using AutoMapper;

namespace ES.Services.ReportLogic.Production
{
    public class ReportProcessCard : IReportProcessCard
    {
        private readonly IProcessCardRepository processCardRepository;

        public ReportProcessCard(IProcessCardRepository processCardRepository)
        {
            this.processCardRepository = processCardRepository;
        }

        public GetSequenceNumberResponseDto GetSequenceNumber(GetSequenceNumberRequestDto getSequenceNumberRequestDto)
        {
            GetSequenceNumberResponseDto response = new GetSequenceNumberResponseDto();

            var model = processCardRepository.GetSequenceNumber(getSequenceNumberRequestDto.PartCode);

            if (model != null)
            {
                response = GetSequnceNumberMapper((List<GetSequenceNumberModel>)model.SequenceNumberList, response);
            }

            return response;
        }

        public GetProcessCardResponseDto GetProcessCard()
        {
            var response = new GetProcessCardResponseDto()
            {
                GetProcessCardMasterResponse = new List<ProcessCardMasterResponse>()
            };
            var processCardMasterResponse = new ProcessCardMasterResponse();

            var model = processCardRepository.GetProcessCard();

            if (model != null)
            {
                processCardMasterResponse = GetProcessCardMapper((List<GetProcessCardQMModel>)model.GetProcessCardDetailsQMModel, processCardMasterResponse);
            }

            foreach (var processCardDetails in processCardMasterResponse.GetProcessCardDetailsResponse)
            {
                var getsingle = new ProcessCardMasterResponse
                {
                    GetProcessCardDetailsResponse = new List<ProcessCardDetailsResponse>()
                };

                var processCardDetailsItems = new ProcessCardDetailsResponse();
                processCardDetailsItems.PartCode = processCardDetails.PartCode;
                processCardDetailsItems.SequenceNumber = processCardDetails.SequenceNumber;
                processCardDetailsItems.SerialNo = processCardDetails.SerialNo;
                processCardDetailsItems.Description = processCardDetails.Description;
                processCardDetailsItems.DimensionMax = processCardDetails.DimensionMax;
                processCardDetailsItems.DimensionMin = processCardDetails.DimensionMin;
                processCardDetailsItems.ParameterCode = processCardDetails.ParameterCode;
                processCardDetailsItems.ParameterDescription = processCardDetails.ParameterDescription;
                processCardDetailsItems.InstrumentCode = processCardDetails.InstrumentCode;
                processCardDetailsItems.InstrumentName = processCardDetails.InstrumentName;
                processCardDetailsItems.ToolCode = processCardDetails.ToolCode;
                processCardDetailsItems.ToolDescription = processCardDetails.ToolDescription;
                processCardDetailsItems.DRFlag = processCardDetails.DRFlag;
                processCardDetailsItems.Symbol = processCardDetails.Symbol;
                processCardDetailsItems.Datum = processCardDetails.Datum;
                processCardDetailsItems.DatumDimension = processCardDetails.DatumDimension;
                processCardDetailsItems.BooleanNumber = processCardDetails.BooleanNumber;
                processCardDetailsItems.IsNew = false;
                
                if (response.GetProcessCardMasterResponse.Count > 0)
                {
                    var isExist = response.GetProcessCardMasterResponse.Any(sequenceNumber => sequenceNumber.SequenceNumber == processCardDetails.SequenceNumber && sequenceNumber.PartCode == processCardDetails.PartCode);
                    if (isExist)
                    {
                        var index = response.GetProcessCardMasterResponse.FindIndex(a => a.SequenceNumber == processCardDetails.SequenceNumber && a.PartCode == processCardDetails.PartCode);

                        response.GetProcessCardMasterResponse[index].GetProcessCardDetailsResponse.Add(processCardDetailsItems);
                    }
                    else
                    {
                        getsingle.PartCode = processCardDetails.PartCode;
                        getsingle.PartDescription = processCardDetails.PartDescription;
                        getsingle.SequenceNumber = processCardDetails.SequenceNumber;
                        getsingle.MachineCode = processCardDetails.MachineCode;
                        getsingle.JigCode = processCardDetails.JigCode;
                        getsingle.RunningTime = processCardDetails.RunningTime;
                        getsingle.SettingTime = processCardDetails.SettingTime;
                        getsingle.MachineDescription = processCardDetails.MachineDescription;
                        getsingle.JigDescription = processCardDetails.JigDescription;
                        getsingle.VendorCode = processCardDetails.VendorCode;
                        getsingle.VendorName = processCardDetails.VendorName;
                        getsingle.MaxSerial = processCardDetails.MaxSerial;
                        getsingle.IsNew = false;
                        getsingle.GetProcessCardDetailsResponse.Add(processCardDetailsItems);
                       
                        response.GetProcessCardMasterResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.PartCode = processCardDetails.PartCode;
                    getsingle.PartDescription = processCardDetails.PartDescription;
                    getsingle.SequenceNumber = processCardDetails.SequenceNumber;
                    getsingle.MachineCode = processCardDetails.MachineCode;
                    getsingle.JigCode = processCardDetails.JigCode;
                    getsingle.MachineDescription = processCardDetails.MachineDescription;
                    getsingle.JigDescription = processCardDetails.JigDescription;
                    getsingle.RunningTime = processCardDetails.RunningTime;
                    getsingle.SettingTime = processCardDetails.SettingTime;
                    getsingle.VendorCode = processCardDetails.VendorCode;
                    getsingle.VendorName = processCardDetails.VendorName;
                    getsingle.MaxSerial = processCardDetails.MaxSerial;
                    getsingle.IsNew = false;
                    getsingle.GetProcessCardDetailsResponse.Add(processCardDetailsItems);

                    response.GetProcessCardMasterResponse.Add(getsingle);
                }
            }

            return response;
        }


        #region Mapper Method
        private static GetSequenceNumberResponseDto GetSequnceNumberMapper(List<GetSequenceNumberModel> list, GetSequenceNumberResponseDto getSequenceNumberResponseDto)
        {
            Mapper.CreateMap<GetSequenceNumberModel, GetSequenceNumberResponseModel>();
            getSequenceNumberResponseDto.SequenceNumberList =
                Mapper.Map<List<GetSequenceNumberModel>, List<GetSequenceNumberResponseModel>>(list);

            return getSequenceNumberResponseDto;
        }

        private static ProcessCardMasterResponse GetProcessCardMapper(List<GetProcessCardQMModel> list, ProcessCardMasterResponse getProcessCardMasterResponse)
        {
            Mapper.CreateMap<GetProcessCardQMModel, ProcessCardDetailsResponse>();
            getProcessCardMasterResponse.GetProcessCardDetailsResponse =
                Mapper.Map<List<GetProcessCardQMModel>, List<ProcessCardDetailsResponse>>(list);

            return getProcessCardMasterResponse;
        }

        #endregion
    }
}
