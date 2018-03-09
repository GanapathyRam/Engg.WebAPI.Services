using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using AutoMapper;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportParameterMaster : IReportParameterMaster
    {
        private readonly IParameterMasterRepository parameterMastersRepository;

        public ReportParameterMaster(IParameterMasterRepository parameterMastersRepository)
        {
            this.parameterMastersRepository = parameterMastersRepository;
        }

        public GetParameterMasterResponseDto GetParameterMaster()
        {
            var response = new GetParameterMasterResponseDto();

            var cModel = new GetParameterMasterCM()
            {
                //PageIndex = getParameterMasterRequestDto.PageIndex,
                //PageSize = getParameterMasterRequestDto.PageSize,
                //ParameterCode = getParameterMasterRequestDto.ParameterCode
            };

            var model = parameterMastersRepository.GetParameterMaster();

            if (model != null && model.GetParameterMasterList.Any())
            {
                response = OperationMasterMapper((List<ParameterMasterModel>)model.GetParameterMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetParameterMasterResponseDto OperationMasterMapper(List<ParameterMasterModel> list, GetParameterMasterResponseDto getParameterMasterResponseDto)
        {
            Mapper.CreateMap<ParameterMasterModel, ParameterMaster>();
            getParameterMasterResponseDto.ParameterMasterList =
                Mapper.Map<List<ParameterMasterModel>, List<ParameterMaster>>(list);

            return getParameterMasterResponseDto;
        }
    }
}
