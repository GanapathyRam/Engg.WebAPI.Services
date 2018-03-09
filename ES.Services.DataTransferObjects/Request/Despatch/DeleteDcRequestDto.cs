using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class DeleteDcRequestDto
    {
        public List<DeleteDcDetails> DcDetailsList { get; set; }
        public string DcNumer { get; set; }
        public string WoNumber { get; set; }
        public int IsDeleteFrom { get; set; }  /* 1. Master delete, 2 Dc Details, 3 Dc Details Serial */
    }

    public class DeleteDcDetails
    {
        public string WoNumber { get; set; }

        public string SerialNo { get; set; }

        public decimal WoSerial { get; set; }
    }
}
