using ES.Services.BusinessLogic.Interface.Production;
using ES.Services.DataTransferObjects.Request.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.ReportLogic.Interface.Production;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Production
{
    [JwtAuthenticationAttribute]
    public class ProcessCardController : ApiController, IBusinessProcessCard, IReportProcessCard
    {
        public readonly IBusinessProcessCard bProcessCardProvider;
        public readonly IReportProcessCard rProcessCardProvider;

        public ProcessCardController()
        {
            this.rProcessCardProvider = ObjectFactory.GetInstance<IReportProcessCard>();
            this.bProcessCardProvider = ObjectFactory.GetInstance<IBusinessProcessCard>();
        }

        [HttpPost]
        public AddProcessCardResponseDto AddProcessCard(AddProcessCardRequestDto addProcessCardRequestDto)
        {
            AddProcessCardResponseDto response = new AddProcessCardResponseDto();
            try
            {
                response = bProcessCardProvider.AddProcessCard(addProcessCardRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetSequenceNumberResponseDto GetSequenceNumber(GetSequenceNumberRequestDto getSequenceNumberRequestDto)
        {
            GetSequenceNumberResponseDto response = new GetSequenceNumberResponseDto();
            try
            {
                response = rProcessCardProvider.GetSequenceNumber(getSequenceNumberRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetSequenceNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetSequenceNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
    }
}
