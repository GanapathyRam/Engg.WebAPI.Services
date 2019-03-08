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
    public class RateMasterController : ApiController, IReportRateMaster, IBusinessRateMaster
    {
        private readonly IBusinessRateMaster bRateMasterProvider;
        private readonly IReportRateMaster rRateMasterProvider;

        public RateMasterController()
        {
            this.bRateMasterProvider = ObjectFactory.GetInstance<IBusinessRateMaster>();
            this.rRateMasterProvider = ObjectFactory.GetInstance<IReportRateMaster>();
        }
        [HttpPost]
        public AddRateMasterResponseDto AddRateMaster(AddRateMasterRequestDto addRateMasterRequestDto)
        {
            AddRateMasterResponseDto addRateMasterResponseDto;

            try
            {
                addRateMasterResponseDto = bRateMasterProvider.AddRateMaster(addRateMasterRequestDto);
                addRateMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addRateMasterResponseDto = new AddRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addRateMasterResponseDto = new AddRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addRateMasterResponseDto;
        }
        [HttpPost]
        public DeleteRateMasterResponseDto DeleteRateMaster(DeleteRateMasterRequestDto deleteRateMasterRequestDto)
        {
            DeleteRateMasterResponseDto deleteRateMasterResponseDto;

            try
            {
                deleteRateMasterResponseDto = bRateMasterProvider.DeleteRateMaster(deleteRateMasterRequestDto);
                deleteRateMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                deleteRateMasterResponseDto = new DeleteRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                deleteRateMasterResponseDto = new DeleteRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return deleteRateMasterResponseDto;
        }
        [HttpPost]
        public GetRateMasterResponseDto GetRateMaster()
        {
            GetRateMasterResponseDto gGetRateMasterResponseDto;

            try
            {
                gGetRateMasterResponseDto = rRateMasterProvider.GetRateMaster();
                gGetRateMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                gGetRateMasterResponseDto = new GetRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                gGetRateMasterResponseDto = new GetRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return gGetRateMasterResponseDto;
        }
        [HttpPost]
        public UpdateRateMasterResponseDto UpdateRateMaster(UpdateRateMasterRequestDto updateRateMasterRequestDto)
        {

            UpdateRateMasterResponseDto updateRateMasterResponseDto;

            try
            {
                updateRateMasterResponseDto = bRateMasterProvider.UpdateRateMaster(updateRateMasterRequestDto);
                updateRateMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateRateMasterResponseDto = new UpdateRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateRateMasterResponseDto = new UpdateRateMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateRateMasterResponseDto;
        }
    }
}
