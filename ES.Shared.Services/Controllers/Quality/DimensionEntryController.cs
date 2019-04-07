using ES.Services.BusinessLogic.Interface.Quality;
using ES.Services.DataTransferObjects.Request.Quality;
using ES.Services.DataTransferObjects.Response.Quality;
using ES.Services.ReportLogic.Interface.Quality;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Quality
{
    public class DimensionEntryController : ApiController
    {
        private readonly IReportDimension rReportDimensionProvider;
        private readonly IBusinessDimension bDimensionProvider;

        public DimensionEntryController()
        {
            this.rReportDimensionProvider = ObjectFactory.GetInstance<IReportDimension>();
            this.bDimensionProvider = ObjectFactory.GetInstance<IBusinessDimension>();
        }

        [HttpPost]
        public GetDimensionEntryResponseDto GetDimensionEntryReport(string SerialNo)
        {
            GetDimensionEntryResponseDto response;

            try
            {
                response = rReportDimensionProvider.GetDimensionReport(SerialNo);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDimensionEntryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDimensionEntryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        public UpdateDimensionEntryResponseDto UpdateDimensionEntry(UpdateDimensionEntryRequestDto updateDimensionEntryRequestDto)
        {
            UpdateDimensionEntryResponseDto response;

            try
            {
                response = bDimensionProvider.UpdateDimensionEntry(updateDimensionEntryRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new UpdateDimensionEntryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new UpdateDimensionEntryResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }
    }
}
