using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Sales
{
    public class WorkOrderDetailsCM
    {
        public string WorkOrderNumber { get; set; }
        public decimal WorkOrderSerial { get; set; }
        public string SerialNo { get; set; }
        public string HeatNo { get; set; }
        public bool DC { get; set; }
        public bool Invoice { get; set; }
        public bool SubContract { get; set; }
        public bool JTC { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
