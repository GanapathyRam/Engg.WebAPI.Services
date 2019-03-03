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
    public class DepartmentMasterRepository : IDepartmentMasterRepository
    {
        public AddDepartmentMasterQM AddDepartmentMaster(AddDepartmentMasterCM addDepartmentMasterCM)
        {
            var model = new AddDepartmentMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DepartmentMasterInsertCommand { Connection = connection };
                model = command.Execute(addDepartmentMasterCM);
            }

            return model;
        }

        public GetDepartmentMasterQM GetDepartmentMaster()
        {
            var model = new GetDepartmentMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DepartmentMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateDepartmentMasterQM UpdateDepartmentMaster(UpdateDepartmentMasterCM updateDepartmentMasterCM)
        {
            var model = new UpdateDepartmentMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DepartmentMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateDepartmentMasterCM);
            }

            return model;
        }
    }
}
