using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using SS.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.Services.BusinessLogic.Interface.Masters;
using StructureMap;
using ES.Shared.Services.Filters;
using ES.Services.ReportLogic.Interface.Masters;

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class CompanyMasterController : ApiController, IBusinessCompanyMaster
    {
        private readonly IBusinessCompanyMaster bcompanyMasterProvider;
        private readonly IReportCompanyMaster rcompanyMasterProvider;

        public CompanyMasterController()
        {
            bcompanyMasterProvider = ObjectFactory.GetInstance<IBusinessCompanyMaster>();
            rcompanyMasterProvider = ObjectFactory.GetInstance<IReportCompanyMaster>();
        }
        public AddCompanyMasterResponseDto AddCompanyMaster(AddCompanyMasterRequestDto addCompanyMasterRequestDto)
        {
            AddCompanyMasterResponseDto addCompanyMasterResponseDto;

            try
            {
                addCompanyMasterResponseDto = bcompanyMasterProvider.AddCompanyMaster(addCompanyMasterRequestDto);
                addCompanyMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                addCompanyMasterResponseDto = new AddCompanyMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                addCompanyMasterResponseDto = new AddCompanyMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return addCompanyMasterResponseDto;
        }

        [HttpPost]
        public GetCompanyMasterResponseDto GetCompanyMaster()
        {
            GetCompanyMasterResponseDto getCompanyMasterResponseDto;

            try
            {
                getCompanyMasterResponseDto = rcompanyMasterProvider.GetCompanyMaster();
                getCompanyMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getCompanyMasterResponseDto = new GetCompanyMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getCompanyMasterResponseDto = new GetCompanyMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getCompanyMasterResponseDto;
        }
    }
}
