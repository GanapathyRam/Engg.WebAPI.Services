using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportSubcontractProcessMaster : IReportSubcontractProcessMaster
    {
        private readonly ISubcontractProcessMasterRepository subcontractProcessMasterRepository;

        public ReportSubcontractProcessMaster(ISubcontractProcessMasterRepository subcontractProcessMasterRepository)
        {
            this.subcontractProcessMasterRepository = subcontractProcessMasterRepository;
        }
        public GetSubcontractProcessMasterResponseDto GetSubcontractProcessMaster()
        {
            var response = new GetSubcontractProcessMasterResponseDto();

            var cModel = new GetSubcontractProcessMasterCM()
            {
                //PageIndex = getParameterMasterRequestDto.PageIndex,
                //PageSize = getParameterMasterRequestDto.PageSize,
                //ParameterCode = getParameterMasterRequestDto.ParameterCode
            };
            var model = subcontractProcessMasterRepository.GetSubcontractProcessMaster();
            if (model != null && model.GetSubcontractProcessMasterList.Any())
            {
                response = SubcontractProcessMasterMapper((List<SubcontractProcessMasterModel>)model.GetSubcontractProcessMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }


        private static GetSubcontractProcessMasterResponseDto SubcontractProcessMasterMapper(List<SubcontractProcessMasterModel> list, GetSubcontractProcessMasterResponseDto getSubcontractProcessMasterResponseDto)
        {
            Mapper.CreateMap<SubcontractProcessMasterModel, SubcontractProcessMaster>();
            getSubcontractProcessMasterResponseDto.GetSubcontractProcessMasterList =
                Mapper.Map<List<SubcontractProcessMasterModel>, List<SubcontractProcessMaster>>(list);

            return getSubcontractProcessMasterResponseDto;
        }
    }
}
