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
    public class UnitMasterRepository : IUnitMasterRepository
    {
        public AddUnitMasterQM AddUnitMaster(AddUnitMasterCM addUnitMasterCM)
        {
            var model = new AddUnitMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new UnitMasterInsertCommand { Connection = connection };
                model = command.Execute(addUnitMasterCM);
            }

            return model;
        }

        public GetUnitMasterQM GetUnitMaster()
        {
            var model = new GetUnitMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new UnitMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateUnitMasterQM UpdateUnitMaster(UpdateUnitMasterCM updateUnitMasterCM)
        {
            var model = new UpdateUnitMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new UnitMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateUnitMasterCM);
            }

            return model;
        }
    }
}
