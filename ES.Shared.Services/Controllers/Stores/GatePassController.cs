using ES.ExceptionAttributes;
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

        public GatePassController()
        {
            this.reportGatePass = ObjectFactory.GetInstance<IReportGatePass>();
           // this.businessAuthentication = ObjectFactory.GetInstance<IBusinessAuthentication>();
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
    }
}
