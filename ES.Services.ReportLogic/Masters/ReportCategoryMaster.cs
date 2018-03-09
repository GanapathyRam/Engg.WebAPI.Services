using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using AutoMapper;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportCategoryMaster : IReportCategoryMaster
    {

        private readonly ICategoryMasterRepository categoryMastersRepository;

        public ReportCategoryMaster(ICategoryMasterRepository categoryMastersRepository)
        {
            this.categoryMastersRepository = categoryMastersRepository;
        }
        public GetCategoryMasterResponseDto GetCategoryMaster()
        {
            var response = new GetCategoryMasterResponseDto();
          
            var model = categoryMastersRepository.GetCategoryMaster();

            if (model != null)
            {
                response = CategoryMasterMapper((List<CategoryMasterModel>)model.CategoryMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetCategoryMasterResponseDto CategoryMasterMapper(List<CategoryMasterModel> list, GetCategoryMasterResponseDto getCategoryMasterResponseDto)
        {
            Mapper.CreateMap<CategoryMasterModel, CategoryMaster>();
            getCategoryMasterResponseDto.CategoryMasterList =
                Mapper.Map<List<CategoryMasterModel>, List<CategoryMaster>>(list);

            return getCategoryMasterResponseDto;
        }
    }
}
