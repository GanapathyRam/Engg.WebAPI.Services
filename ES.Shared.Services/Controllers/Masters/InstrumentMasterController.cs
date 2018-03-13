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
    public class InstrumentMasterController : ApiController, IReportInstrumentMaster, IBusinessInstrumentMaster
    {
         private readonly IBusinessInstrumentMaster bInstrumentMasterProvider;
        private readonly IReportInstrumentMaster rInstrumentMasterProvider;

        public InstrumentMasterController()
        {
            this.bInstrumentMasterProvider = ObjectFactory.GetInstance<IBusinessInstrumentMaster>();
            this.rInstrumentMasterProvider = ObjectFactory.GetInstance<IReportInstrumentMaster>();
        }

        [HttpPost]
        public AddInstrumentMasterResponseDto AddInstrumentMaster(AddInstrumentMasterRequestDto addInstrumentMasterRequestDto)
        {
            AddInstrumentMasterResponseDto addInstrumentMasterResponseDto;

            try
            {
                addInstrumentMasterResponseDto = bInstrumentMasterProvider.AddInstrumentMaster(addInstrumentMasterRequestDto);
                addInstrumentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addInstrumentMasterResponseDto = new AddInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addInstrumentMasterResponseDto = new AddInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addInstrumentMasterResponseDto;
        }

        [HttpPost]
        public GetInstrumentMasterResponseDto GetInstrumentMaster()
        {
            GetInstrumentMasterResponseDto getInstrumentMasterResponseDto;

            try
            {
                getInstrumentMasterResponseDto = rInstrumentMasterProvider.GetInstrumentMaster();
                getInstrumentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getInstrumentMasterResponseDto = new GetInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getInstrumentMasterResponseDto = new GetInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getInstrumentMasterResponseDto;
        }

        [HttpPost]
        public UpdateInstrumentMasterResponseDto UpdateInstrumentMaster(UpdateInstrumentMasterRequestDto updateInstrumentMasterRequestDto)
        {
            UpdateInstrumentMasterResponseDto updateInstrumentMasterResponseDto;

            try
            {
                updateInstrumentMasterResponseDto = bInstrumentMasterProvider.UpdateInstrumentMaster(updateInstrumentMasterRequestDto);
                updateInstrumentMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updateInstrumentMasterResponseDto = new UpdateInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updateInstrumentMasterResponseDto = new UpdateInstrumentMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updateInstrumentMasterResponseDto;
        }
    }
}
