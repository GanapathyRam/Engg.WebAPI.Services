using ES.Services.DataTransferObjects.Request.Stores;
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
        GetGPOutsideReturnNumberResponseDto GetGPOutsideReturnNumber();
        GPOutsideReturnResponseDto GetGPOutsideReturn();
        GetGPOutsideReturnVendorResponseDto GetGPOutsideReturnVendorList();
        GPOutsideReturnDetailsGridResponseDto GetGPReceivedDetailsGrid(Int64 VendorCode);
    }
}
