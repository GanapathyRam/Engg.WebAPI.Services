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
    public class ReportToolsMaster : IReportToolsMaster
    {
        private readonly IToolsMasterRepository toolsMastersRepository;

        public ReportToolsMaster(IToolsMasterRepository toolsMastersRepository)
        {
            this.toolsMastersRepository = toolsMastersRepository;
        }

        public GetToolsMasterResponseDto GetToolsMaster()
        {
            var response = new GetToolsMasterResponseDto();

            var cModel = new GetToolsMasterCM()
            {
                //PageIndex = getToolsMasterRequestDto.PageIndex,
                //PageSize = getToolsMasterRequestDto.PageSize,
                //ToolsCode = getToolsMasterRequestDto.ToolCode
            };

            var model = toolsMastersRepository.GetToolsMaster(cModel);

            if (model != null && model.GetToolsMasterList.Any())
            {
                response = ToolsMasterMapper((List<ToolsMasterModel>)model.GetToolsMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }
        //public GetMaterialMasterResponseDto GetMaterialMaster(GetMaterialMasterRequestDto getMaterialMasterRequestDto)
        //{
        //    var response = new GetMaterialMasterResponseDto();
        //    var cModel = new GetMaterialMasterCM
        //    {
        //        PageIndex = getMaterialMasterRequestDto.PageIndex,
        //        PageSize = getMaterialMasterRequestDto.PageSize,
        //        MaterialCode = getMaterialMasterRequestDto.MaterialCode
        //    };
        //    var model = materialMastersRepository.GetMaterialMaster(cModel);

        //    if (model != null && model.MaterialMasterList.Any())
        //    {
        //        response = MaterialMasterMapper((List<MaterialMasterModel>)model.MaterialMasterList, response);
        //    }

        //    return response;
        //}

        private static GetToolsMasterResponseDto ToolsMasterMapper(List<ToolsMasterModel> list, GetToolsMasterResponseDto getToolsMasterResponseDto)
        {
            Mapper.CreateMap<ToolsMasterModel, ToolsMaster>();
            getToolsMasterResponseDto.ToolsMasterList =
                Mapper.Map<List<ToolsMasterModel>, List<ToolsMaster>>(list);

            return getToolsMasterResponseDto;
        }
    }
}
