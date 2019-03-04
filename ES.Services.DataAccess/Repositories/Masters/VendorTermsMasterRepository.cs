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
    public class VendorTermsMasterRepository : IVendorTermsMasterRepository
    {
        public AddVendorTermsMasterQM AddVendorTermsMaster(AddVendorTermsMasterCM addVendorTermsMasterCM)
        {
            var model = new AddVendorTermsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorTermsMasterInsertCommand { Connection = connection };
                model = command.Execute(addVendorTermsMasterCM);
            }

            return model;
        }

        public DeleteVendorTermsMasterQM DeleteVendorTermsMaster(DeleteVendorTermsMasterCM deleteVendorTermsMasterCM)
        {
            var model = new DeleteVendorTermsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorTermsMasterDeleteCommand { Connection = connection };
                model = command.Execute(deleteVendorTermsMasterCM);
            }

            return model;
        }

        public GetVendorTermsMasterQM GetVendorTermsMaster()
        {

            var model = new GetVendorTermsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorTermsMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;

        }

        public UpdateVendorTermsMasterQM UpdateVendorTermsMaster(UpdateVendorTermsMasterCM updateVendorTermsMasterCM)
        {
            var model = new UpdateVendorTermsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorTermsMasterUpdateCommand { Connection = connection };
                model = command.Execute(updateVendorTermsMasterCM);
            }

            return model;
        }
    }
}
