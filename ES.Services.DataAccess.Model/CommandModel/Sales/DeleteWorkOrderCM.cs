using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Sales
{
    public class DeleteWorkOrderCM
    {
        public string WorkOrderNumber { get; set; }
        public decimal WorkOrderSerial { get; set; }
    }
}
