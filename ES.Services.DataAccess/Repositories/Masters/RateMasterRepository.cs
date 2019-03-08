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
    public class RateMasterRepository : IRateMasterRepository
    {
        public AddRateMasterQM AddRateMaster(AddRateMasterCM addRateMasterCM)
        {
            var model = new AddRateMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new RateMasterInsertCommand { Connection = connection };
                model = command.Execute(addRateMasterCM);
            }

            return model;
        }

        public DeleteRateMasterQM DeleteRateMaster(DeleteRateMasterCM deleteRateMasterCM)
        {
            var model = new DeleteRateMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new RateMasterDeleteCommand { Connection = connection };
                model = command.Execute(deleteRateMasterCM);
            }

            return model;
        }

        public GetRateMasterQM GetRateMaster()
        {
            var model = new GetRateMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new RateMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateRateMasterQM UpdateRateMaster(UpdateRateMasterCM updateRateMasterCM)
        {
            var model = new UpdateRateMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new RateMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateRateMasterCM);
            }

            return model;
        }
    }
}
