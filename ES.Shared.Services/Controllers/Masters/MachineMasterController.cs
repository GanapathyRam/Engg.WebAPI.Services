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
    public class MachineMasterController : ApiController, IReportMachineMaster, IBusinessMachineMaster
    {
        private readonly IReportMachineMaster rMachineMasterProvider;

        private readonly IBusinessMachineMaster bMachineMasterProvider;
 
        public MachineMasterController()
        {
            this.bMachineMasterProvider = ObjectFactory.GetInstance<IBusinessMachineMaster>();
            this.rMachineMasterProvider = ObjectFactory.GetInstance<IReportMachineMaster>();
        }

        [HttpPost]
        public AddMachineMasterResponseDto AddMachineMaster(AddMachineMasterRequestDto addMachineMasterRequestDto)
        {
            AddMachineMasterResponseDto addMachineMasterResponseDto;

            try
            {
                addMachineMasterResponseDto = bMachineMasterProvider.AddMachineMaster(addMachineMasterRequestDto);
                addMachineMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addMachineMasterResponseDto = new AddMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addMachineMasterResponseDto = new AddMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addMachineMasterResponseDto;
        }

        [HttpPost]
        public GetMachineMasterResponseDto GetMachineMaster()
        {
            GetMachineMasterResponseDto getMachineMasterResponseDto;

            try
            {
                getMachineMasterResponseDto = rMachineMasterProvider.GetMachineMaster();
                getMachineMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getMachineMasterResponseDto = new GetMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getMachineMasterResponseDto = new GetMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getMachineMasterResponseDto;
        }

        [HttpPost]
        public UpdateMachineMasterResponseDto UpdateMachineMaster(UpdateMachineMasterRequestDto updateMachieMasterRequestDto)
        {
            UpdateMachineMasterResponseDto updateMachineMasterResponseDto;

            try
            {
                updateMachineMasterResponseDto = bMachineMasterProvider.UpdateMachineMaster(updateMachieMasterRequestDto);
                updateMachineMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateMachineMasterResponseDto = new UpdateMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateMachineMasterResponseDto = new UpdateMachineMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateMachineMasterResponseDto;
        }
    }
}
