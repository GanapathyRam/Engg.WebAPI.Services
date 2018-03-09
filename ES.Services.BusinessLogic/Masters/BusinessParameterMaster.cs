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
    public class BusinessParameterMaster : IBusinessParameterMaster
    {
        private readonly IParameterMasterRepository parameterMastersRepository;

        public BusinessParameterMaster(IParameterMasterRepository parameterMastersRepository)
        {
            this.parameterMastersRepository = parameterMastersRepository;
        }

        public AddParameterMasterResponseDto AddParameterMaster(AddParameterMasterRequestDto addParameterMasterRequestDto)
        {
            var cModel = new AddParameterMasterCM
            {
                description = addParameterMasterRequestDto.Description
            };

            var response = parameterMastersRepository.AddParameterMaster(cModel);

            return new AddParameterMasterResponseDto();
        }

        public UpdateParameterMasterResponseDto UpdateParameterMaster(UpdateParameterMasterRequestDto updateParameterMasterRequestDto)
        {
            var cModel = new UpdateParameterMasterCM
            {
                ParameterCode = updateParameterMasterRequestDto.ParameterCode,
                Description = updateParameterMasterRequestDto.Description
            };

            var response = parameterMastersRepository.UpdateParameterMaster(cModel);

            return new UpdateParameterMasterResponseDto();
        }
    }
}
