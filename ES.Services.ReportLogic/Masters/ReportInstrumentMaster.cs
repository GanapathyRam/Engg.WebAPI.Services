using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportInstrumentMaster : IReportInstrumentMaster
    {
        private readonly IInstrumentMasterRepository instrumentMastersRepository;

        public ReportInstrumentMaster(IInstrumentMasterRepository instrumentMastersRepository)
        {
            this.instrumentMastersRepository = instrumentMastersRepository;
        }

        public GetInstrumentMasterResponseDto GetInstrumentMaster()
        {
            var response = new GetInstrumentMasterResponseDto();

            var cModel = new GetInstrumentMasterCM()
            {
                //PageIndex = getInstrumentMasterRequestDto.PageIndex,
                //PageSize = getInstrumentMasterRequestDto.PageSize,
                //InstrumentCode = getInstrumentMasterRequestDto.InstrumentCode
            };

            var model = instrumentMastersRepository.GetInstrumentMaster();

            if (model != null && model.GetInstrumentMasterList.Any())
            {
                response = InstrumentMasterMapper((List<InstrumentMasterModel>)model.GetInstrumentMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetInstrumentMasterResponseDto InstrumentMasterMapper(List<InstrumentMasterModel> list, GetInstrumentMasterResponseDto response)
        {
            Mapper.CreateMap<InstrumentMasterModel, InstrumentMasterList>();
            response.InstrumentMasterList =
                Mapper.Map<List<InstrumentMasterModel>, List<InstrumentMasterList>>(list);

            return response;
        }
    }
}
