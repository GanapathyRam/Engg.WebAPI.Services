using ES.Services.BusinessLogic.Interface.SubContract;
using ES.Services.BusinessLogic.Interface.Transaction;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Request.Transaction;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataTransferObjects.Response.SubContract;
using ES.Services.DataTransferObjects.Response.Transaction;
using ES.Services.ReportLogic.Interface.SubContract;
using ES.Services.ReportLogic.Interface.Transaction;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.SubContract
{
    [JwtAuthenticationAttribute]
    public class TransactionController : ApiController
    {
        private readonly IReportTransaction rTransactionProvider;
        private readonly IBusinessTransaction bTransactionProvider;

        public TransactionController()
        {
            this.rTransactionProvider = ObjectFactory.GetInstance<IReportTransaction>();
            this.bTransactionProvider = ObjectFactory.GetInstance<IBusinessTransaction>();
        }

        #region Purchase Order Master

        [HttpPost]
        public GetPoNumberResponseDto GetPoNumber()
        {
            GetPoNumberResponseDto response = new GetPoNumberResponseDto();
            try
            {
                response = rTransactionProvider.GetPoNumber();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetPoNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetPoNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetVendorTermsMasterResponseDto GetVendorTermMaster(Int64 VendorCode)
        {
            GetVendorTermsMasterResponseDto getVendorTermsMasterResponseDto;

            try
            {
                getVendorTermsMasterResponseDto = rTransactionProvider.GetVendorTermsMaster(VendorCode);
                getVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getVendorTermsMasterResponseDto = new GetVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getVendorTermsMasterResponseDto = new GetVendorTermsMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getVendorTermsMasterResponseDto;
        }

        [HttpPost]
        public POResponseDto AddPurchaseOrder(PORequestDto PoRequestDto)
        {
            POResponseDto response;

            try
            {
                response = bTransactionProvider.AddPurchaseOrder(PoRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new POResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new POResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public POResponseDto UpdatePurchaseOrder(UpdatePORequestDto UpdatePORequestDto)
        {
            POResponseDto response;

            try
            {
                response = bTransactionProvider.UpdatePurchaseOrder(UpdatePORequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new POResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new POResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeletePOResponseDto DeletePurchaseOrder(DeletePORequestDto DeletePORequestDto)
        {
            DeletePOResponseDto response;

            try
            {
                response = bTransactionProvider.DeletePurchaseOrder(DeletePORequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeletePOResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeletePOResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetRateMasterDetailsFromVendorCodeResponseDto GetRateMasterDetailsFromVendorCode(Int64 VendorCode, decimal ItemCode)
        {
            GetRateMasterDetailsFromVendorCodeResponseDto getVendorTermsMasterResponseDto;

            try
            {
                getVendorTermsMasterResponseDto = rTransactionProvider.GetRateMasterDetailsFromVendorCode(VendorCode, ItemCode);
                getVendorTermsMasterResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getVendorTermsMasterResponseDto = new GetRateMasterDetailsFromVendorCodeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getVendorTermsMasterResponseDto = new GetRateMasterDetailsFromVendorCodeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getVendorTermsMasterResponseDto;
        }

        [HttpGet]
        public GetPoResponseDto GetPoMasterAndDetails()
        {
            GetPoResponseDto getPoResponseDto;

            try
            {
                getPoResponseDto = rTransactionProvider.GetPoMasterAndDetails();
                getPoResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getPoResponseDto = new GetPoResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getPoResponseDto = new GetPoResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getPoResponseDto;
        }

        [HttpGet]
        public GetPOTypeResponseDto GetPOTypeMaster()
        {
            GetPOTypeResponseDto getPoResponseDto;

            try
            {
                getPoResponseDto = rTransactionProvider.GetPOTypeMaster();
                getPoResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getPoResponseDto = new GetPOTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getPoResponseDto = new GetPOTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getPoResponseDto;
        }

        #endregion

        #region GRN
        [HttpGet]
        public GetGRNNumberResponseDto GetGRNNumber()
        {
            GetGRNNumberResponseDto response = new GetGRNNumberResponseDto();
            try
            {
                response = rTransactionProvider.GetGRNNumber();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGRNNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGRNNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetGRNFromVendorCodeResponseDto GetGRNDetailsFromVendorCode(Int64 VendorCode)
        {
            GetGRNFromVendorCodeResponseDto response = new GetGRNFromVendorCodeResponseDto();
            try
            {
                response = rTransactionProvider.GetGRNDetailsFromVendorCode(VendorCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGRNFromVendorCodeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGRNFromVendorCodeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpGet]
        public GetGRNSupplierNameResponseDto GetGRNSupplierName()
        {
            GetGRNSupplierNameResponseDto response = new GetGRNSupplierNameResponseDto();
            try
            {
                response = rTransactionProvider.GetGRNSupplierName();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetGRNSupplierNameResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetGRNSupplierNameResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public AddGRNMasterResponseDto AddGRNMasterAndDetails(AddGRNMasterRequestDto addGRNMasterRequestDto)
        {
            AddGRNMasterResponseDto response = new AddGRNMasterResponseDto();
            try
            {
                response = bTransactionProvider.AddGRNMasterAndDetails(addGRNMasterRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddGRNMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddGRNMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public UpdateGRNMasterResponseDto UpdateGRNMasterAndDetails(UpdateGRNMasterRequestDto updateGRNMasterRequestDto)
        {
            UpdateGRNMasterResponseDto response = new UpdateGRNMasterResponseDto();
            try
            {
                response = bTransactionProvider.UpdateGRNMasterAndDetails(updateGRNMasterRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new UpdateGRNMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new UpdateGRNMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpGet]
        public GetGRNMasterAndDetailsResponseDto GetGRNMasterAndDetails()
        {
            GetGRNMasterAndDetailsResponseDto getGrnResponseDto;

            try
            {
                getGrnResponseDto = rTransactionProvider.GetGRNMasterAndDetails();
                getGrnResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getGrnResponseDto = new GetGRNMasterAndDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getGrnResponseDto = new GetGRNMasterAndDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGrnResponseDto;
        }

        [HttpPost]
        public DeleteGRNResponseDto DeleteGRNMasterAndDetails(DeleteGRNRequestDto DeleteGRNRequestDto)
        {
            DeleteGRNResponseDto response;

            try
            {
                response = bTransactionProvider.DeleteGRNMasterAndDetails(DeleteGRNRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteGRNResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteGRNResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        #endregion

        #region Issues

        [HttpGet]
        public GetIssuesNumberResponseDto GetIssueNumber()
        {
            GetIssuesNumberResponseDto response = new GetIssuesNumberResponseDto();
            try
            {
                response = rTransactionProvider.GetIssuesNumber();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetIssuesNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetIssuesNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpGet]
        public GetIssueDetailsResponseDto GetIssueDetails()
        {
            GetIssueDetailsResponseDto response = new GetIssueDetailsResponseDto();
            try
            {
                response = rTransactionProvider.GetIssueDetails();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetIssueDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetIssueDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public AddIssueMasterResponseDto AddIssueMasterAndDetails(AddIssueMasterRequestDto addIssueMasterRequestDto)
        {
            AddIssueMasterResponseDto response = new AddIssueMasterResponseDto();

            try
            {
                response = bTransactionProvider.AddIssueMasterAndDetails(addIssueMasterRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new AddIssueMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new AddIssueMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public UpdateIssueMasterResponseDto UpdateIssueMasterAndDetails(UpdateIssueMasterRequestDto updateIssueMasterRequestDto)
        {
            UpdateIssueMasterResponseDto response = new UpdateIssueMasterResponseDto();
            try
            {
                response = bTransactionProvider.UpdateIssueMasterAndDetails(updateIssueMasterRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new UpdateIssueMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new UpdateIssueMasterResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpGet]
        public GetSavedIssueMasterAndDetailsResponseDto GetSavedIssueMasterAndDetails()
        {
            GetSavedIssueMasterAndDetailsResponseDto getGrnResponseDto;

            try
            {
                getGrnResponseDto = rTransactionProvider.GetSavedIssueMasterAndDetails();
                getGrnResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                getGrnResponseDto = new GetSavedIssueMasterAndDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                getGrnResponseDto = new GetSavedIssueMasterAndDetailsResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return getGrnResponseDto;
        }

        #endregion 

    }
}
