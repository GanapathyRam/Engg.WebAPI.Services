using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Stores
{
   public interface IBusinessGatePassOutside
    {
        GPOutsideReceiptResponseDto SaveGPOutsideReceipt(GPOutsideReceiptRequestDto gPOutsideReceiptRequestDto);

        DeleteGPOutsideReceiptResponseDto DeletPOutsideReceiptMasterAndDetails(DeleteGPOutsideReceiptRequestDto deleteGPOutsideReceiptRequestDto);

        GetGPOutsideReturnResponseDto SaveGPOutsideReturn(GPOutsideReturnRequestDto gpOutsideReturnRequestDto);
    }
}
