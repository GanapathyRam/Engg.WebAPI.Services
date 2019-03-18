using ES.Services.DataTransferObjects.Response.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Stores
{
   public interface IReportGPOutside
    {
        GetGPOutsideReceiptNumberResponseDto getGPOutsideReceiptNumber(string gpOutsideType);
        GetGPOutsideReceiptResponseDto getGPOutsideReceipt();
    }
}
