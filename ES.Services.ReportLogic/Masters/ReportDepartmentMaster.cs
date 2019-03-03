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
    public class ReportDepartmentMaster : IReportDepartmentMaster
    {
        private readonly IDepartmentMasterRepository departmentMasterRepository;
        public ReportDepartmentMaster(IDepartmentMasterRepository departmentMasterRepository)
        {
            this.departmentMasterRepository = departmentMasterRepository;
        }
        public GetDepartmentMasterResponseDto GetDepartmentMaster()
        {
            var response = new GetDepartmentMasterResponseDto();
            var model = departmentMasterRepository.GetDepartmentMaster();
            if (model != null && model.DepartmentMasterList.Any())
            {
                response = DepartmentMasterMapper((List<DepartmentMasterModel>)model.DepartmentMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetDepartmentMasterResponseDto DepartmentMasterMapper(List<DepartmentMasterModel> departmentMasterList, GetDepartmentMasterResponseDto response)
        {
            Mapper.CreateMap<DepartmentMasterModel, DepartmentMaster>();
            response.DepartmentMasterList =
                Mapper.Map<List<DepartmentMasterModel>, List<DepartmentMaster>>(departmentMasterList);

            return response;
        }
    }
}
