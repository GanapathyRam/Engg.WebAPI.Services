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
    public class InstrumentMasterRepository : IInstrumentMasterRepository
    {
        public AddInstrumentMasterQM AddInstrumentMaster(AddInstrumentMasterCM addInstrumentMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InstrumentMasterInsertCommand { Connection = connection };
                command.Execute(addInstrumentMasterCM);
            }

            return new AddInstrumentMasterQM();
        }

        public GetInstrumentMasterQM GetInstrumentMaster()
        {
            var model = new GetInstrumentMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InstrumentMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public UpdateInstrumentMasterQM UpdateInstrumentMaster(UpdateInstrumentMasterCM updateInstrumentMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InstrumentMasterUpdateCommand { Connection = connection };
                command.Execute(updateInstrumentMasterCM);
            }

            return new UpdateInstrumentMasterQM();
        }
    }
}
