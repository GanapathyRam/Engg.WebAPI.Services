using ES.Services.DataAccess.Interface.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataAccess.Model.QueryModel.SubContract;
using ES.Services.DataAccess.Commands.Despatch;
using ES.Services.DataAccess.Commands.SubContract;

namespace ES.Services.DataAccess.Repositories.SubContract
{
    public class SubContractRepository : ISubContractRepository
    {
        public GetSubContractSendingResponseQM GetSubContractSendingDetails()
        {
            var model = new GetSubContractSendingResponseQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSubContractSendingSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
