using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Production
{
    public interface IBusinessJobCardGeneration
    {
        AddJobCardGenerationResponseDto AddJobCardGeneration(AddJobCardGenerationRequestDto addJobCardGenerationRequestDto);

        UpdateJobCardMaintanceResponseDto UpdateJobCardMaintance(GetJobCardMaintanceResponseDto getJobCardMaintanceResponseDto);

        DeleteJobCardDetailsResponseDto DeleteJobCardDetails(DeleteJobCardDetailsRequestDto deleteJobCardDetailsRequestDto);
    }
}
