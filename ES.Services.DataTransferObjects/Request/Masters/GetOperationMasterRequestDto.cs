﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class GetOperationMasterRequestDto
    {

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public decimal OperationCode { get; set; }

    }
}
