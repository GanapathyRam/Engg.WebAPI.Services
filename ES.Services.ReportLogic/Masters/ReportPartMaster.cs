using ES.Services.ReportLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using AutoMapper;

namespace ES.Services.ReportLogic.Masters
{
    public class ReportPartMaster : IReportPartMaster
    {
        private readonly IPartMasterRepository partMastersRepository;

        public ReportPartMaster(IPartMasterRepository partMastersRepository)
        {
            this.partMastersRepository = partMastersRepository;
        }

        public GetPartMasterResponseDto GetPartMaster(GetPartMasterRequestDto getPartMasterRequestDto)
        {
            var response = new GetPartMasterResponseDto();

            var cModel = new GetPartMasterCM()
            {
                //PageIndex = getPartMasterRequestDto.PageIndex,
                //PageSize = getPartMasterRequestDto.PageSize,
                VendorCode = getPartMasterRequestDto.VendorCode
            };

            var model = partMastersRepository.GetPartMaster(cModel);

            if (model != null && model.PartMasterList.Any())
            {
                response = PartMasterMapper((List<PartMasterModel>)model.PartMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetPartMasterResponseDto PartMasterMapper(List<PartMasterModel> list, GetPartMasterResponseDto getPartMasterResponseDto)
        {
            Mapper.CreateMap<PartMasterModel, PartMaster>();
            getPartMasterResponseDto.PartMasterList =
                Mapper.Map<List<PartMasterModel>, List<PartMaster>>(list);

            return getPartMasterResponseDto;
        }
    }
}
