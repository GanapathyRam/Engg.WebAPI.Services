using ES.ExceptionAttributes;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessDepartmentMaster : IBusinessDepartmentMaster
    {
        private readonly IDepartmentMasterRepository departmentMasterRepository;
        public BusinessDepartmentMaster(IDepartmentMasterRepository departmentMasterRepository)
        {
            this.departmentMasterRepository = departmentMasterRepository;
        }
        public AddDepartmentMasterResponseDto AddDepartmentMaster(AddDepartmentMasterRequestDto addDepartmentMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddDepartmentMasterResponseDto();
            var cModel = new AddDepartmentMasterCM
            {
                DepartmentName = addDepartmentMasterRequestDto.DepartmentName,
                CreatedBy = createdBy
            };

            var response = departmentMasterRepository.AddDepartmentMaster(cModel);
            model.DepartmentCode = response.DepartmentCode;
            return model;
        }

        public UpdateDepartmentMasterResponseDto UpdateDepartmentMaster(UpdateDepartmentMasterRequestDto updateDepartmentMasterRequestDto)
        {
            var updatedBy = Helper.userIdToekn();
            var model = new UpdateDepartmentMasterResponseDto();
            var cModel = new UpdateDepartmentMasterCM
            {
                DepartmentCode = updateDepartmentMasterRequestDto.DepartmentCode,
                DepartmentName = updateDepartmentMasterRequestDto.DepartmentName,
                UpdatedBy = updatedBy
            };

            var response = departmentMasterRepository.UpdateDepartmentMaster(cModel);
            model.DepartmentCode = response.DepartmentCode;
            return model;
        }
    }
}
