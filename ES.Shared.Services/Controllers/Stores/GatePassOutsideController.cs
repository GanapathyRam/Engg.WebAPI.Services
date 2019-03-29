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

        public GPOutsideReturnResponseDto GetGPOutsideReturn()
        {
            GPOutsideReturnResponseDto gpOutsideReturnResponseDto;
            try
            {
                gpOutsideReturnResponseDto = reportGatePassOutside.GetGPOutsideReturn();
                gpOutsideReturnResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpOutsideReturnResponseDto = new GPOutsideReturnResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpOutsideReturnResponseDto = new GPOutsideReturnResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpOutsideReturnResponseDto;
        }

        public GetGPOutsideReturnNumberResponseDto GetGPOutsideReturnNumber()
        {
            GetGPOutsideReturnNumberResponseDto getGPOutsideReturnNumberResponseDto;
            try
            {
                getGPOutsideReturnNumberResponseDto = reportGatePassOutside.GetGPOutsideReturnNumber();
                getGPOutsideReturnNumberResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                getGPOutsideReturnNumberResponseDto = new GetGPOutsideReturnNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                getGPOutsideReturnNumberResponseDto = new GetGPOutsideReturnNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGPOutsideReturnNumberResponseDto;
        }

        public GetGPOutsideReturnVendorResponseDto GetGPOutsideReturnVendorList()
        {
            GetGPOutsideReturnVendorResponseDto gpOutsideReturnVendorResponseDto;
            try
            {
                gpOutsideReturnVendorResponseDto = reportGatePassOutside.GetGPOutsideReturnVendorList();
                gpOutsideReturnVendorResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpOutsideReturnVendorResponseDto = new GetGPOutsideReturnVendorResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpOutsideReturnVendorResponseDto = new GetGPOutsideReturnVendorResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpOutsideReturnVendorResponseDto;
        }

        public GPOutsideReturnDetailsGridResponseDto GetGPReceivedDetailsGrid(Int64 VendorCode)
        {
            GPOutsideReturnDetailsGridResponseDto gpOutsideReturnDetailsGridResponseDto;
            try
            {
                gpOutsideReturnDetailsGridResponseDto = reportGatePassOutside.GetGPReceivedDetailsGrid(VendorCode);
                gpOutsideReturnDetailsGridResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpOutsideReturnDetailsGridResponseDto = new GPOutsideReturnDetailsGridResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpOutsideReturnDetailsGridResponseDto = new GPOutsideReturnDetailsGridResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpOutsideReturnDetailsGridResponseDto;
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

        public GetGPOutsideReturnResponseDto SaveGPOutsideReturn(GPOutsideReturnRequestDto gpOutsideReturnRequestDto)
        {
            GetGPOutsideReturnResponseDto gpOutsideReturnResponseDto;
            try
            {
                gpOutsideReturnResponseDto = businessGatePassOutside.SaveGPOutsideReturn(gpOutsideReturnRequestDto);
                gpOutsideReturnResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                gpOutsideReturnResponseDto = new GetGPOutsideReturnResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                gpOutsideReturnResponseDto = new GetGPOutsideReturnResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gpOutsideReturnResponseDto;
        }
    }
}
