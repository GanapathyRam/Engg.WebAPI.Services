using ES.Services.DataAccess.Commands.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Masters
{
    public class EmployeeMasterRepository : IEmployeeMasterRepository
    {
        public GetEmployeeMasterQM GetEmployeeMaster()
        {
            var model = new GetEmployeeMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new EmployeeMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
