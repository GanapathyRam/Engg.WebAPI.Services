using AutoMapper;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportMachineMaster : IReportMachineMaster
    {
         private readonly IMachineMasterRepository machineMastersRepository;

         public ReportMachineMaster(IMachineMasterRepository machineMastersRepository)
        {
            this.machineMastersRepository = machineMastersRepository;
        }

        public GetMachineMasterResponseDto GetMachineMaster()
        {
            var response = new GetMachineMasterResponseDto();

            var cModel = new GetMachineMasterCM()
            {
                //PageIndex = getMachineMasterRequestDto.PageIndex,
                //PageSize = getMachineMasterRequestDto.PageSize,
                //MachineCode = getMachineMasterRequestDto.MachineCode
            };

            var model = machineMastersRepository.GetMachineMaster();

            if (model != null && model.GetMachineMasterList.Any())
            {
                response = MachineMasterMapper((List<MachineMasterModel>)model.GetMachineMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetMachineMasterResponseDto MachineMasterMapper(List<MachineMasterModel> list, GetMachineMasterResponseDto response)
        {
             Mapper.CreateMap<MachineMasterModel, MachineMasterList>();
            response.MachineMasterList =
                Mapper.Map<List<MachineMasterModel>, List<MachineMasterList>>(list);

            return response;
        }
    }
}
