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
    public class PartMasterRepository : IPartMasterRepository
    {
        public AddPartMasterQM AddPartMaster(AddPartMasterCM addPartMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PartMasterInsertCommand { Connection = connection };
                command.Execute(addPartMasterCM);
            }

            return new AddPartMasterQM();
        }

        public GetPartMasterQM GetPartMaster(GetPartMasterCM getPartMasterCM)
        {
            var model = new GetPartMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PartMasterSelectCommand { Connection = connection };
                model = command.Execute(getPartMasterCM);
            }

            return model;
        }

        public UpdatePartMasterQM UpdatePartMaster(UpdatePartMasterCM updatePartMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PartMasterUpdateCommand { Connection = connection };
                command.Execute(updatePartMasterCM);
            }

            return new UpdatePartMasterQM(); ;
        }
    }
}
