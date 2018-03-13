using ES.Services.BusinessLogic.Interface.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.ReportLogic.Interface.Despatch;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Despatch
{
    [JwtAuthenticationAttribute]
    public class DeliveryChallanController : ApiController, IReportDeliveryChallan, IBusinessDeliveryChallan
    {
        private readonly IReportDeliveryChallan rDeliveryChallanProvider;
        private readonly IBusinessDeliveryChallan bDeliveryChallanProvider;

        public DeliveryChallanController()
        {
            this.rDeliveryChallanProvider = ObjectFactory.GetInstance<IReportDeliveryChallan>();
            this.bDeliveryChallanProvider = ObjectFactory.GetInstance<IBusinessDeliveryChallan>();
        }

        [HttpPost]
        public GetDcTypeResponseDto GetDCType()
        {
            GetDcTypeResponseDto response;

            try
            {
                response = rDeliveryChallanProvider.GetDCType();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDcTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDcTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetWOMasterForDcResponseDto GetWoMasterForDc(GetWOMasterForDcRequestDto getWOMasterForDcRequestDto)
        {
            GetWOMasterForDcResponseDto response;

            try
            {
                response = rDeliveryChallanProvider.GetWoMasterForDc(getWOMasterForDcRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetWOMasterForDcResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetWOMasterForDcResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetDCNumberResponseDto GetDCNumber(string WoType)
        {
            GetDCNumberResponseDto response = new GetDCNumberResponseDto();
            try
            {
                response = rDeliveryChallanProvider.GetDCNumber(WoType);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDCNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDCNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeliveryChallanResponseDto AddDeliveryChallan(DeliveryChallanRequestDto deliveryChallanRequestDto)
        {
            DeliveryChallanResponseDto response;

            try
            {
                response = bDeliveryChallanProvider.AddDeliveryChallan(deliveryChallanRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeliveryChallanResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeliveryChallanResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetDcMasterResponseDto GetDcMaster()
        {
            GetDcMasterResponseDto response = new GetDcMasterResponseDto();
            try
            {
                response = rDeliveryChallanProvider.GetDcMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDcMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDcMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteDcResponseDto DeleteDcDetails(DeleteDcRequestDto deleteDcRequestDto)
        {
            DeleteDcResponseDto response = new DeleteDcResponseDto();
            try
            {
                response = bDeliveryChallanProvider.DeleteDcDetails(deleteDcRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteDcResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteDcResponseDto
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
