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
    public class ReportVendorTermsMaster : IReportVendorTermsMaster
    {
        private readonly IVendorTermsMasterRepository vendorTermsMasterRepository;
        public ReportVendorTermsMaster(IVendorTermsMasterRepository vendorTermsMasterRepository)
        {
            this.vendorTermsMasterRepository = vendorTermsMasterRepository;
        }

        public GetVendorTermsMasterResponseDto GetVendorTermsMaster()
        {
            var response = new GetVendorTermsMasterResponseDto();
            var model = vendorTermsMasterRepository.GetVendorTermsMaster();
            if (model != null && model.VendorTermsMasterList.Any())
            {
                response = VendorTermsMasterMapper((List<VendorTermsMasterModel>)model.VendorTermsMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetVendorTermsMasterResponseDto VendorTermsMasterMapper(List<VendorTermsMasterModel> vendorTermsMasterList, GetVendorTermsMasterResponseDto response)
        {
            Mapper.CreateMap<VendorTermsMasterModel, VendorTermsMaster>();
            response.VendorTermsMasterList =
                Mapper.Map<List<VendorTermsMasterModel>, List<VendorTermsMaster>>(vendorTermsMasterList);

            return response;
        }
    }
}
