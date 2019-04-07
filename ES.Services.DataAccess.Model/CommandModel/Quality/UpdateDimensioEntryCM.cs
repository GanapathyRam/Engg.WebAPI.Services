using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Quality
{
    public class UpdateDimensioEntryCM
    {
        public string SerialNo { get; set; }

        public string DimensionActual { get; set; }

        public string DatumDimesionActual { get; set; }

        public decimal Serial { get; set; }

        public decimal SequenceNumber { get; set; }
    }
}
