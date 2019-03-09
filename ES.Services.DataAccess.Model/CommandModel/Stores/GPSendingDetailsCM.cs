using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPSendingDetailsCM
    {
        public IEnumerable<GPSendingDetailsListCM> GPSendingDetailsListItemsCM { get; set; }
    }

    public class GPSendingDetailsListCM
    {
        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public string Description { get; set; }

        public decimal Units { get; set; }

        public decimal SentQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
