using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
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
    public class ReportEmployeeMaster : IReportEmployeeMaster
    {
        private readonly IEmployeeMasterRepository employeeMastersRepository;

        public ReportEmployeeMaster(IEmployeeMasterRepository employeeMastersRepository)
        {
            this.employeeMastersRepository = employeeMastersRepository;
        }
        public GetEmployeeMasterResponseDto GetEmployeeMaster()
        {
            var response = new GetEmployeeMasterResponseDto();

            var model = employeeMastersRepository.GetEmployeeMaster();

            if (model != null)
            {
                response = EmployeeMasterMapper((List<EmployeeMasterModel>)model.EmployeeMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }


        private static GetEmployeeMasterResponseDto EmployeeMasterMapper(List<EmployeeMasterModel> list, GetEmployeeMasterResponseDto getEmployeeMasterResponseDto)
        {
            Mapper.CreateMap<EmployeeMasterModel, EmployeeMasterResponse>();
            getEmployeeMasterResponseDto.EmployeeMasterResponseList =
                Mapper.Map<List<EmployeeMasterModel>, List<EmployeeMasterResponse>>(list);

            return getEmployeeMasterResponseDto;
        }
    }
}
