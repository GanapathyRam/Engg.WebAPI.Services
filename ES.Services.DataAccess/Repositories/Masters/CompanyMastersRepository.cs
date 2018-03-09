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
    public class CompanyMastersRepository : ICompanyMastersRepository
    {
        public AddCompanyMasterQueryModel AddCompanyMaster(AddCompanyMasterCommandModel addCompanyMasterCommandModel)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var companyMasterInsertCommand = new CompanyMasterInsertCommand { Connection = connection };
                companyMasterInsertCommand.Execute(addCompanyMasterCommandModel);
            }

            return new AddCompanyMasterQueryModel();
        }
       
    }
}
