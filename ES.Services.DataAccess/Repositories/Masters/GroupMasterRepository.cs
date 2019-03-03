using ES.Services.DataAccess.Commands.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Masters
{
    public class GroupMasterRepository : IGroupMasterRepository
    {
        public AddGroupMasterQM AddGroupMaster(AddGroupMasterCM addParameterMasterCM)
        {
            var model = new AddGroupMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GroupMasterInsertCommand { Connection = connection };
                model = command.Execute(addParameterMasterCM);
            }

            return model;
        }

        public GetGroupMasterQM GetGroupMaster()
        {
            var model = new GetGroupMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GroupMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateGroupMasterQM UpdateGroupMaster(UpdateGroupMasterCM updateParameterMasterCM)
        {
            var model = new UpdateGroupMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GroupMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateParameterMasterCM);
            }

            return model;
        }
    }
}
