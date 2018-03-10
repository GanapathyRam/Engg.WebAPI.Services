using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response;
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
    public class SymbolMasterController : ApiController, IReportSymbolMaster
    {
        private readonly IReportSymbolMaster rSymbolMasterProvider;
        public SymbolMasterController()
        {
           // this.bParameterMasterProvider = ObjectFactory.GetInstance<IBusinessParameterMaster>();
            this.rSymbolMasterProvider = ObjectFactory.GetInstance<IReportSymbolMaster>();
        }
        [HttpPost]
        public GetSymbolMasterResponseDto GetSymbolMaster()
        {
            GetSymbolMasterResponseDto getSymbolMasterResponseDto;
            try
            {
                getSymbolMasterResponseDto = rSymbolMasterProvider.GetSymbolMaster();
                getSymbolMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getSymbolMasterResponseDto = new GetSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getSymbolMasterResponseDto = new GetSymbolMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getSymbolMasterResponseDto;
        }

        [HttpPost]
        public AddSymbolMasterResponseDto AddSymbolMaster()
        {
            AddSymbolMasterResponseDto addSymbolMasterResponseDto;


            return addSymbolMasterResponseDto;
        }

    }
}