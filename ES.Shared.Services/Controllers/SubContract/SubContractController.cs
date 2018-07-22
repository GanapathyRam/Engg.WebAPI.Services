using ES.Services.BusinessLogic.Interface.SubContract;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.SubContract;
using ES.Services.ReportLogic.Interface.SubContract;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.SubContract
{
    [JwtAuthenticationAttribute]
    public class SubContractController : ApiController
    {
        private readonly IReportSubContract rSubContractProvider;
        private readonly IBusinessSubContract bSubContractProvider;

        public SubContractController()
        {
            this.rSubContractProvider = ObjectFactory.GetInstance<IReportSubContract>();
            this.bSubContractProvider = ObjectFactory.GetInstance<IBusinessSubContract>();
        }

        [HttpPost]
        public GetSubContractSendingResponseDto GetSubContractSendingDetails()
        {
            GetSubContractSendingResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractSendingDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetSubContractSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetSubContractSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public SubContractResponseDto AddSubContractSending(SubContractRequestDto subContractRequestDto)
        {
            SubContractResponseDto response;

            try
            {
                response = bSubContractProvider.AddSubContractSending(subContractRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SubContractResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SubContractResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteScSendingResponseDto DeleteScSendingDetails(DeleteScSendingRequestDto deleteScSendingRequestDto)
        {
            DeleteScSendingResponseDto response = new DeleteScSendingResponseDto();
            try
            {
                response = bSubContractProvider.DeleteScSendingDetails(deleteScSendingRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteScSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetScSendingMasterResponseDto GetScSendingMaster()
        {
            GetScSendingMasterResponseDto response = new GetScSendingMasterResponseDto();
            try
            {
                response = rSubContractProvider.GetScSendingMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetScSendingMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetScSendingMasterResponseDto
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
