using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.SubContract
{
    public class ScDetailSerialCM
    {
        public IEnumerable<ScDetailSerialItems> ScDetailSerialItems { get; set; }
    }

    public class ScDetailSerialItems
    {
        public string ScNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public string SerialNo { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
