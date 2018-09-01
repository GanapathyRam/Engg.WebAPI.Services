using ES.Services.ReportLogic.Interface.Enquiry;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Collections.Generic;
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
        public HttpResponseMessage GetStockEnquiry()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                //response = rEnquiryProvider.GetStockEnquiry();
            }
            catch (SSException applicationException)
            {
               
            }
            catch (Exception exception)
            {
            }

            return response;
        }
    }
}
