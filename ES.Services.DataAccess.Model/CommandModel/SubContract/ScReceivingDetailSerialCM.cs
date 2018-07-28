using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.SubContract
{
    public class ScReceivingDetailSerialCM
    {
        public IEnumerable<ScReceivingDetailSerialItems> ScReceivingDetailSerialItems { get; set; }
    }

    public class ScReceivingDetailSerialItems
    {
        public string ScReceivingNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public string SerialNo { get; set; }

        public bool IsReceived { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
