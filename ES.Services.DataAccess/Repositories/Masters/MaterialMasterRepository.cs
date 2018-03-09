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
    public class MaterialMasterRepository : IMaterialMasterRepository
    {
        public AddMaterialMasterQM AddMaterialMaster(AddMaterialMasterCM addMaterialMasterCM)
        {
            var response = new AddMaterialMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MaterialMasterInsertCommand { Connection = connection };
                response.MaterialCode = command.Execute(addMaterialMasterCM);
            }

            return response;
        }

        public UpdateMaterialMasterQM UpdateMaterialMaster(UpdateMaterialMasterCM updateMaterialMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MaterialMasterUpdateCommand { Connection = connection };
                command.Execute(updateMaterialMasterCM);
            }

            return new UpdateMaterialMasterQM();
        }

        public GetMaterialMasterQM GetMaterialMaster()
        {
            var model = new GetMaterialMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MaterialMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public GetMaterialMasterListQM GetMaterialMasterList()
        {
            var model = new GetMaterialMasterListQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new MaterialMasterListSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
