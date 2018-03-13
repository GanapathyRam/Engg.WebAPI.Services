using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class CategoryMasterController : ApiController, IReportCategoryMaster
    {
        private readonly IReportCategoryMaster rCategoryMasterProvider;

        public CategoryMasterController()
        {
            this.rCategoryMasterProvider = ObjectFactory.GetInstance<IReportCategoryMaster>();
        }
        [HttpPost]
        public GetCategoryMasterResponseDto GetCategoryMaster()
        {
            GetCategoryMasterResponseDto response;

            try
            {
                response = rCategoryMasterProvider.GetCategoryMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetCategoryMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetCategoryMasterResponseDto
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
