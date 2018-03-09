using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Despatch
{
    public class DcDetailSerialCM
    {
        public IEnumerable<DcDetailSerialItems> DcDetailSerialItems { get; set; }
    }

    public class DcDetailSerialItems
    {
        public string DcNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal DcSerial { get; set; }

        public decimal WoSerial { get; set; }

        public string SerialNo { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
