using ES.Services.DataAccess.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataAccess.Commands.Masters;

namespace ES.Services.DataAccess.Repositories.Masters
{
    public class ToolsMasterRepository : IToolsMasterRepository
    {
        public AddToolsMasterQM AddToolsMaster(AddToolsMasterCM addToolsMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ToolsMasterInsertCommand { Connection = connection };
                command.Execute(addToolsMasterCM);
            }

            return new AddToolsMasterQM();
        }

        public GetToolsMasterQM GetToolsMaster(GetToolsMasterCM getToolsMasterCM)
        {
            var model = new GetToolsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ToolsMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateToolsMasterQM UpdateToolsMaster(UpdateToolsMasterCM updateToolsMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ToolsMasterUpdateCommand { Connection = connection };
                command.Execute(updateToolsMasterCM);
            }

            return new UpdateToolsMasterQM();
        }
    }
}
