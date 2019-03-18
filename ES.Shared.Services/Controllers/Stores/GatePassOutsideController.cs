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
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Stores
{
    [JwtAuthenticationAttribute]
    public class GatePassOutsideController : ApiController, IBusinessGatePassOutside, IReportGPOutside
    {
        private readonly IReportGPOutside reportGatePassOutside;

        private readonly IBusinessGatePassOutside businessGatePassOutside;

        public GatePassOutsideController()
        {
            this.reportGatePassOutside = ObjectFactory.GetInstance<IReportGPOutside>();
            this.businessGatePassOutside = ObjectFactory.GetInstance<IBusinessGatePassOutside>();
        }
        [HttpPost]
        public DeleteGPOutsideReceiptResponseDto DeletPOutsideReceiptMasterAndDetails(DeleteGPOutsideReceiptRequestDto deleteGPOutsideReceiptRequestDto)
        {
            DeleteGPOutsideReceiptResponseDto response = new DeleteGPOutsideReceiptResponseDto();
            try
            {
                response = businessGatePassOutside.DeletPOutsideReceiptMasterAndDetails(deleteGPOutsideReceiptRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteGPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteGPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        [HttpPost]
        public GetGPOutsideReceiptResponseDto getGPOutsideReceipt()
        {
            GetGPOutsideReceiptResponseDto response = new GetGPOutsideReceiptResponseDto();
            try
            {
                response = reportGatePassOutside.getGPOutsideReceipt();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
        [HttpPost]
        public GetGPOutsideReceiptNumberResponseDto getGPOutsideReceiptNumber(string gpOutsideType)
        {
            GetGPOutsideReceiptNumberResponseDto getGPOutsideReceiptNumberResponseDto;
            try
            {
                getGPOutsideReceiptNumberResponseDto = reportGatePassOutside.getGPOutsideReceiptNumber(gpOutsideType);
                getGPOutsideReceiptNumberResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                getGPOutsideReceiptNumberResponseDto = new GetGPOutsideReceiptNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                getGPOutsideReceiptNumberResponseDto = new GetGPOutsideReceiptNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGPOutsideReceiptNumberResponseDto;
        }

        public GPOutsideReceiptResponseDto SaveGPOutsideReceipt(GPOutsideReceiptRequestDto gPOutsideReceiptRequestDto)
        {
            GPOutsideReceiptResponseDto gpOutsideReceiptResponseDto;
            try
            {
                gpOutsideReceiptResponseDto = businessGatePassOutside.SaveGPOutsideReceipt(gPOutsideReceiptRequestDto);
                gpOutsideReceiptResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpOutsideReceiptResponseDto = new GPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpOutsideReceiptResponseDto = new GPOutsideReceiptResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpOutsideReceiptResponseDto;
        }
    }
}
