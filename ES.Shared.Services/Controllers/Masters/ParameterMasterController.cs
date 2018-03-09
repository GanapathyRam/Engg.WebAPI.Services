using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
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
    public class ParameterMasterController : ApiController, IBusinessParameterMaster, IReportParameterMaster
    {
        private readonly IBusinessParameterMaster bParameterMasterProvider;
        private readonly IReportParameterMaster rParameterMasterProvider;

        public ParameterMasterController()
        {
            this.bParameterMasterProvider = ObjectFactory.GetInstance<IBusinessParameterMaster>();
            this.rParameterMasterProvider = ObjectFactory.GetInstance<IReportParameterMaster>();
        }

        [HttpPost]
        public AddParameterMasterResponseDto AddParameterMaster(AddParameterMasterRequestDto addParameterMasterRequestDto)
        {
            AddParameterMasterResponseDto addParameterMasterResponseDto;

            try
            {
                addParameterMasterResponseDto = bParameterMasterProvider.AddParameterMaster(addParameterMasterRequestDto);
                addParameterMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addParameterMasterResponseDto = new AddParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addParameterMasterResponseDto = new AddParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addParameterMasterResponseDto;
        }

        [HttpPost]
        public GetParameterMasterResponseDto GetParameterMaster()
        {
            GetParameterMasterResponseDto getParameterMasterResponseDto;

            try
            {
                getParameterMasterResponseDto = rParameterMasterProvider.GetParameterMaster();
                getParameterMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getParameterMasterResponseDto = new GetParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getParameterMasterResponseDto = new GetParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getParameterMasterResponseDto;
        }

        [HttpPost]
        public UpdateParameterMasterResponseDto UpdateParameterMaster(UpdateParameterMasterRequestDto updateParameterMasterRequestDto)
        {
            UpdateParameterMasterResponseDto updateParameterMasterResponseDto;

            try
            {
                updateParameterMasterResponseDto = bParameterMasterProvider.UpdateParameterMaster(updateParameterMasterRequestDto);
                updateParameterMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateParameterMasterResponseDto = new UpdateParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateParameterMasterResponseDto = new UpdateParameterMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateParameterMasterResponseDto;
        }
    }
}
