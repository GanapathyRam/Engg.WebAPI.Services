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
    public class VendorMasterRepository : IVendorMasterRepository
    {
        public AddVendorMasterQM AddVendorMaster(AddVendorMasterCM addVendorMasterCM)
        {
            var response = new AddVendorMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorMasterInsertCommand { Connection = connection };
                response.VendorCode = command.Execute(addVendorMasterCM);
            }

            return response;
        }

        public UpdateVendorMasterQM UpdateVendorMaster(UpdateVendorMasterCM updateVendorMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorMasterUpdateCommand { Connection = connection };
                command.Execute(updateVendorMasterCM);
            }

            return new UpdateVendorMasterQM();
        }

        public GetVendorMasterQM GetVendorMaster()
        {
            var model = new GetVendorMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public GetVendorMasterListQM GetVendorMasterList()
        {
            var model = new GetVendorMasterListQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new VendorMasterListSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
