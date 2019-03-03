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
    public class UnitMasterController : ApiController, IReportUnitMaster, IBusinessUnitMaster
    {
        private readonly IBusinessUnitMaster bUnitMasterProvider;
        private readonly IReportUnitMaster rUnitMasterProvider;

        public UnitMasterController()
        {
            this.bUnitMasterProvider = ObjectFactory.GetInstance<IBusinessUnitMaster>();
            this.rUnitMasterProvider = ObjectFactory.GetInstance<IReportUnitMaster>();
        }
        [HttpPost]
        public AddUnitMasterResponseDto AddUnitMaster(AddUnitMasterRequestDto addUnitMasterRequestDto)
        {
            AddUnitMasterResponseDto addUnitMasterResponseDto;

            try
            {
                addUnitMasterResponseDto = bUnitMasterProvider.AddUnitMaster(addUnitMasterRequestDto);
                addUnitMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addUnitMasterResponseDto = new AddUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addUnitMasterResponseDto = new AddUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addUnitMasterResponseDto;
        }
        [HttpPost]
        public GetUnitMasterResponseDto GetUnitMaster()
        {
            GetUnitMasterResponseDto getUnitMasterResponseDto;

            try
            {
                getUnitMasterResponseDto = rUnitMasterProvider.GetUnitMaster();
                getUnitMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getUnitMasterResponseDto = new GetUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getUnitMasterResponseDto = new GetUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getUnitMasterResponseDto;
        }
        [HttpPost]
        public UpdateUnitMasterResponseDto UpdateUnitMaster(UpdateUnitMasterRequestDto updateUnitMasterRequestDto)
        {
            UpdateUnitMasterResponseDto updateUnitMasterResponseDto;

            try
            {
                updateUnitMasterResponseDto = bUnitMasterProvider.UpdateUnitMaster(updateUnitMasterRequestDto);
                updateUnitMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateUnitMasterResponseDto = new UpdateUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateUnitMasterResponseDto = new UpdateUnitMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateUnitMasterResponseDto;
        }
    }
}
