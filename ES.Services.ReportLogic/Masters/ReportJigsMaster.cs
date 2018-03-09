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
    public class ReportJigsMaster : IReportJigsMaster
    {
        private readonly IJigsMasterRepository JigsMastersRepository;

        public ReportJigsMaster(IJigsMasterRepository JigsMastersRepository)
        {
            this.JigsMastersRepository = JigsMastersRepository;
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

        //private static GetMaterialMasterResponseDto MaterialMasterMapper(List<MaterialMasterModel> list, GetMaterialMasterResponseDto getMaterialMasterResponseDto)
        //{
        //    Mapper.CreateMap<MaterialMasterModel, MaterialMaster>();
        //    getMaterialMasterResponseDto.MaterialMasterList =
        //        Mapper.Map<List<MaterialMasterModel>, List<MaterialMaster>>(list);

        //    return getMaterialMasterResponseDto;
        //}

        public GetJigsMasterResponseDto GetJigsMaster()
        {
            var response = new GetJigsMasterResponseDto();
            var cModel = new GetJigsMasterCM
            {
                //PageIndex = getJigsMasterRequestDto.PageIndex,
                //PageSize = getJigsMasterRequestDto.PageSize,
                //JigsCode = getJigsMasterRequestDto.JigsCode
            };
            var model = JigsMastersRepository.GetJigsMaster();

            if (model != null && model.GetJigsMasterList.Any())
            {
                response = JigsMasterMapper((List<JigsMasterModel>)model.GetJigsMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetJigsMasterResponseDto JigsMasterMapper(List<JigsMasterModel> list, GetJigsMasterResponseDto getJigsMasterResponseDto)
        {
            Mapper.CreateMap<JigsMasterModel, JigsMaster>();
            getJigsMasterResponseDto.JigsMasterList =
                Mapper.Map<List<JigsMasterModel>, List<JigsMaster>>(list);

            return getJigsMasterResponseDto;
        }
    }
}
