using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetSerialNoFromWoNumerWoSerialResponse
    {
        public string SerialNo { get; set; }

        public string WONumber { get; set; }

        public string DCNumber { get; set; }

        public decimal WOSerial { get; set; }

    }
}
