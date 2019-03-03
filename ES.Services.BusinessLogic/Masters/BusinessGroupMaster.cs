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
    public class BusinessGroupMaster : IBusinessGroupMaster
    {
        private readonly IGroupMasterRepository groupMasterRepository;
        public BusinessGroupMaster(IGroupMasterRepository groupMasterRepository)
        {
            this.groupMasterRepository = groupMasterRepository;
        }
        public AddGroupMasterResponseDto AddGroupMaster(AddGroupMasterRequestDto addGroupMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddGroupMasterResponseDto();
            var cModel = new AddGroupMasterCM
            {
                GroupDescription = addGroupMasterRequestDto.GroupDescription,
                CreatedBy = createdBy
            };

            var response = groupMasterRepository.AddGroupMaster(cModel);
            model.GroupCode = response.GroupCode;
            return model;
        }

        public UpdateGroupMasterResponseDto UpdateGroupMaster(UpdateGroupMasterRequestDto updateGroupMasterRequestDto)
        {
            var updatedBy = Helper.userIdToekn();
            var model = new UpdateGroupMasterResponseDto();
            var cModel = new UpdateGroupMasterCM
            {
                GroupCode= updateGroupMasterRequestDto.GroupCode,
                GroupDescription = updateGroupMasterRequestDto.GroupDescription,
                UpdatedBy = updatedBy
            };

            var response = groupMasterRepository.UpdateGroupMaster(cModel);
            model.GroupCode = response.GroupCode;
            return model;
        }
    }
}
