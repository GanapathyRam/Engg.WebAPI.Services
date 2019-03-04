using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Masters
{
   public interface IReportVendorTermsMaster
    {
        GetVendorTermsMasterResponseDto GetVendorTermsMaster();
    }
}
