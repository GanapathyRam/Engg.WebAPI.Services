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
    public class OperationMasterController : ApiController, IBusinessOperationMaster, IReportOperationMaster
    {
        private readonly IBusinessOperationMaster bOperationMasterProvider;
        private readonly IReportOperationMaster rOperationMasterProvider;

        public OperationMasterController()
        {
            this.bOperationMasterProvider = ObjectFactory.GetInstance<IBusinessOperationMaster>();
            this.rOperationMasterProvider = ObjectFactory.GetInstance<IReportOperationMaster>();
        }

        [HttpPost]
        public AddOperationMasterResponseDto AddOperationMaster(AddOperationMasterRequestDto addOperationMasterRequestDto)
        {
            AddOperationMasterResponseDto addOperationMasterResponseDto;

            try
            {
                addOperationMasterResponseDto = bOperationMasterProvider.AddOperationMaster(addOperationMasterRequestDto);
                addOperationMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addOperationMasterResponseDto = new AddOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addOperationMasterResponseDto = new AddOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addOperationMasterResponseDto;
        }

        [HttpPost]
        public GetOperationMasterResponseDto GetOperationMaster()
        {
            GetOperationMasterResponseDto getOperationMasterResponseDto;

            try
            {
                getOperationMasterResponseDto = rOperationMasterProvider.GetOperationMaster();
                getOperationMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getOperationMasterResponseDto = new GetOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getOperationMasterResponseDto = new GetOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getOperationMasterResponseDto;
        }

        [HttpPost]
        public UpdateOperationMasterResponseDto UpdateOperationMaster(UpdateOperationMasterRequestDto updateOperationMasterRequestDto)
        {
            UpdateOperationMasterResponseDto updateOperationMasterResponseDto;

            try
            {
                updateOperationMasterResponseDto = bOperationMasterProvider.UpdateOperationMaster(updateOperationMasterRequestDto);
                updateOperationMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateOperationMasterResponseDto = new UpdateOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateOperationMasterResponseDto = new UpdateOperationMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateOperationMasterResponseDto;
        }
    }
}
