using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Sales
{
    public class GetWorkOrderTypeQM
    {
        public IEnumerable<WorkOrderTypeModel> workOrderTypeModelList { get; set; }
    }
}
