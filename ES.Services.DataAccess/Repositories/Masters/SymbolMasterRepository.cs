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
    public class SymbolMasterRepository : ISymbolMasterRepository
    {
        public GetSymbolMasterQM GetSymbolMaster()
        {
            var model = new GetSymbolMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new SymbolMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
