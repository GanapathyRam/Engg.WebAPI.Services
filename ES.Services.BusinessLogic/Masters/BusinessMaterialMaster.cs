using ES.Services.BusinessLogic.Interface.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Registration;
using ES.Services.DataTransferObjects.Response.Registration;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessMaterialMaster : IBusinessMaterialMaster
    {
        private readonly IMaterialMasterRepository materialMasterRepository;

        public BusinessMaterialMaster(IMaterialMasterRepository materialMasterRepository)
        {
            this.materialMasterRepository = materialMasterRepository;
        }

        public AddMaterialMasterResponseDto AddMaterialMaster(AddMaterialMasterRequestDto addMaterialMasterRequestDto)
        {
            AddMaterialMasterResponseDto addMaterialMasterResponseDto = new AddMaterialMasterResponseDto();

            var cModel = new AddMaterialMasterCM
            {
                MaterialDescription = addMaterialMasterRequestDto.MaterialDescription,
                MaterialShortDescription = addMaterialMasterRequestDto.MaterialShortDescription
            };

            var response = materialMasterRepository.AddMaterialMaster(cModel);

            return new AddMaterialMasterResponseDto();
        }

        public UpdateMaterialMasterResponseDto UpdateMaterialMaster(UpdateMaterialMasterRequestDto updateMaterialMasterRequestDto)
        {
            UpdateMaterialMasterResponseDto updateMaterialMasterResponseDto = new UpdateMaterialMasterResponseDto();

            var cModel = new UpdateMaterialMasterCM
            {
                MaterialDescription = updateMaterialMasterRequestDto.MaterialDescription,
                MaterialShortDescription = updateMaterialMasterRequestDto.MaterialShortDescription,
                MaterialCode = updateMaterialMasterRequestDto.MaterialCode
            };

            var response = materialMasterRepository.UpdateMaterialMaster(cModel);

            return new UpdateMaterialMasterResponseDto();
        }
    }
}
