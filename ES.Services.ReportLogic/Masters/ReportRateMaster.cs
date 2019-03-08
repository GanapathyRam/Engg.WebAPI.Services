using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportRateMaster : IReportRateMaster
    {
        private readonly IRateMasterRepository rateMasterRepository;
        public ReportRateMaster(IRateMasterRepository rateMasterRepository)
        {
            this.rateMasterRepository = rateMasterRepository;
        }
        public GetRateMasterResponseDto GetRateMaster()
        {
             var response = new GetRateMasterResponseDto();
            var model = rateMasterRepository.GetRateMaster();
            if (model != null && model.RateMasterList.Any())
            {
                response = RateMasterMapper((List<RateMasterModel>)model.RateMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetRateMasterResponseDto RateMasterMapper(List<RateMasterModel> rateMasterList, GetRateMasterResponseDto response)
        {
            Mapper.CreateMap<RateMasterModel, RateMaster>();
            response.RateMasterList =
                Mapper.Map<List<RateMasterModel>, List<RateMaster>>(rateMasterList);

            return response;
        }
    }
}
