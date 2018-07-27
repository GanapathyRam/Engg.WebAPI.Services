using System;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class AddPartMasterCM
    {
        public Int64 VendorCode { get; set; }

        public string Description { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public decimal MaterialCode { get; set; }

        public decimal? RatePiece { get; set; }

        public decimal? RawWeight { get; set; }

        public decimal? FinishWeight { get; set; }
    }
}
