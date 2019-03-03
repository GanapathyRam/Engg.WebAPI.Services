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
    public class DepartmentMasterController : ApiController, IBusinessDepartmentMaster, IReportDepartmentMaster
    {
        private readonly IBusinessDepartmentMaster bDepartmentMasterProvider;
        private readonly IReportDepartmentMaster rDepartmentMasterProvider;

        public DepartmentMasterController()
        {
            this.bDepartmentMasterProvider = ObjectFactory.GetInstance<IBusinessDepartmentMaster>();
            this.rDepartmentMasterProvider = ObjectFactory.GetInstance<IReportDepartmentMaster>();
        }
        [HttpPost]
        public AddDepartmentMasterResponseDto AddDepartmentMaster(AddDepartmentMasterRequestDto addDepartmentMasterRequestDto)
        {
            AddDepartmentMasterResponseDto addDepartmentMasterResponseDto;

            try
            {
                addDepartmentMasterResponseDto = bDepartmentMasterProvider.AddDepartmentMaster(addDepartmentMasterRequestDto);
                addDepartmentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addDepartmentMasterResponseDto = new AddDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addDepartmentMasterResponseDto = new AddDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addDepartmentMasterResponseDto;
        }
        [HttpPost]
        public GetDepartmentMasterResponseDto GetDepartmentMaster()
        {
            GetDepartmentMasterResponseDto getDepartmentMasterResponseDto;

            try
            {
                getDepartmentMasterResponseDto = rDepartmentMasterProvider.GetDepartmentMaster();
                getDepartmentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getDepartmentMasterResponseDto = new GetDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getDepartmentMasterResponseDto = new GetDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getDepartmentMasterResponseDto;
        }
        [HttpPost]
        public UpdateDepartmentMasterResponseDto UpdateDepartmentMaster(UpdateDepartmentMasterRequestDto updateDepartmentMasterRequestDto)
        {
            UpdateDepartmentMasterResponseDto updateDepartmentMasterResponseDto;

            try
            {
                updateDepartmentMasterResponseDto = bDepartmentMasterProvider.UpdateDepartmentMaster(updateDepartmentMasterRequestDto);
                updateDepartmentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateDepartmentMasterResponseDto = new UpdateDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateDepartmentMasterResponseDto = new UpdateDepartmentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateDepartmentMasterResponseDto;
        }
    }
}
