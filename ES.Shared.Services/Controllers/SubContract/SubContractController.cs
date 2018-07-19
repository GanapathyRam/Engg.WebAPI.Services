using ES.Services.DataTransferObjects.Response.SubContract;
using ES.Services.ReportLogic.Interface.SubContract;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.SubContract
{
    [JwtAuthenticationAttribute]
    public class SubContractController : ApiController
    {
        private readonly IReportSubContract rSubContractProvider;
        //private readonly IBusinessDeliveryChallan bDeliveryChallanProvider;

        public SubContractController()
        {
            this.rSubContractProvider = ObjectFactory.GetInstance<IReportSubContract>();
            //this.bDeliveryChallanProvider = ObjectFactory.GetInstance<IBusinessDeliveryChallan>();
        }

        [HttpPost]
        public GetSubContractSendingResponseDto GetSubContractSendingDetails()
        {
            GetSubContractSendingResponseDto response;

            try
            {
                response = rSubContractProvider.GetSubContractSendingDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetSubContractSendingResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetSubContractSendingResponseDto
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
