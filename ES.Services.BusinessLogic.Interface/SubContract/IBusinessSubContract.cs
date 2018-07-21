using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.SubContract
{
    public interface IBusinessSubContract
    {
        SubContractResponseDto AddSubContractSending(SubContractRequestDto subContractRequestDto);
    }
}
