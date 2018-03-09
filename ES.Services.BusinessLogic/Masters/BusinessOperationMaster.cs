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
    public class BusinessOperationMaster : IBusinessOperationMaster
    {
        private readonly IOperationMasterRepository operationMastersRepository;

        public BusinessOperationMaster(IOperationMasterRepository operationMastersRepository)
        {
            this.operationMastersRepository = operationMastersRepository;
        }
        
        public AddOperationMasterResponseDto AddOperationMaster(AddOperationMasterRequestDto addOperationMasterRequestDto)
        {
            var cModel = new AddOperationMasterCM
            {
                OperationName = addOperationMasterRequestDto.OperationName
            };

            var response = operationMastersRepository.AddOperationMaster(cModel);

            return new AddOperationMasterResponseDto();
        }

        public UpdateOperationMasterResponseDto UpdateOperationMaster(UpdateOperationMasterRequestDto updateOperationMasterRequestDto)
        {
            var cModel = new UpdateOperationMasterCM
            {
                OperationCode = updateOperationMasterRequestDto.OperationCode,
                OperationName = updateOperationMasterRequestDto.OperationName
            };

            var response = operationMastersRepository.UpdateOperationMaster(cModel);

            return new UpdateOperationMasterResponseDto();
        }
    }
}
