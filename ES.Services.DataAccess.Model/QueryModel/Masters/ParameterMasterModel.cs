﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class ParameterMasterModel
    {
        public decimal ParameterCode { get; set; }
        public string Description { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
