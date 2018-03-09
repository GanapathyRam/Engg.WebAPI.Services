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
    public class BusinessMachineMaster : IBusinessMachineMaster
    {
        private readonly IMachineMasterRepository machineMastersRepository;

        public BusinessMachineMaster(IMachineMasterRepository machineMastersRepository)
        {
            this.machineMastersRepository = machineMastersRepository;
        }

        public AddMachineMasterResponseDto AddMachineMaster(AddMachineMasterRequestDto addMachineMasterRequestDto)
        {
            var cModel = new AddMachineMasterCM()
            {
                MachineName = addMachineMasterRequestDto.MachineName,
                AddedDate = addMachineMasterRequestDto.AddedDate
            };

            var response = machineMastersRepository.AddMachineMaster(cModel);

            return new AddMachineMasterResponseDto();
        }

        public UpdateMachineMasterResponseDto UpdateMachineMaster(UpdateMachineMasterRequestDto updateMachineMasterRequestDto)
        {
            var cModel = new UpdateMachineMasterCM()
            {
                MachineCode = updateMachineMasterRequestDto.MachineCode,
                MachineName = updateMachineMasterRequestDto.MachineName,
                AddedDate = updateMachineMasterRequestDto.AddedDate
            };

            var response = machineMastersRepository.UpdateMachineMaster(cModel);

            return new UpdateMachineMasterResponseDto();
        }
    }
}
