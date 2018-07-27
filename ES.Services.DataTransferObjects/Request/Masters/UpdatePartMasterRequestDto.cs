﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdatePartMasterRequestDto
    {
        public Int64 PartCode { get; set; }

        public Int64 VendorCode { get; set; }

        public string Description { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public decimal MaterialCode { get; set; }

        public decimal? RatePiece { get; set; }

        public decimal? RawWeight { get; set; }

        public decimal? FinishWeight { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
