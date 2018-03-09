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
    public class ParameterMasterRepository : IParameterMasterRepository
    {
        public AddParameterMasterQM AddParameterMaster(AddParameterMasterCM addParameterMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ParameterMasterInsertCommand { Connection = connection };
                command.Execute(addParameterMasterCM);
            }

            return new AddParameterMasterQM();
        }

        public GetParameterMasterQM GetParameterMaster()
        {
            var model = new GetParameterMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ParameterMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateParameterMasterQM UpdateParameterMaster(UpdateParameterMasterCM updateParameterMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ParameterMasterUpdateCommand { Connection = connection };
                command.Execute(updateParameterMasterCM);
            }

            return new UpdateParameterMasterQM(); ;
        }
    }
}
