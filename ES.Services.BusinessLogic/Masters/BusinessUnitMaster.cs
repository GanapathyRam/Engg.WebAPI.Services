using ES.ExceptionAttributes;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessUnitMaster : IBusinessUnitMaster
    {
        private readonly IUnitMasterRepository unitMasterRepository;
        public BusinessUnitMaster(IUnitMasterRepository unitMasterRepository)
        {
            this.unitMasterRepository = unitMasterRepository;
        }
        public AddUnitMasterResponseDto AddUnitMaster(AddUnitMasterRequestDto addUnitMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddUnitMasterResponseDto();
            var cModel = new AddUnitMasterCM
            {
                UOMDescription = addUnitMasterRequestDto.UOMDescription,
                CreatedBy = createdBy
            };

            var response = unitMasterRepository.AddUnitMaster(cModel);
            model.UOMCode = response.UOMCode;
            return model;
        }

        public UpdateUnitMasterResponseDto UpdateUnitMaster(UpdateUnitMasterRequestDto updateUnitMasterRequestDto)
        {
            var updatedBy = Helper.userIdToekn();
            var model = new UpdateUnitMasterResponseDto();
            var cModel = new UpdateUnitMasterCM
            {
                UOMCode = updateUnitMasterRequestDto.UOMCode,
                UOMDescription = updateUnitMasterRequestDto.UOMDescription,
                UpdatedBy = updatedBy
            };

            var response = unitMasterRepository.UpdateUnitMaster(cModel);
            model.UOMCode = response.UOMCode;
            return model;
        }
    }
}
