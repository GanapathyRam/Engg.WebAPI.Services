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
    public class ReportMaterialMaster : IReportMaterialMaster
    {
        private readonly IMaterialMasterRepository materialMastersRepository;

        public ReportMaterialMaster(IMaterialMasterRepository materialMastersRepository)
        {
            this.materialMastersRepository = materialMastersRepository;
        }
        public GetMaterialMasterResponseDto GetMaterialMaster()
        {
            var response = new GetMaterialMasterResponseDto();
            var cModel = new GetMaterialMasterCM
            {
                //PageIndex = getMaterialMasterRequestDto.PageIndex,
                //PageSize = getMaterialMasterRequestDto.PageSize,
                //MaterialCode = getMaterialMasterRequestDto.MaterialCode
            };
            var model = materialMastersRepository.GetMaterialMaster();

            if (model != null && model.MaterialMasterList.Any())
            {
                response = MaterialMasterMapper((List<MaterialMasterModel>)model.MaterialMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        public GetMaterialMasterListResponseDto GetMaterialMasterList()
        {
            var response = new GetMaterialMasterListResponseDto();
            var cModel = new GetMaterialMasterListCM
            {
                //PageIndex = getMaterialMasterListRequestDto.PageIndex,
                //PageSize = getMaterialMasterListRequestDto.PageSize
            };
            var model = materialMastersRepository.GetMaterialMasterList();

            if (model != null && model.MaterialMasterList.Any())
            {
                response = MaterialMasterListMapper((List<MaterialMasterListForDropDown>)model.MaterialMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetMaterialMasterListResponseDto MaterialMasterListMapper(List<MaterialMasterListForDropDown> list, GetMaterialMasterListResponseDto GetMaterialMasterListResponseDto)
        {
            Mapper.CreateMap<MaterialMasterListForDropDown, MaterialMasterList>();
            GetMaterialMasterListResponseDto.MaterialMasterList =
                Mapper.Map<List<MaterialMasterListForDropDown>, List<MaterialMasterList>>(list);

            return GetMaterialMasterListResponseDto;
        }

        private static GetMaterialMasterResponseDto MaterialMasterMapper(List<MaterialMasterModel> list, GetMaterialMasterResponseDto getMaterialMasterResponseDto)
        {
            Mapper.CreateMap<MaterialMasterModel, MaterialMaster>();
            getMaterialMasterResponseDto.MaterialMasterList =
                Mapper.Map<List<MaterialMasterModel>, List<MaterialMaster>>(list);

            return getMaterialMasterResponseDto;
        }
    }
}
