using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Sales
{
    public class GetWorkOrderNumberForHeatQM
    {
        public IEnumerable<GetWorkOrderNumberHeatModelQM> getWorkOrderNumberHeatDetails { get; set; }
    }
    public class GetWorkOrderNumberHeatModelQM
    {
        public string WONumber { get; set; }
    }
}
