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
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "StockEnquiryOption";
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
    }
}
