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
    public class BusinessToolsMaster : IBusinessToolsMaster
    {
        private readonly IToolsMasterRepository toolsMastersRepository;

        public BusinessToolsMaster(IToolsMasterRepository toolsMastersRepository)
        {
            this.toolsMastersRepository = toolsMastersRepository;
        }

        public AddToolsMasterResponseDto AddToolsMaster(AddToolsMasterRequestDto addToolsMasterRequestDto)
        {
            var cModel = new AddToolsMasterCM()
            {
                Description = addToolsMasterRequestDto.Description
            };

            var response = toolsMastersRepository.AddToolsMaster(cModel);

            return new AddToolsMasterResponseDto();
        }

        public UpdateToolsMasterResponseDto UpdateToolsMaster(UpdateToolsMasterRequestDto updateToolsMasterRequestDto)
        {
            var cModel = new UpdateToolsMasterCM()
            {
                ToolCode = updateToolsMasterRequestDto.ToolCode,
                Description = updateToolsMasterRequestDto.Description
            };

            var response = toolsMastersRepository.UpdateToolsMaster(cModel);

            return new UpdateToolsMasterResponseDto();
        }
    }
}
