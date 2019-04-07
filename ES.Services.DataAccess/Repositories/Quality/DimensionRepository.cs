using ES.Services.DataAccess.Commands.Quality;
using ES.Services.DataAccess.Interface.Quality;
using ES.Services.DataAccess.Model.QueryModel.Quality;
using ES.Services.DataAccess.Repositories.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataAccess.Model.CommandModel.Quality;

namespace ES.Services.DataAccess.Repositories.Quality
{
    public class DimensionRepository : IDimensionRepository
    {
        public GetDimensionEntryQM GetDimensionEntryReport(string SerialNo)
        {
            var model = new GetDimensionEntryQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DimensionEntrySelectCommand { Connection = connection };
                model = command.Execute(SerialNo);
            }

            return model;
        }

        public void UpdateDimensionEntry(UpdateDimensioEntryCM updateDimensioEntryCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DimensionEntryUpdateCommand { Connection = connection };

                command.Execute(updateDimensioEntryCM);
            }
        }
    }
}
