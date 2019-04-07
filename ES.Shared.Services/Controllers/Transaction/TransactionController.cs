﻿using ES.Services.BusinessLogic.Interface.SubContract;
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

        #endregion

    }
}