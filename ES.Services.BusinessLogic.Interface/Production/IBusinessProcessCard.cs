using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Production
{
    public interface IBusinessProcessCard
    {
        AddProcessCardResponseDto AddProcessCard(AddProcessCardRequestDto addProcessCardRequestDto);

        DeleteProcessCardResponseDto DeleteProcessCard(DeleteProcessCardRequestDto deleteProcessCardRequestDto);

        AddProcesssCardCopyResponseDto AddProcessCardCopy(AddProcesssCardCopyRequestDto addProcesssCardCopyRequestDto);
    }
}
