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
    public class SubcontractProcessMasterRepository : ISubcontractProcessMasterRepository
    {
      public  AddSubcontractProcessMasterQM AddSubcontractProcessMaster(AddSubcontractProcessMasterCM addSubcontractProcessMasterCM)
        {
              using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new SubcontractProcessMasterInsertCommand { Connection = connection };
                command.Execute(addSubcontractProcessMasterCM);
            }

            return new AddSubcontractProcessMasterQM();

        }
        public UpdateSubcontractProcessMasterQM UpdateSubcontractProcessMaster(UpdateSubcontractProcessMasterCM updateSubcontractProcessMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new SubcontractProcessMasterUpdateCommand { Connection = connection };
                command.Execute(updateSubcontractProcessMasterCM);
            }

            return new UpdateSubcontractProcessMasterQM();
        }
        public GetSubcontractProcessMasterQM GetSubcontractProcessMaster()
        {
            var model = new GetSubcontractProcessMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new SubcontractProcessMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
