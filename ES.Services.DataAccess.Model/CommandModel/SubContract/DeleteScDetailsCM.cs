using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.SubContract
{
    public class DeleteScDetailsCM
    {
        public List<DeleteScDetailsItems> scDetailsListItems { get; set; }
        public string ScNumer { get; set; }
        public string WoNumber { get; set; }
        public int IsDeleteFrom { get; set; }  /* 1. Master delete, 2 Dc Details, 3 Dc Details Serial */
    }

    public class DeleteScDetailsItems
    {
        public string WoNumber { get; set; }

        public string SerialNo { get; set; }

        public Decimal WoSerial { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
