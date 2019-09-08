using ES.Services.BusinessLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using SS.Framework.Exceptions;
using StructureMap;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Shared.Services.Filters;

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class VendorMasterController : ApiController, IBusinessVendorMaster, IReportVendorMaster
    {
        private readonly IBusinessVendorMaster bVendorMasterProvider;
        private readonly IReportVendorMaster rVendorMasterProvider;

        public VendorMasterController()
        {
            this.bVendorMasterProvider = ObjectFactory.GetInstance<IBusinessVendorMaster>();
            this.rVendorMasterProvider = ObjectFactory.GetInstance<IReportVendorMaster>();
        }

        [HttpPost]
        public AddVendorMasterResponseDto AddVendorMaster(AddVendorMasterRequestDto addVendorMasterRequestDto)
        {
            AddVendorMasterResponseDto addVendorMasterResponseDto;

            try
            {
                addVendorMasterResponseDto = bVendorMasterProvider.AddVendorMaster(addVendorMasterRequestDto);
                addVendorMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addVendorMasterResponseDto = new AddVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addVendorMasterResponseDto = new AddVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addVendorMasterResponseDto;
        }

        [HttpPost]
        public UpdateVendorMasterResponseDto UpdateVendorMaster(UpdateVendorMasterRequestDto updateVendorMasterRequestDto)
        {
            UpdateVendorMasterResponseDto response;

            try
            {
                response = bVendorMasterProvider.UpdateVendorMaster(updateVendorMasterRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new UpdateVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new UpdateVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetVendorMasterResponseDto GetVendorMaster()
        {
            GetVendorMasterResponseDto response;

            try
            {
                response = rVendorMasterProvider.GetVendorMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetVendorMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetVendorMasterListResponseDto GetVendorMasterList(Char CategoryCode = '*')
        {
            GetVendorMasterListResponseDto response;

            try
            {
                response = rVendorMasterProvider.GetVendorMasterList(CategoryCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetVendorMasterListResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetVendorMasterListResponseDto
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