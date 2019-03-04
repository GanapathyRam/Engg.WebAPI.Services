using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class VendorTermsMasterController : ApiController, IBusinessVendorTermsMaster, IReportVendorTermsMaster
    {
        private readonly IBusinessVendorTermsMaster bVendorTermsMasterProvider;
        private readonly IReportVendorTermsMaster rVendorTermsMasterProvider;
     
        public VendorTermsMasterController()
        {
            this.bVendorTermsMasterProvider = ObjectFactory.GetInstance<IBusinessVendorTermsMaster>();
            this.rVendorTermsMasterProvider = ObjectFactory.GetInstance<IReportVendorTermsMaster>();
        }
        [HttpPost]
        public AddVendorTermsMasterResponseDto AddVendorTermsMaster(AddVendorTermsMasterRequestDto addVendorTermsMasterRequestDto)
        {
            AddVendorTermsMasterResponseDto addVendorTermsMasterResponseDto;

            try
            {
                addVendorTermsMasterResponseDto = bVendorTermsMasterProvider.AddVendorTermsMaster(addVendorTermsMasterRequestDto);
                addVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addVendorTermsMasterResponseDto = new AddVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addVendorTermsMasterResponseDto = new AddVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addVendorTermsMasterResponseDto;
        }
        [HttpPost]
        public DeleteVendorTermsMasterResponseDto DeleteVendorTermsMaster(DeleteVendorTermsMasterRequestDto deleteVendorTermsMasterRequestDto)
        {
            DeleteVendorTermsMasterResponseDto deleteVendorTermsMasterResponseDto;

            try
            {
                deleteVendorTermsMasterResponseDto = bVendorTermsMasterProvider.DeleteVendorTermsMaster(deleteVendorTermsMasterRequestDto);
                deleteVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                deleteVendorTermsMasterResponseDto = new DeleteVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                deleteVendorTermsMasterResponseDto = new DeleteVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return deleteVendorTermsMasterResponseDto;
        }
        [HttpPost]
        public GetVendorTermsMasterResponseDto GetVendorTermsMaster()
        {
            GetVendorTermsMasterResponseDto getVendorTermsMasterResponseDto;

            try
            {
                getVendorTermsMasterResponseDto = rVendorTermsMasterProvider.GetVendorTermsMaster();
                getVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getVendorTermsMasterResponseDto = new GetVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getVendorTermsMasterResponseDto = new GetVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getVendorTermsMasterResponseDto;
        }
        [HttpPost]
        public UpdateVendorTermsMasterResponseDto UpdateVendorTermsMaster(UpdateVendorTermsMasterRequestDto updateVendorTermsMasterRequestDto)
        {
            UpdateVendorTermsMasterResponseDto updateVendorTermsMasterResponseDto;

            try
            {
                updateVendorTermsMasterResponseDto = bVendorTermsMasterProvider.UpdateVendorTermsMaster(updateVendorTermsMasterRequestDto);
                updateVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateVendorTermsMasterResponseDto = new UpdateVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateVendorTermsMasterResponseDto = new UpdateVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateVendorTermsMasterResponseDto;
        }
    }
}
