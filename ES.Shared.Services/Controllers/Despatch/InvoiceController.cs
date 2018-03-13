using ES.Services.BusinessLogic.Interface.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.ReportLogic.Interface.Despatch;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Despatch
{
    [JwtAuthenticationAttribute]
    public class InvoiceController : ApiController, IReportInvoice, IBusinessInvoice
    {
        private readonly IReportInvoice rInvoiceProvider;
        private readonly IBusinessInvoice bInvoiceProvider;

        public InvoiceController()
        {
            this.rInvoiceProvider = ObjectFactory.GetInstance<IReportInvoice>();
            this.bInvoiceProvider = ObjectFactory.GetInstance<IBusinessInvoice>();
        }

        [HttpPost]
        public GetInvoiceNumberResponseDto GetInvoiceNumber(string WoType)
        {
            GetInvoiceNumberResponseDto response = new GetInvoiceNumberResponseDto();
            try
            {
                response = rInvoiceProvider.GetInvoiceNumber(WoType);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetInvoiceNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetInvoiceNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetDcNumberForInvoiceResponseDto GetDcNumberForInvoice(GetInvoiceNumberRequestDto getInvoiceNumberRequestDto)
        {
            GetDcNumberForInvoiceResponseDto response = new GetDcNumberForInvoiceResponseDto();
            try
            {
                response = rInvoiceProvider.GetDcNumberForInvoice(getInvoiceNumberRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDcNumberForInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDcNumberForInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetDcDetailsForInvoiceResponseDto GetDcDetailsForInvoice(string DcNumber)
        {
            GetDcDetailsForInvoiceResponseDto response = new GetDcDetailsForInvoiceResponseDto();
            try
            {
                response = rInvoiceProvider.GetDcDetailsForInvoice(DcNumber);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetDcDetailsForInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetDcDetailsForInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public AddInvoiceResponseDto AddInvoice(AddInvoiceRequestDto addInvoiceRequestDto)
        {
            AddInvoiceResponseDto response = new AddInvoiceResponseDto();
            try
            {
                response = bInvoiceProvider.AddInvoice(addInvoiceRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetInvoiceMasterResponseDto GetInvoiceMaster()
        {
            GetInvoiceMasterResponseDto response = new GetInvoiceMasterResponseDto();
            try
            {
                response = rInvoiceProvider.GetInvoiceMaster();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetInvoiceMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetInvoiceMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetInvoiceDetailsResponseDto GetInvoiceDetails(GetInvoiceDetailsRequestDto getInvoiceDetailsRequestDto)
        {
            GetInvoiceDetailsResponseDto response = new GetInvoiceDetailsResponseDto();
            try
            {
                response = rInvoiceProvider.GetInvoiceDetails(getInvoiceDetailsRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetInvoiceDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetInvoiceDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteInvoiceResponseDto DeleteInvoice(DeleteInvoiceRequestDto deleteInvoiceRequestDto)
        {
            var response = new DeleteInvoiceResponseDto();
            try
            {
                response = bInvoiceProvider.DeleteInvoice(deleteInvoiceRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteInvoiceResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteInvoiceResponseDto
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
