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
    public class PartMasterController : ApiController, IBusinessPartMaster, IReportPartMaster
    {
        private readonly IBusinessPartMaster bPartMasterProvider;
        private readonly IReportPartMaster rPartMasterProvider;

        public PartMasterController()
        {
            this.bPartMasterProvider = ObjectFactory.GetInstance<IBusinessPartMaster>();
            this.rPartMasterProvider = ObjectFactory.GetInstance<IReportPartMaster>();
        }

        [HttpPost]
        public AddPartMasterResponseDto AddPartMaster(AddPartMasterRequestDto addPartMasterRequestDto)
        {
            AddPartMasterResponseDto addPartMasterResponseDto;

            try
            {
                addPartMasterResponseDto = bPartMasterProvider.AddPartMaster(addPartMasterRequestDto);
                addPartMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addPartMasterResponseDto = new AddPartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addPartMasterResponseDto = new AddPartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addPartMasterResponseDto;
        }

        [HttpPost]
        public GetPartMasterResponseDto GetPartMaster(GetPartMasterRequestDto getPartMasterRequestDto)
        {
            GetPartMasterResponseDto getPartMasterResponseDto;

            try
            {
                getPartMasterResponseDto = rPartMasterProvider.GetPartMaster(getPartMasterRequestDto);
                getPartMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getPartMasterResponseDto = new GetPartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getPartMasterResponseDto = new GetPartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getPartMasterResponseDto;
        }

        [HttpPost]
        public UpdatePartMasterResponseDto UpdatePartMaster(UpdatePartMasterRequestDto updatePartMasterRequestDto)
        {
            UpdatePartMasterResponseDto updatePartMasterResponseDto;

            try
            {
                updatePartMasterResponseDto = bPartMasterProvider.UpdatePartMaster(updatePartMasterRequestDto);
                updatePartMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                updatePartMasterResponseDto = new UpdatePartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                updatePartMasterResponseDto = new UpdatePartMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return updatePartMasterResponseDto;
        }
    }
}
