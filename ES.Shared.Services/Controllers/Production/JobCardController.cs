using ES.Services.BusinessLogic.Interface.Production;
using ES.Services.ReportLogic.Interface.Production;
using ES.Shared.Services.Filters;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Production
{
    [JwtAuthenticationAttribute]
    public class JobCardController : ApiController, IBusinessJobCard, IReportJobCard
    {
        public readonly IBusinessJobCard bJobCardProvider;
        public readonly IReportJobCard rJobCardProvider;

        public JobCardController()
        {
            this.rJobCardProvider = ObjectFactory.GetInstance<IReportJobCard>();
            this.bJobCardProvider = ObjectFactory.GetInstance<IBusinessJobCard>();
        }
    }
}
