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
    public class InventoryMasterRepository : IInventoryMasterRepository
    {
        public AddInventoryMasterQM AddInventoryMaster(AddInventoryMasterCM addInventoryMasterCM)
        {
            var model = new AddInventoryMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InventoryMasterInsertCommand { Connection = connection };
                model = command.Execute(addInventoryMasterCM);
            }

            return model;
        }

        public GetInventoryMasterQM GetInventoryMaster()
        {
            var model = new GetInventoryMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InventoryMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateInventoryMasterQM UpdateInventoryMaster(UpdateInventoryMasterCM updateInventoryMasterCM)
        {
            var model = new UpdateInventoryMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InventoryMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateInventoryMasterCM);
            }

            return model;
        }
    }
}
