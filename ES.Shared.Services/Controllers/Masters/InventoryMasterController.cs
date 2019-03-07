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
    public class InventoryMasterController : ApiController, IReportInventoryMaster, IBusinessInventoryMaster
    {
        private readonly IBusinessInventoryMaster bInventoryMasterProvider;
        private readonly IReportInventoryMaster rInventoryMasterProvider;
        public InventoryMasterController()
        {
            this.bInventoryMasterProvider = ObjectFactory.GetInstance<IBusinessInventoryMaster>();
            this.rInventoryMasterProvider = ObjectFactory.GetInstance<IReportInventoryMaster>();
        }
        [HttpPost]
        public AddInventoryMasterResponseDto AddInventoryMaster(AddInventoryMasterRequestDto addInventoryMasterRequestDto)
        {
            AddInventoryMasterResponseDto addInventoryMasterResponseDto;

            try
            {
                addInventoryMasterResponseDto = bInventoryMasterProvider.AddInventoryMaster(addInventoryMasterRequestDto);
                addInventoryMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addInventoryMasterResponseDto = new AddInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addInventoryMasterResponseDto = new AddInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addInventoryMasterResponseDto;
        }
        [HttpPost]
        public GetInventoryMasterResponseDto GetInventoryMaster()
        {
            GetInventoryMasterResponseDto getInventoryMasterResponseDto;

            try
            {
                getInventoryMasterResponseDto = rInventoryMasterProvider.GetInventoryMaster();
                getInventoryMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getInventoryMasterResponseDto = new GetInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getInventoryMasterResponseDto = new GetInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getInventoryMasterResponseDto;
        }
        [HttpPost]
        public UpdateInventoryMasterResponseDto UpdateInventoryMaster(UpdateInventoryMasterRequestDto updateInventoryMasterRequestDto)
        {
            UpdateInventoryMasterResponseDto updateInventoryMasterResponseDto;

            try
            {
                updateInventoryMasterResponseDto = bInventoryMasterProvider.UpdateInventoryMaster(updateInventoryMasterRequestDto);
                updateInventoryMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateInventoryMasterResponseDto = new UpdateInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateInventoryMasterResponseDto = new UpdateInventoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateInventoryMasterResponseDto;
        }
    }
}
