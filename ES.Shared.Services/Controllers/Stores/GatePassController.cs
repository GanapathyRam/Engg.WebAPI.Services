using ES.ExceptionAttributes;
using ES.Services.BusinessLogic.Interface.Stores;
using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using ES.Services.ReportLogic.Interface.Stores;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;


namespace ES.Shared.Services.Controllers.Stores
{
    [JwtAuthenticationAttribute]
    public class GatePassController : ApiController, IReportGatePass
    {
        private readonly IReportGatePass reportGatePass;

        private readonly IBusinessGatePass businessGatePass;

        public GatePassController()
        {
            this.reportGatePass = ObjectFactory.GetInstance<IReportGatePass>();
            this.businessGatePass = ObjectFactory.GetInstance<IBusinessGatePass>();
        }

        [HttpPost]
        public GetUnitMasterResponseDto GetUnitMaster()
        {
            GetUnitMasterResponseDto response;

            try
            {
                response = reportGatePass.GetUnitMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        [HttpPost]
        public GPTypeMasterResponseDto getGPTypeMaster()
        {
            GPTypeMasterResponseDto gpTypeMasterResponseDto;
            try
            {
                gpTypeMasterResponseDto = reportGatePass.getGPTypeMaster();
                gpTypeMasterResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpTypeMasterResponseDto = new GPTypeMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpTypeMasterResponseDto = new GPTypeMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpTypeMasterResponseDto;
        }
        [HttpPost]
        public GPSendingNumberResponseDto getGPSendingNumber(string gpType)
        {
            GPSendingNumberResponseDto gPSendingNumberResponseDto;
            try
            {
                gPSendingNumberResponseDto = reportGatePass.getGPSendingNumber(gpType);
                gPSendingNumberResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gPSendingNumberResponseDto = new GPSendingNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gPSendingNumberResponseDto = new GPSendingNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gPSendingNumberResponseDto;
        }
        [HttpPost]
        public GPReceiptNumberResponseDto getGPReceiptNumber()
        {
            GPReceiptNumberResponseDto gPReceiptNumberResponseDto;
            try
            {
                gPReceiptNumberResponseDto = reportGatePass.getGPReceiptNumber();
                gPReceiptNumberResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gPReceiptNumberResponseDto = new GPReceiptNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gPReceiptNumberResponseDto = new GPReceiptNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gPReceiptNumberResponseDto;
        }
        [HttpPost]
        public GetGPReceiptVendorResponseDto getGPReceiptVendor()
        {
            GetGPReceiptVendorResponseDto getGPReceiptVendorResponseDto;
            try
            {
                getGPReceiptVendorResponseDto = reportGatePass.getGPReceiptVendor();
                getGPReceiptVendorResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                getGPReceiptVendorResponseDto = new GetGPReceiptVendorResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                getGPReceiptVendorResponseDto = new GetGPReceiptVendorResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGPReceiptVendorResponseDto;
        }
        [HttpPost]
        public GPSendingResponseDto SaveGPSendingDetails(GPSendingRequestDto GPSendingRequestDto)
        {
            GPSendingResponseDto getGPSendingResponseDto;
            try
            {
                getGPSendingResponseDto = businessGatePass.SaveGPSendingDetails(GPSendingRequestDto);
                getGPSendingResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                getGPSendingResponseDto = new GPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                getGPSendingResponseDto = new GPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGPSendingResponseDto;
        }
        [HttpPost]
        public GetGPSendingResponseDto GetGPSendingMasterAndDetails()
        {
            GetGPSendingResponseDto response = new GetGPSendingResponseDto();
            try
            {
                response = reportGatePass.GetGPSendingMasterAndDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        [HttpPost]
        public DeleteGPSendingResponseDto DeleteGPSendingMasterAndDetails(DeleteGPSendingRequestDto deleteGPSendingRequestDto)
        {
            DeleteGPSendingResponseDto response = new DeleteGPSendingResponseDto();
            try
            {
                response = businessGatePass.DeleteGPSendingMasterAndDetails(deleteGPSendingRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteGPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteGPSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        //[HttpPost]
        public GetGPReceivingResponseDto GetGPReceivingMasterAndDetails(Int64 VendorCode)
        {
            GetGPReceivingResponseDto response = new GetGPReceivingResponseDto();
            try
            {
                response = reportGatePass.GetGPReceivingMasterAndDetails(VendorCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGPReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGPReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        [HttpPost]
        public GPReceivingResponseDto SaveGPReceivingtDetails(GPReceivingRequestDto GPReceivingRequestDto)
        {
            GPReceivingResponseDto getGPReceivingResponseDto;
            try
            {
                getGPReceivingResponseDto = businessGatePass.SaveGPReceivingtDetails(GPReceivingRequestDto);
                getGPReceivingResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                getGPReceivingResponseDto = new GPReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                getGPReceivingResponseDto = new GPReceivingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGPReceivingResponseDto;
        }

        //[HttpPost]
        public GetGPReceivedDetailsResponseDto GetGPReceivedDetails()
        {
            GetGPReceivedDetailsResponseDto response = new GetGPReceivedDetailsResponseDto();
            try
            {
                response = reportGatePass.GetGPReceivedDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGPReceivedDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGPReceivedDetailsResponseDto
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
