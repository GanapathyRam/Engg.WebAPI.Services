using ES.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Quality
{
    public class UpdateDimensionEntryRequestDto : BaseResponse
    {
        public List<UpdateDimensionEntryResponse> UpdateDimensionEntryResponseList { get; set; }
    }

    public class UpdateDimensionEntryResponse
    {
        public string SerialNo { get; set; } 

        public string DimensionActual { get; set; }

        public string DatumDimesionActual { get; set; }

        public decimal Serial { get; set; }

        public decimal SequenceNumber { get; set; }
    }
}
