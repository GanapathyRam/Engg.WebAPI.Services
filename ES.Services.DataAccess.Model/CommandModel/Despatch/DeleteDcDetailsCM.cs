using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Despatch
{
    public class DeleteDcDetailsCM
    {
        public List<DeleteDcDetailsItems> dcDetailsListItems { get; set; }
        public string DcNumer { get; set; }
        public string WoNumber { get; set; }
        public int IsDeleteFrom { get; set; }  /* 1. Master delete, 2 Dc Details, 3 Dc Details Serial */
    }

    public class DeleteDcDetailsItems
    {
        public string WoNumber { get; set; }

        public string SerialNo { get; set; }

        public Decimal WoSerial { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
