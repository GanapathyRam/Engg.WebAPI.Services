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
    public class OperationMasterRepository : IOperationMasterRepository
    {

        public AddOperationMasterQM AddOperationMaster(AddOperationMasterCM addOperationMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new OperationMasterInsertCommand { Connection = connection };
                command.Execute(addOperationMasterCM);
            }

            return new AddOperationMasterQM();
        }

        public GetOperationMasterQM GetOperationMaster()
        {
            var model = new GetOperationMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new OperationMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateOperationMasterQM UpdateOperationMaster(UpdateOperationMasterCM updateOperationMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new OperationMasterUpdateCommand { Connection = connection };
                command.Execute(updateOperationMasterCM);
            }

            return new UpdateOperationMasterQM();
        }
    }
}
