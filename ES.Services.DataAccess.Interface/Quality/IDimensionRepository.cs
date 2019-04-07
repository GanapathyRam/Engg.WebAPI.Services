using ES.Services.DataAccess.Model.CommandModel.Quality;
using ES.Services.DataAccess.Model.QueryModel.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Quality
{
    public interface IDimensionRepository
    {
        GetDimensionEntryQM GetDimensionEntryReport(string SerialNo);

        void UpdateDimensionEntry(UpdateDimensioEntryCM updateDimensioEntryCM);
    }
}
