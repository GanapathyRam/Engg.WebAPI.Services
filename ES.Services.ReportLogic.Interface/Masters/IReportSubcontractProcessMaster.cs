using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Response.Masters;
namespace ES.Services.ReportLogic.Interface.Masters
{
    public interface IReportSubcontractProcessMaster
    {
        GetSubcontractProcessMasterResponseDto GetSubcontractProcessMaster();
    }
}
