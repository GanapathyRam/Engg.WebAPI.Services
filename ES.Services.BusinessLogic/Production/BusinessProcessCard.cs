using ES.Services.BusinessLogic.Interface.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.CommandModel.Production;

namespace ES.Services.BusinessLogic.Production
{
    public class BusinessProcessCard : IBusinessProcessCard
    {

        private readonly IProcessCardRepository processCardRepository;

        public BusinessProcessCard(IProcessCardRepository processCardRepository)
        {
            this.processCardRepository = processCardRepository;
        }

        public AddProcessCardResponseDto AddProcessCard(AddProcessCardRequestDto addProcessCardRequestDto)
        {
            AddProcessCardResponseDto response = new AddProcessCardResponseDto();
            AddProcessCardCM addProcessCardCM = new AddProcessCardCM();
            UpdateProcessCardCM updateProcessCardCM = new UpdateProcessCardCM();

            var addProcessCardDetailsCmModel = new List<ProcessCardDetailsCmModel>();
            var updateProcessCardDetailsCmModelList = new List<UpdateProcessCardDetailsCmModel>();


            var processCardMasterCmModel = new ProcessCardMasterCmModel();
            var processCardDetailsCmModel = new ProcessCardDetailsCmModel();

            var updateProcessCardMasterCmModel = new UpdateProcessCardMasterCmModel();
            var updateProcessCardDetailsCmModel = new UpdateProcessCardDetailsCmModel();

            processCardMasterCmModel = new ProcessCardMasterCmModel
            {
                PartCode = addProcessCardRequestDto.PartCode,
                SequenceNumber = addProcessCardRequestDto.SequenceNumber,
                MachineCode = addProcessCardRequestDto.MachineCode,
                JigCode = addProcessCardRequestDto.JigCode,
                SettingTime = addProcessCardRequestDto.SettingTime,
                RunningTime = addProcessCardRequestDto.RunningTime
            };


            //addProcessCardMasterCmModel.Add(processCardMasterCmModel);

            foreach (var processCardDetails in addProcessCardRequestDto.ListProcessCardDetails.Where(x => x.IsNew == true))
            {
                processCardDetailsCmModel = new ProcessCardDetailsCmModel
                {
                    PartCode = processCardDetails.PartCode,
                    SequenceNumber = processCardDetails.SequenceNumber,
                    SerialNo = processCardDetails.SerialNo,
                    Description = processCardDetails.Description,
                    DimensionMax = processCardDetails.DimensionMax,
                    DimensionMin = processCardDetails.DimensionMin,
                    ParameterCode = processCardDetails.ParameterCode,
                    InstrumentCode = processCardDetails.InstrumentCode,
                    ToolCode = processCardDetails.ToolCode,
                    DRFlag = processCardDetails.DRFlag,
                    Symbol = processCardDetails.Symbol,
                    Datum = processCardDetails.Datum,
                    DatumDimension = processCardDetails.DatumDimension,
                    BooleanNumber = processCardDetails.BooleanNumber
                };

                addProcessCardDetailsCmModel.Add(processCardDetailsCmModel);
            }

            if (addProcessCardDetailsCmModel != null && addProcessCardDetailsCmModel.ToList().Count > 0)
            {
                addProcessCardCM = new AddProcessCardCM()
                {
                    //ListProcessCardMaster = addProcessCardMasterCmModel,
                    IsNew = addProcessCardRequestDto.IsNew,
                    PartCode = processCardMasterCmModel.PartCode,
                    SequenceNumber = processCardMasterCmModel.SequenceNumber,
                    MachineCode = processCardMasterCmModel.MachineCode,
                    JigCode = processCardMasterCmModel.JigCode,
                    SettingTime = processCardMasterCmModel.SettingTime,
                    RunningTime = processCardMasterCmModel.RunningTime,
                    ListProcessCardDetails = addProcessCardDetailsCmModel
                };

                processCardRepository.AddProcessCard(addProcessCardCM);

            }

            foreach (var processCardDetails in addProcessCardRequestDto.ListProcessCardDetails.Where(x => x.IsNew == false))
            {
                updateProcessCardDetailsCmModel = new UpdateProcessCardDetailsCmModel
                {
                    PartCode = processCardDetails.PartCode,
                    SequenceNumber = processCardDetails.SequenceNumber,
                    SerialNo = processCardDetails.SerialNo,
                    Description = processCardDetails.Description,
                    DimensionMax = processCardDetails.DimensionMax,
                    DimensionMin = processCardDetails.DimensionMin,
                    ParameterCode = processCardDetails.ParameterCode,
                    InstrumentCode = processCardDetails.InstrumentCode,
                    ToolCode = processCardDetails.ToolCode,
                    DRFlag = processCardDetails.DRFlag,
                    Symbol = processCardDetails.Symbol,
                    Datum = processCardDetails.Datum,
                    DatumDimension = processCardDetails.DatumDimension,
                    BooleanNumber = processCardDetails.BooleanNumber
                };

                updateProcessCardDetailsCmModelList.Add(updateProcessCardDetailsCmModel);
            };

            if (updateProcessCardDetailsCmModelList != null && updateProcessCardDetailsCmModelList.ToList().Count > 0)
            {
                updateProcessCardCM = new UpdateProcessCardCM()
                {
                    //ListProcessCardMaster = addProcessCardMasterCmModel,
                    PartCode = processCardMasterCmModel.PartCode,
                    SequenceNumber = processCardMasterCmModel.SequenceNumber,
                    MachineCode = processCardMasterCmModel.MachineCode,
                    JigCode = processCardMasterCmModel.JigCode,
                    SettingTime = processCardMasterCmModel.SettingTime,
                    RunningTime = processCardMasterCmModel.RunningTime,
                    ListUpdateProcessCardDetails = updateProcessCardDetailsCmModelList
                };

                processCardRepository.UpdateProcessCard(updateProcessCardCM);
            }

            return response;
        }
    }
}
