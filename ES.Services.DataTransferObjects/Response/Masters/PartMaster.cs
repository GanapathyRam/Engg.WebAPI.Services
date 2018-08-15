using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class PartMaster
    {
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Description { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingUnit { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public Int64 MaterialCode { get; set; }

        public string MaterialDescription { get; set; }

        public decimal? RatePiece { get; set; }

        public decimal? RawWeight { get; set; }

        public decimal? FinishWeight { get; set; }

        public Int64 PartCode { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
