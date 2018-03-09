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
    public class BusinessJigsMaster : IBusinessJigsMaster
    {
        private readonly IJigsMasterRepository JigsMastersRepository;

        public BusinessJigsMaster(IJigsMasterRepository JigsMastersRepository)
        {
            this.JigsMastersRepository = JigsMastersRepository;
        }

        public AddJigsMasterResponseDto AddJigsMaster(AddJigsMasterRequestDto addJigsMasterRequestDto)
        {
            var cModel = new AddJigsMasterCM
            {
                Description = addJigsMasterRequestDto.Description
            };

            var response = JigsMastersRepository.AddJigsMaster(cModel);

            return new AddJigsMasterResponseDto();
        }

        public UpdateJigsMasterResponseDto UpdateJigsMaster(UpdateJigsMasterRequestDto updateJigsMasterRequestDto)
        {
            var cModel = new UpdateJigsMasterCM
            {
                JigsCode = updateJigsMasterRequestDto.JigsCode,
                Description = updateJigsMasterRequestDto.Description
            };

            var response = JigsMastersRepository.UpdateJigsMaster(cModel);

            return new UpdateJigsMasterResponseDto();
        }
    }
}
