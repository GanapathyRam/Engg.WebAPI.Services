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
    public class JigsMasterController : ApiController, IBusinessJigsMaster, IReportJigsMaster
    {
        private readonly IBusinessJigsMaster bJigsMasterProvider;
        private readonly IReportJigsMaster rJigsMasterProvider;

        public JigsMasterController()
        {
            this.bJigsMasterProvider = ObjectFactory.GetInstance<IBusinessJigsMaster>();
            this.rJigsMasterProvider = ObjectFactory.GetInstance<IReportJigsMaster>();
        }

        [HttpPost]
        public AddJigsMasterResponseDto AddJigsMaster(AddJigsMasterRequestDto addJigsMasterRequestDto)
        {
            AddJigsMasterResponseDto addJigsMasterResponseDto;

            try
            {
                addJigsMasterResponseDto = bJigsMasterProvider.AddJigsMaster(addJigsMasterRequestDto);
                addJigsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addJigsMasterResponseDto = new AddJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addJigsMasterResponseDto = new AddJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addJigsMasterResponseDto;
        }

        [HttpPost]
        public GetJigsMasterResponseDto GetJigsMaster()
        {
            GetJigsMasterResponseDto getJigsMasterResponseDto;

            try
            {
                getJigsMasterResponseDto = rJigsMasterProvider.GetJigsMaster();
                getJigsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getJigsMasterResponseDto = new GetJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getJigsMasterResponseDto = new GetJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getJigsMasterResponseDto;
        }

        [HttpPost]
        public UpdateJigsMasterResponseDto UpdateJigsMaster(UpdateJigsMasterRequestDto updateJigsMasterRequestDto)
        {
            UpdateJigsMasterResponseDto updateJigsMasterResponseDto;

            try
            {
                updateJigsMasterResponseDto = bJigsMasterProvider.UpdateJigsMaster(updateJigsMasterRequestDto);
                updateJigsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateJigsMasterResponseDto = new UpdateJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateJigsMasterResponseDto = new UpdateJigsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateJigsMasterResponseDto;
        }
    }
}
