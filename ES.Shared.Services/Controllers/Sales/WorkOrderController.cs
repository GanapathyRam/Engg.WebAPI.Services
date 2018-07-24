using ES.Services.BusinessLogic.Interface.Sales;
using ES.Services.DataTransferObjects.Request.Sales;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataTransferObjects.Response.Sales;
using ES.Services.ReportLogic.Interface.Sales;
using ES.Shared.Services.Filters;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Sales
{
    [JwtAuthenticationAttribute]
    public class WorkOrderController : ApiController, IReportWorkOrder, IBusinessWorkOrder
    {
        private readonly IReportWorkOrder rWorkOrderProvider;
        private readonly IBusinessWorkOrder bWorkOrderProvider;
        public WorkOrderController()
        {
            this.rWorkOrderProvider = ObjectFactory.GetInstance<IReportWorkOrder>();
            this.bWorkOrderProvider = ObjectFactory.GetInstance<IBusinessWorkOrder>();
        }
        [HttpPost]
        public GetWorkOrderTypeResponseDto GetWorkOrderType()
        {
            GetWorkOrderTypeResponseDto response;

            try
            {
                response = rWorkOrderProvider.GetWorkOrderType();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetWorkOrderTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetWorkOrderTypeResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetWorkOrderNumberResponseDto GetWorkOrderNumber()
        {
            GetWorkOrderNumberResponseDto response = new GetWorkOrderNumberResponseDto();
            try
            {
                response = rWorkOrderProvider.GetWorkOrderNumber();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetWorkOrderNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetWorkOrderNumberResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetWorkOrderClientSerialNoResponseDto GetWorkOrderClientSerialNo(string shortCode)
        {
            GetWorkOrderClientSerialNoResponseDto response = new GetWorkOrderClientSerialNoResponseDto();
            try
            {
                response = rWorkOrderProvider.GetWorkOrderClientSerialNo(shortCode);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetWorkOrderClientSerialNoResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetWorkOrderClientSerialNoResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public WorkOrderResponseDto AddWorkOrder(WorkOrderRequestDto workOrderRequestDto)
        {
            WorkOrderResponseDto response = new WorkOrderResponseDto();
            try
            {
                response = bWorkOrderProvider.AddWorkOrder(workOrderRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new WorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new WorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        public UpdateWorkOrderResponseDto UpdateWorkOrder(UpdateWorkOrderRequestDto updateWorkOrderRequestDto)
        {
            UpdateWorkOrderResponseDto response = new UpdateWorkOrderResponseDto();
            try
            {
                response = bWorkOrderProvider.UpdateWorkOrder(updateWorkOrderRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new UpdateWorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new UpdateWorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DeleteWorkOrderResponseDto DeleteWorkOrder(DeleteWorkOrderRequestDto deleteWorkOrderRequestDto)
        {
            DeleteWorkOrderResponseDto response = new DeleteWorkOrderResponseDto();
            try
            {
                response = bWorkOrderProvider.DeleteWorkOrder(deleteWorkOrderRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeleteWorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeleteWorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public GetWorkOrderResponseDto GetWorkOrder()
        {
            GetWorkOrderResponseDto response = new GetWorkOrderResponseDto();
            try
            {
                response = rWorkOrderProvider.GetWorkOrder();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new GetWorkOrderResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new GetWorkOrderResponseDto
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
