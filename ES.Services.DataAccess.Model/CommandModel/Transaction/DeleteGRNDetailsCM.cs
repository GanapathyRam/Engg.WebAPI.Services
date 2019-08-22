﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class DeleteGRNDetailsCM
    {
        public IList<DeleteGRNDetailsCMItem> DeleteGRNDetailsCMList { get; set; }
    }

    public class DeleteGRNDetailsCMItem
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}