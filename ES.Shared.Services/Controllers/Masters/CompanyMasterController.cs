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

namespace ES.Shared.Services.Controllers.Masters
{
    [JwtAuthenticationAttribute]
    public class CompanyMasterController : ApiController, IBusinessCompanyMaster
    {
        private readonly IBusinessCompanyMaster companyMasterProvider;

        public CompanyMasterController()
        {
            companyMasterProvider = ObjectFactory.GetInstance<IBusinessCompanyMaster>();
        }
        public AddCompanyMasterResponseDto AddCompanyMaster(AddCompanyMasterRequestDto addCompanyMasterRequestDto)
        {
            AddCompanyMasterResponseDto addCompanyMasterResponseDto;

            try
            {
                addCompanyMasterResponseDto = companyMasterProvider.AddCompanyMaster(addCompanyMasterRequestDto);
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

        public GetCompanyMasterResponseDto GetCompanyMaster(GetCompanyMasterRequestDto getCompanyMasterRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
