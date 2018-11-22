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

        [HttpPost]
        public GetProcessCardResponseDto GetProcessCard(string vendorCode)
        {
            GetProcessCardResponseDto response = new GetProcessCardResponseDto();
            try
            {
                response = rProcessCardProvider.GetProcessCard(vendorCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteProcessCardResponseDto DeleteProcessCard(DeleteProcessCardRequestDto deleteProcessCardRequestDto)
        {
            DeleteProcessCardResponseDto response = new DeleteProcessCardResponseDto();
            try
            {
                response = bProcessCardProvider.DeleteProcessCard(deleteProcessCardRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteProcessCardResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetProcesssCardCopyResponseDto GetProcessCardCopy()
        {
            GetProcesssCardCopyResponseDto response = new GetProcesssCardCopyResponseDto();
            try
            {
                response = rProcessCardProvider.GetProcessCardCopy();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetProcesssCardCopyResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetProcesssCardCopyResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public AddProcesssCardCopyResponseDto AddProcessCardCopy(AddProcesssCardCopyRequestDto addProcesssCardCopyRequestDto)
        {
            AddProcesssCardCopyResponseDto response = new AddProcesssCardCopyResponseDto();
            try
            {
                response = bProcessCardProvider.AddProcessCardCopy(addProcesssCardCopyRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddProcesssCardCopyResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddProcesssCardCopyResponseDto
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
