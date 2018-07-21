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
using System.Web.Http;


namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class SubcontractProcessMasterController : ApiController, IReportSubcontractProcessMaster, IBusinessSubcontractProcessMaster
    {
        private readonly IBusinessSubcontractProcessMaster bSubcontractProcessMasterProvider;
        private readonly IReportSubcontractProcessMaster rSubcontractProcessMasterProvider;

        public SubcontractProcessMasterController()
        {
            this.bSubcontractProcessMasterProvider = ObjectFactory.GetInstance<IBusinessSubcontractProcessMaster>();
            this.rSubcontractProcessMasterProvider = ObjectFactory.GetInstance<IReportSubcontractProcessMaster>();
        }
        [HttpPost]
        public GetSubcontractProcessMasterResponseDto GetSubcontractProcessMaster()
        {
            GetSubcontractProcessMasterResponseDto getSubcontractProcessMasterResponseDto; 

            try
            {
                getSubcontractProcessMasterResponseDto = rSubcontractProcessMasterProvider.GetSubcontractProcessMaster();
                getSubcontractProcessMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getSubcontractProcessMasterResponseDto = new GetSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getSubcontractProcessMasterResponseDto = new GetSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }
            return getSubcontractProcessMasterResponseDto;
        }
        public AddSubcontractProcessMasterResponseDto AddSubcontractProcessMaster(AddSubcontractProcessMasterRequestDto addSubcontractProcessMasterRequestDto)
        {
            AddSubcontractProcessMasterResponseDto addSubcontractProcessMasterResponseDto;
            try
            {
                addSubcontractProcessMasterResponseDto = bSubcontractProcessMasterProvider.AddSubcontractProcessMaster(addSubcontractProcessMasterRequestDto);
                addSubcontractProcessMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addSubcontractProcessMasterResponseDto = new AddSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addSubcontractProcessMasterResponseDto = new AddSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addSubcontractProcessMasterResponseDto;
        }
        public UpdateSubcontractProcessMasterResponseDto UpdateSubcontractProcessMaster(UpdateSubcontractProcessMasterRequestDto updateSubcontractProcessMasterRequestDto)
        {
            UpdateSubcontractProcessMasterResponseDto updateSubcontractProcessMasterResponseDto;

            try
            {
                updateSubcontractProcessMasterResponseDto = bSubcontractProcessMasterProvider.UpdateSubcontractProcessMaster(updateSubcontractProcessMasterRequestDto);
                updateSubcontractProcessMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateSubcontractProcessMasterResponseDto = new UpdateSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateSubcontractProcessMasterResponseDto = new UpdateSubcontractProcessMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }
            return updateSubcontractProcessMasterResponseDto;

        }
    }
}