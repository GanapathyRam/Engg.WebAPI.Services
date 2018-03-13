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
    public class ToolsMasterController : ApiController, IBusinessToolsMaster, IReportToolsMaster
    {
        private readonly IBusinessToolsMaster bToolsMasterProvider;
        private readonly IReportToolsMaster rToolsMasterProvider;

        public ToolsMasterController()
        {
            this.bToolsMasterProvider = ObjectFactory.GetInstance<IBusinessToolsMaster>();
            this.rToolsMasterProvider = ObjectFactory.GetInstance<IReportToolsMaster>();
        }

        [HttpPost]
        public AddToolsMasterResponseDto AddToolsMaster(AddToolsMasterRequestDto addToolsMasterRequestDto)
        {
            AddToolsMasterResponseDto addToolsMasterResponseDto;

            try
            {
                addToolsMasterResponseDto = bToolsMasterProvider.AddToolsMaster(addToolsMasterRequestDto);
                addToolsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addToolsMasterResponseDto = new AddToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addToolsMasterResponseDto = new AddToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addToolsMasterResponseDto;
        }

        [HttpPost]
        public GetToolsMasterResponseDto GetToolsMaster()
        {
            GetToolsMasterResponseDto getToolsMasterResponseDto;

            try
            {
                getToolsMasterResponseDto = rToolsMasterProvider.GetToolsMaster();
                getToolsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getToolsMasterResponseDto = new GetToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getToolsMasterResponseDto = new GetToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getToolsMasterResponseDto;
        }

        [HttpPost]
        public UpdateToolsMasterResponseDto UpdateToolsMaster(UpdateToolsMasterRequestDto updateToolsMasterRequestDto)
        {
            UpdateToolsMasterResponseDto updateToolsMasterResponseDto;

            try
            {
                updateToolsMasterResponseDto = bToolsMasterProvider.UpdateToolsMaster(updateToolsMasterRequestDto);
                updateToolsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateToolsMasterResponseDto = new UpdateToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateToolsMasterResponseDto = new UpdateToolsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateToolsMasterResponseDto;
        }
    }
}
