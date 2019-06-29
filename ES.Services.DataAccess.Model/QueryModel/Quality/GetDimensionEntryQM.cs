using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Quality
{
    public class GetDimensionEntryQM
    {
        public IEnumerable<GetDimensionEntryEditModel> GetDimensionEntryEditModelList { get; set; }
    }

    public class GetDimensionEntryEditModel
    {
        public string WONumber { get; set; }

        public decimal WOSerial { get; set; }

        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string ItemCode { get; set; }

        public string MaterialDescription { get; set; }


        public string SerialNo { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal Serial { get; set; }

        public string Description { get; set; }

        public string DimensionMin { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionActual { get; set; }

        public string DatumDimesionActual { get; set; }
    }
}
