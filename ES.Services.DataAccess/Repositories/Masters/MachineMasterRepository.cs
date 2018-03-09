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
    public class MachineMasterRepository : IMachineMasterRepository
    {
        public AddMachineMasterQM AddMachineMaster(AddMachineMasterCM addMachineMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MachineMasterInsertCommand { Connection = connection };
                command.Execute(addMachineMasterCM);
            }

            return new AddMachineMasterQM();
        }

        public GetMachineMasterQM GetMachineMaster()
        {
            var model = new GetMachineMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MachineMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateMachineMasterQM UpdateMachineMaster(UpdateMachineMasterCM updateMachineMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MachineMasterUpdateCommand { Connection = connection };
                command.Execute(updateMachineMasterCM);
            }

            return new UpdateMachineMasterQM();
        }
    }
}
