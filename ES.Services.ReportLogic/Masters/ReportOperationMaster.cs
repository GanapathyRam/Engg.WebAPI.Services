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
    public class ReportOperationMaster : IReportOperationMaster
    {
        private readonly IOperationMasterRepository operationMastersRepository;

        public ReportOperationMaster(IOperationMasterRepository operationMastersRepository)
        {
            this.operationMastersRepository = operationMastersRepository;
        }
        

        public GetOperationMasterResponseDto GetOperationMaster()
        {
            var response = new GetOperationMasterResponseDto();

            var cModel = new GetOperationMasterCM
            {
                //PageIndex = getOperationMasterRequestDto.PageIndex,
                //PageSize = getOperationMasterRequestDto.PageSize,
                //OperationCode = getOperationMasterRequestDto.OperationCode
            };
            var model = operationMastersRepository.GetOperationMaster();

            if (model != null && model.GetOperationMasterList.Any())
            {
                response = OperationMasterMapper((List<OperationMasterModel>)model.GetOperationMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetOperationMasterResponseDto OperationMasterMapper(List<OperationMasterModel> list, GetOperationMasterResponseDto getOperationMasterResponseDto)
        {
            Mapper.CreateMap<OperationMasterModel, OperationMaster>();
            getOperationMasterResponseDto.OperationMasterList =
                Mapper.Map<List<OperationMasterModel>, List<OperationMaster>>(list);

            return getOperationMasterResponseDto;
        }
    }
}
