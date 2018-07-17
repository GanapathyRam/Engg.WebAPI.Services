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
    public class ReportVendorMaster : IReportVendorMaster
    {
        private readonly IVendorMasterRepository vendorMastersRepository;

        public ReportVendorMaster(IVendorMasterRepository vendorMastersRepository)
        {
            this.vendorMastersRepository = vendorMastersRepository;
        }
        public GetVendorMasterResponseDto GetVendorMaster()
        {
            var response = new GetVendorMasterResponseDto();
            //var cModel = new GetVendorMasterCM
            //{
            //    PageIndex = getVendorMasterRequestDto.PageIndex,
            //    PageSize = getVendorMasterRequestDto.PageSize,
            //    UserId = getVendorMasterRequestDto.UserId
            //};

            var model = vendorMastersRepository.GetVendorMaster();

            if (model != null && model.VendorMasterList.Any())
            {
                response = VendorMasterMapper((List<VendorMasterModel>)model.VendorMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        public GetVendorMasterListResponseDto GetVendorMasterList(Char CategoryCode)
        {
            var response = new GetVendorMasterListResponseDto();

            //var cModel = new GetVendorMasterListCM
            //{
            //    PageIndex = getVendorMasterListRequestDto.PageIndex,
            //    PageSize = getVendorMasterListRequestDto.PageSize
            //};
            var model = vendorMastersRepository.GetVendorMasterList(CategoryCode);

            if (model != null)
            {
                response = VendorMasterListMapper((List<VendorMasterList>)model.VendorMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private static GetVendorMasterListResponseDto VendorMasterListMapper(List<VendorMasterList> list, GetVendorMasterListResponseDto getVendorMasterListResponseDto)
        {
            Mapper.CreateMap<VendorMasterList, VendorMasterListForDropDown>();
            getVendorMasterListResponseDto.VendorMasterList =
                Mapper.Map<List<VendorMasterList>, List<VendorMasterListForDropDown>>(list);

            return getVendorMasterListResponseDto;
        }

        private static GetVendorMasterResponseDto VendorMasterMapper(List<VendorMasterModel> list, GetVendorMasterResponseDto getVendorMasterResponseDto)
        {
            Mapper.CreateMap<VendorMasterModel, VendorMaster>();
            getVendorMasterResponseDto.VendorMasterList =
                Mapper.Map<List<VendorMasterModel>, List<VendorMaster>>(list);

            return getVendorMasterResponseDto;
        }
    }
}
