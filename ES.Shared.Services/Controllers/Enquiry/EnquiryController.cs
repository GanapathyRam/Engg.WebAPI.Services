using ES.Services.DataTransferObjects.Request.Enquiry;
using ES.Services.DataTransferObjects.Response.Enquiry;
using ES.Services.ReportLogic.Interface.Enquiry;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Enquiry
{
    public class EnquiryController : ApiController
    {
        private readonly IEnquiryReport rEnquiryProvider;

        public EnquiryController()
        {
            this.rEnquiryProvider = ObjectFactory.GetInstance<IEnquiryReport>();
        }

        // Report For Stock Enquiry Option
        [HttpPost]
        public HttpResponseMessage GetStockEnquiry(Int16 Option)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["StockEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetStockEnquiry(Option, filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "StockEnquiryOption.xlsx";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public StockEnquiryOptionResponseDto GetStockEnquiryForGrid(Int16 Option)
        {
            StockEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetStockEnquiryForGrid(Option);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new StockEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new StockEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public DespatchEnquiryOptionResponseDto GetDespatchEnquiryForGrid(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto)
        {
            DespatchEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetDespatchEnquiryForGrid(despatchEnquiryOptionRequestDto);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DespatchEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DespatchEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetDespacthEnquiry(DespatchEnquiryOptionRequestDto despatchEnquiryOptionRequestDto)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["DespatchEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetDespacthEnquiry(despatchEnquiryOptionRequestDto, filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DespatchEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public HttpResponseMessage GetinvoicedEnquiry()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["InvoicedEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetInvoicedEnquiry(filePath);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DespatchEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public InvoicedEnquiryOptionResponseDto GetInvoicedEnquiryForGrid()
        {
            InvoicedEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetInvoicedEnquiryForGrid();
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new InvoicedEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new InvoicedEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetSerialNoEnquiry(string SerialNo)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SerialNoEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetSerialNoEnquiry(filePath, SerialNo);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DespatchEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public SerialNoEnquiryOptionResponseDto GetSerialNoEnquiryForGrid(string SerialNo)
        {
            SerialNoEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetSerialNoEnquiryForGrid(SerialNo);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SerialNoEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SerialNoEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetDeliveryFollowUpEnquiry(DateTime FromDate)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SerialNoEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetDeliveryFollowUpEnquiry(filePath, FromDate);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DeliveryFollowUpOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public DeliveryFollowUpEnquiryOptionResponseDto GetDeliveryFollowUpEnquiryForGrid(DateTime FromDate)
        {
            DeliveryFollowUpEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetDeliveryFollowUpEnquiryForGrid(FromDate);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new DeliveryFollowUpEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new DeliveryFollowUpEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetSalesEnquiry(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            var filePath = System.Configuration.ConfigurationManager.AppSettings["SerialNoEnquiryOption"].ToString();

            try
            {
                rEnquiryProvider.GetSalesEnquiry(filePath, FromDate, ToDate, WorkOrdeType, Option, Type);

                var dataBytes = File.ReadAllBytes(filePath);
                //adding bytes to memory stream   
                var dataStream = new MemoryStream(dataBytes);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "SalesEnquiryOption";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return httpResponseMessage;
            }
            catch (SSException applicationException)
            {
            }
            catch (Exception exception)
            {
            }

            return httpResponseMessage;
        }

        [HttpPost]
        public SalesEnquiryOptionResponseDto GetSalesEnquiryForGrid(DateTime FromDate, DateTime ToDate, Int16 WorkOrdeType, Int16 Option, string Type)
        {
            SalesEnquiryOptionResponseDto response;

            try
            {
                response = rEnquiryProvider.GetSalesEnquiryForGrid(FromDate, ToDate, WorkOrdeType, Option, Type);
                response.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                response = new SalesEnquiryOptionResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                response = new SalesEnquiryOptionResponseDto
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
