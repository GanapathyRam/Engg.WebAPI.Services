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
    public class JigsMasterRepository : IJigsMasterRepository
    {
        public AddJigsMasterQM AddJigsMaster(AddJigsMasterCM addJigsMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new JigsMasterInsertCommand { Connection = connection };
                command.Execute(addJigsMasterCM);
            }

            return new AddJigsMasterQM();
        }

        public GetJigsMasterQM GetJigsMaster()
        {
            var model = new GetJigsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new JigsMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateJigsMasterQM UpdateJigsMaster(UpdateJigsMasterCM updateJigsMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new JigsMasterUpdateCommand { Connection = connection };
                command.Execute(updateJigsMasterCM);
            }

            return new UpdateJigsMasterQM(); ;
        }
    }
}
