using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Repositories.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using AutoMapper;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportCompanyMaster : IReportCompanyMaster
    {
        private readonly ICompanyMastersRepository companyMastersRepository;

        public ReportCompanyMaster(CompanyMastersRepository companyMastersRepository)
        {
            this.companyMastersRepository = companyMastersRepository;
        }

        public GetCompanyMasterResponseDto GetCompanyMaster()
        {
            var response = new GetCompanyMasterResponseDto();

            int companyCode = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CompanyCode"]);


            var model = companyMastersRepository.GetCompanyMaster(companyCode);

            if (model != null)
            {
                response = CompanyMasterMapper((List<GetCompanyMasterModel>)model.GetCompanyMasterModelList, response);
                //response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetCompanyMasterResponseDto CompanyMasterMapper(List<GetCompanyMasterModel> list, GetCompanyMasterResponseDto getCompanyMasterResponseDto)
        {
            Mapper.CreateMap<GetCompanyMasterModel, CompanyMasterResponse>();
            getCompanyMasterResponseDto.CompanyMasterResponseLis =
                Mapper.Map<List<GetCompanyMasterModel>, List<CompanyMasterResponse>>(list);

            return getCompanyMasterResponseDto;
        }
    }
}
