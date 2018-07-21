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
    public class BusinessSubcontractProcessMaster : IBusinessSubcontractProcessMaster
    {
        private readonly ISubcontractProcessMasterRepository subcontractProcessMasterRepository;

        public BusinessSubcontractProcessMaster(ISubcontractProcessMasterRepository subcontractProcessMasterRepository)
        {
            this.subcontractProcessMasterRepository = subcontractProcessMasterRepository;
        }
       public AddSubcontractProcessMasterResponseDto AddSubcontractProcessMaster(AddSubcontractProcessMasterRequestDto addSubcontractProcessMasterRequestDto)
        {
            var cModel = new AddSubcontractProcessMasterCM
            {
                ProcessDescription = addSubcontractProcessMasterRequestDto.ProcessDescription,
                CreatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove
                CreatedDateTime = System.DateTime.UtcNow
            };

            var response = subcontractProcessMasterRepository.AddSubcontractProcessMaster(cModel);

            return new AddSubcontractProcessMasterResponseDto();
        }
        public UpdateSubcontractProcessMasterResponseDto UpdateSubcontractProcessMaster(UpdateSubcontractProcessMasterRequestDto updateSubcontractProcessMasterRequestDto)
        {
            var cModel = new UpdateSubcontractProcessMasterCM
            {
                ProcessCode = updateSubcontractProcessMasterRequestDto.ProcessCode,
                ProcessDescription= updateSubcontractProcessMasterRequestDto.ProcessDescription,
                UpdatedBy = new Guid("783F190B-9B66-42AC-920B-E938732C1C01"), //Later needs to be remove,
                UpdatedDateTime = System.DateTime.UtcNow,

            };

            var response = subcontractProcessMasterRepository.UpdateSubcontractProcessMaster(cModel);
            return new UpdateSubcontractProcessMasterResponseDto();
        }
    }
}
