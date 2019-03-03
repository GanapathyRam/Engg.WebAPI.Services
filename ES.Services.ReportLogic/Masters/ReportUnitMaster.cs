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
    public class ReportUnitMaster : IReportUnitMaster
    {
        private readonly IUnitMasterRepository unitMasterRepository;
        public ReportUnitMaster(IUnitMasterRepository unitMasterRepository)
        {
            this.unitMasterRepository = unitMasterRepository;
        }
        public GetUnitMasterResponseDto GetUnitMaster()
        {
            var response = new GetUnitMasterResponseDto();
            var model = unitMasterRepository.GetUnitMaster();
            if (model != null && model.UnitMasterList.Any())
            {
                response = UnitMasterMapper((List<UnitMasterModel>)model.UnitMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetUnitMasterResponseDto UnitMasterMapper(List<UnitMasterModel> unitMasterList, GetUnitMasterResponseDto response)
        {
            Mapper.CreateMap<UnitMasterModel, UnitMaster>();
            response.UnitMasterList =
                Mapper.Map<List<UnitMasterModel>, List<UnitMaster>>(unitMasterList);

            return response;
        }
    }
}
