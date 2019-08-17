using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class AddGRNDetailsCM
    {
        public IEnumerable<AddGRNDetailsCMItems> AddGRNDetailsCMItems { get; set; }
    }

    public class AddGRNDetailsCMItems
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
