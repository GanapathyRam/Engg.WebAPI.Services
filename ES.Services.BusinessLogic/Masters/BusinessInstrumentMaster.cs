using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessInstrumentMaster : IBusinessInstrumentMaster
    {
        private readonly IInstrumentMasterRepository instrumentMastersRepository;

        public BusinessInstrumentMaster(IInstrumentMasterRepository instrumentMastersRepository)
        {
            this.instrumentMastersRepository = instrumentMastersRepository;
        }

        public AddInstrumentMasterResponseDto AddInstrumentMaster(AddInstrumentMasterRequestDto addInstrumentMasterRequestDto)
        {
            var cModel = new AddInstrumentMasterCM()
            {
                InstrumentName = addInstrumentMasterRequestDto.InstrumentName,
                AddedDate = addInstrumentMasterRequestDto.AddedDate,
                Make = addInstrumentMasterRequestDto.Make,
                Range = addInstrumentMasterRequestDto.Range,
                Accuracy = addInstrumentMasterRequestDto.Accuracy,
                Serial = addInstrumentMasterRequestDto.Serial,
                CalibratedDate = addInstrumentMasterRequestDto.CalibratedDate,
                Frequency = addInstrumentMasterRequestDto.Frequency,
                CalibrationDueDate = addInstrumentMasterRequestDto.CalibrationDueDate,
                VendorCode = addInstrumentMasterRequestDto.VendorCode                
            };

            var response = instrumentMastersRepository.AddInstrumentMaster(cModel);

            return new AddInstrumentMasterResponseDto();
        }

        public UpdateInstrumentMasterResponseDto UpdateInstrumentMaster(UpdateInstrumentMasterRequestDto updateInstrumentMasterRequestDto)
        {
            var cModel = new UpdateInstrumentMasterCM()
            {
                InstrumentName = updateInstrumentMasterRequestDto.InstrumentName,
                AddedDate = updateInstrumentMasterRequestDto.AddedDate,
                Make = updateInstrumentMasterRequestDto.Make,
                Range = updateInstrumentMasterRequestDto.Range,
                Accuracy = updateInstrumentMasterRequestDto.Accuracy,
                Serial = updateInstrumentMasterRequestDto.Serial,
                CalibratedDate = updateInstrumentMasterRequestDto.CalibratedDate,
                Frequency = updateInstrumentMasterRequestDto.Frequency,
                CalibrationDueDate = updateInstrumentMasterRequestDto.CalibrationDueDate,
                VendorCode = updateInstrumentMasterRequestDto.VendorCode,
                InstrumentCode = updateInstrumentMasterRequestDto.InstrumentCode
            };

            var response = instrumentMastersRepository.UpdateInstrumentMaster(cModel);

            return new UpdateInstrumentMasterResponseDto();
        }
    }
}
