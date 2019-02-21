using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPReceivingDetailsCM
    {
        public IEnumerable<GPReceivingDetailsListCM> GPReceivingDetailsListItemsCM { get; set; }
    }

    public class GPReceivingDetailsListCM
    {
        public string GPReceiptNumber { get; set; }

        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
