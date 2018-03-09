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
    public class CategoryMasterRepository : ICategoryMasterRepository
    {
        public GetCategoryMasterQM GetCategoryMaster()
        {
            var model = new GetCategoryMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new CategoryMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }
    }
}
