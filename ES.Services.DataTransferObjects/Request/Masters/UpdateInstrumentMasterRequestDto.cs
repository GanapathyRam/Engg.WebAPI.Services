﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateInstrumentMasterRequestDto
    {
        public decimal InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public DateTime? AddedDate { get; set; }
        public string Make { get; set; }
        public string Range { get; set; }
        public string Accuracy { get; set; }
        public string Serial { get; set; }
        public DateTime? CalibratedDate { get; set; }
        public decimal Frequency { get; set; }
        public DateTime? CalibrationDueDate { get; set; }
        public string VendorCode { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
