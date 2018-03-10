using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Response;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using AutoMapper;
using ES.Services.DataTransferObjects.Response.Masters;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportSymbolMaster : IReportSymbolMaster
    {
        private readonly ISymbolMasterRepository symbolMasterRepository;

        public ReportSymbolMaster(ISymbolMasterRepository symbolMastersRepository)
        {
            this.symbolMasterRepository = symbolMastersRepository;
        }

        public GetSymbolMasterResponseDto GetSymbolMaster()
        {
            var response = new GetSymbolMasterResponseDto();

            var cModel = new GetSymbolMasterCM()
            {
                //PageIndex = getParameterMasterRequestDto.PageIndex,
                //PageSize = getParameterMasterRequestDto.PageSize,
                //ParameterCode = getParameterMasterRequestDto.ParameterCode
            };

            var model = symbolMasterRepository.GetSymbolMaster();

            if (model != null && model.GetSymbolMasterList.Any())
            {
                response = OperationMasterMapper((List<SymbolMasterModel>)model.GetSymbolMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetSymbolMasterResponseDto OperationMasterMapper(List<SymbolMasterModel> list, GetSymbolMasterResponseDto getSymbolMasterResponseDto)
        {
            Mapper.CreateMap<SymbolMasterModel, SymbolMaster>();
            getSymbolMasterResponseDto.SymbolMasterList =
                Mapper.Map<List<SymbolMasterModel>, List<SymbolMaster>>(list);

            return getSymbolMasterResponseDto;
        }

      
    }
}
