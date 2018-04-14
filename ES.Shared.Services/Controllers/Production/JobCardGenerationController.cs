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
    public class JobCardGenerationController : ApiController, IBusinessJobCardGeneration, IReportJobCardGeneration
    {
        public readonly IBusinessJobCardGeneration bJobCardProvider;
        public readonly IReportJobCardGeneration rJobCardProvider;

        public JobCardGenerationController()
        {
            this.rJobCardProvider = ObjectFactory.GetInstance<IReportJobCardGeneration>();
            this.bJobCardProvider = ObjectFactory.GetInstance<IBusinessJobCardGeneration>();
        }

        [HttpPost]
        public GetJobCardGenerationResponseDto GetJobCardGeneration()
        {
            GetJobCardGenerationResponseDto response = new GetJobCardGenerationResponseDto();
            try
            {
                response = rJobCardProvider.GetJobCardGeneration();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetJobCardGenerationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetJobCardGenerationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        public AddJobCardGenerationResponseDto AddJobCardGeneration(AddJobCardGenerationRequestDto addJobCardGenerationRequestDto)
        {
            AddJobCardGenerationResponseDto response = new AddJobCardGenerationResponseDto();
            try
            {
                response = bJobCardProvider.AddJobCardGeneration(addJobCardGenerationRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddJobCardGenerationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddJobCardGenerationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetJobCardMaintanceResponseDto GetJobCardMaintane()
        {
            GetJobCardMaintanceResponseDto response = new GetJobCardMaintanceResponseDto();
            try
            {
                response = rJobCardProvider.GetJobCardMaintane();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetJobCardMaintanceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetJobCardMaintanceResponseDto
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
