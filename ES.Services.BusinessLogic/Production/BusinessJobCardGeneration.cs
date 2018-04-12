using ES.Services.BusinessLogic.Interface.Production;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.CommandModel.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.ReportLogic.Interface.Production;
using System;
using System.Collections.Generic;

namespace ES.Services.BusinessLogic.Production
{
    public class BusinessJobCardGeneration : IBusinessJobCardGeneration
    {
        private readonly IJobCardGenerationRepository jobCardGenerationRepository;

        public BusinessJobCardGeneration(IJobCardGenerationRepository jobCardGenerationRepository)
        {
            this.jobCardGenerationRepository = jobCardGenerationRepository;
        }

        public AddJobCardGenerationResponseDto AddJobCardGeneration(AddJobCardGenerationRequestDto addJobCardGenerationRequestDto)
        {
            AddJobCardGenerationResponseDto response = new AddJobCardGenerationResponseDto();
            AddJobCardMasterAndDetailsCM addJobCardMasterAndDetailsCM = new AddJobCardMasterAndDetailsCM();

            foreach (var request in addJobCardGenerationRequestDto.addJobCardGenerationRequestList)
            {
                GetProcessCardMasterQM getProcessCardMasterQM = new GetProcessCardMasterQM();
                GetProcessCardDetailsQM getProcessCardDetailsQM = new GetProcessCardDetailsQM();

                AddJobCardMasterCM addJobCardMasterCM = new AddJobCardMasterCM();
                AddJobCardDetailsCM addJobCardDetailsCM = new AddJobCardDetailsCM();

                var addJobCardMasterList = new List<AddJobCardMasterCM>();
                var addJobCardDetailsList = new List<AddJobCardDetailsCM>();                

                #region Process Card Master and Details Information
                getProcessCardMasterQM = jobCardGenerationRepository.GetProcessCardMaster(request.PartCode, request.SequenceNumber);

                getProcessCardDetailsQM = jobCardGenerationRepository.GetProcessCardDetails(request.PartCode, request.SequenceNumber);

                #endregion

                #region Save JobCard Master and Details

                foreach (var processCardMaster in getProcessCardMasterQM.GetProcessCardMasterModelList)
                {
                    addJobCardMasterCM = new AddJobCardMasterCM()
                    {
                        SerialNo = "SQD1",
                        JobCardDate = System.DateTime.UtcNow,
                        PartCode = processCardMaster.PartCode,
                        SequenceNumber = processCardMaster.SequenceNumber,
                        MachineCode = processCardMaster.MachineCode,
                        JigCode = processCardMaster.JigCode,
                        SettingTime = processCardMaster.SettingTime,
                        RunningTime = processCardMaster.RunningTime,
                        CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                        CreatedDateTime = System.DateTime.UtcNow
                    };
                }

                addJobCardMasterList.Add(addJobCardMasterCM);

                foreach (var processCardDetails in getProcessCardDetailsQM.GetProcessCardDetailsQMModelList)
                {
                    addJobCardDetailsCM = new AddJobCardDetailsCM()
                    {
                        SerialNo = "SQD1",
                        PartCode = processCardDetails.PartCode,
                        SequenceNumber = processCardDetails.SequenceNumber,
                        Serial = processCardDetails.Serial,
                        Description = processCardDetails.Description,
                        DimensionMin = processCardDetails.DimensionMin,
                        DimensionMax = processCardDetails.DimensionMax,
                        ParameterCode = processCardDetails.ParameterCode,
                        InstrumentCode = processCardDetails.InstrumentCode,
                        ToolCode = processCardDetails.ToolCode,
                        DRFlag = processCardDetails.DRFlag,
                        Symbol = processCardDetails.Symbol,
                        Datum = processCardDetails.Datum,
                        DatumDimension = processCardDetails.DatumDimension,
                        BooleanNumber = processCardDetails.BooleanNumber,
                        CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                        CreatedDateTime = System.DateTime.UtcNow
                    };

                    addJobCardDetailsList.Add(addJobCardDetailsCM);
                }

                addJobCardMasterAndDetailsCM = new AddJobCardMasterAndDetailsCM()
                {
                    AddJobCardMasterCMList = addJobCardMasterList,
                    AddJobCardDetailsCMList = addJobCardDetailsList
                };

                jobCardGenerationRepository.AddJobCardMasterAndDetails(addJobCardMasterAndDetailsCM);

                #endregion

            }

            return response;
        }
    }
}
