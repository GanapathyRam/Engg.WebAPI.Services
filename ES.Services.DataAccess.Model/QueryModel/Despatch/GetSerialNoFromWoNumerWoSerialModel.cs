using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetSerialNoFromWoNumerWoSerialModel
    {
        public string SerialNo { get; set; }

        public string WONumber { get; set; }

        public string DCNumber { get; set; }

        public decimal WOSerial { get; set; }
    }
}
