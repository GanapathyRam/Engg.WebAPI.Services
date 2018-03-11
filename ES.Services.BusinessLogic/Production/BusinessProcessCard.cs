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

            var addProcessCardMasterCmModel = new List<ProcessCardMasterCmModel>();
            var addProcessCardDetailsCmModel = new List<ProcessCardDetailsCmModel>();

            var processCardMasterCmModel = new ProcessCardMasterCmModel();
            var processCardDetailsCmModel = new ProcessCardDetailsCmModel();

            foreach (var processCardMaster in addProcessCardRequestDto.ListProcessCardMaster)
            {
                processCardMasterCmModel = new ProcessCardMasterCmModel
                {
                    PartCode = processCardMaster.PartCode,
                    MachineCode = processCardMaster.MachineCode,
                    JigCode = processCardMaster.JigCode,
                    SettingTime = processCardMaster.SettingTime,
                    RunningTime = processCardMaster.RunningTime
                };

                addProcessCardMasterCmModel.Add(processCardMasterCmModel);

                foreach (var processCardDetails in addProcessCardRequestDto.ListProcessCardDetails)
                {
                    processCardDetailsCmModel = new ProcessCardDetailsCmModel
                    {
                        PartCode = processCardDetails.PartCode,
                        //SequenceNumber = processCardDetails.SequenceNumber,
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

                addProcessCardCM = new AddProcessCardCM()
                {
                    ListProcessCardMaster = addProcessCardMasterCmModel,
                    ListProcessCardDetails = addProcessCardDetailsCmModel
                };

                processCardRepository.AddProcessCard(addProcessCardCM);
            }

            return response;
        }
    }
}
