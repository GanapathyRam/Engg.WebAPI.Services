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
    public class EmployeeMasterController : ApiController, IReportEmployeeMaster
    {
        private readonly IReportEmployeeMaster rEmployeeMasterProvider;

        public EmployeeMasterController()
        {
            this.rEmployeeMasterProvider = ObjectFactory.GetInstance<IReportEmployeeMaster>();
        }

        [HttpPost]
        public GetEmployeeMasterResponseDto GetEmployeeMaster()
        {
            GetEmployeeMasterResponseDto response;

            try
            {
                response = rEmployeeMasterProvider.GetEmployeeMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetEmployeeMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetEmployeeMasterResponseDto
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
