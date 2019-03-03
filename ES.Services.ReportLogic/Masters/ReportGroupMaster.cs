using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportGroupMaster : IReportGroupMaster
    {
        private readonly IGroupMasterRepository groupMasterRepository;
        public ReportGroupMaster(IGroupMasterRepository groupMasterRepository)
        {
            this.groupMasterRepository = groupMasterRepository;
        }
        public GetGroupMasterResponseDto GetGroupMaster()
        {
            var response = new GetGroupMasterResponseDto();
            var model = groupMasterRepository.GetGroupMaster();
            if (model != null && model.GroupMasterList.Any())
            {
                response = GroupMasterMapper((List<GroupMasterModel>)model.GroupMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetGroupMasterResponseDto GroupMasterMapper(List<GroupMasterModel> groupMasterList, GetGroupMasterResponseDto response)
        {
            Mapper.CreateMap<GroupMasterModel, GroupMaster>();
            response.GroupMasterList =
                Mapper.Map<List<GroupMasterModel>, List<GroupMaster>>(groupMasterList);

            return response;
        }
    }
}
