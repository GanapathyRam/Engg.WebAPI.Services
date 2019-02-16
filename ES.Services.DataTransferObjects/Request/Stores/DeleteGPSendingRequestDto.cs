
using System;
using System.Collections.Generic;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class DeleteGPSendingRequestDto
    {
        public string GPNumber { get; set; }

        public int IsDeleteFrom { get; set; }  /* 1. Delete From GP Master 2. Delete From GP Details */

        public List<DeleteGPSendingDetails> DeleteGPSendingDetails { get; set; }
    }

    public class DeleteGPSendingDetails
    {
        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }
    }
}
