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
    public class ReportInventoryMaster : IReportInventoryMaster
    {
        private readonly IInventoryMasterRepository inventoryMasterRepository;
        public ReportInventoryMaster(IInventoryMasterRepository inventoryMasterRepository)
        {
            this.inventoryMasterRepository = inventoryMasterRepository;
        }
        public GetInventoryMasterResponseDto GetInventoryMaster()
        {
            var response = new GetInventoryMasterResponseDto();
            var model = inventoryMasterRepository.GetInventoryMaster();
            if (model != null && model.InventoryMasterList.Any())
            {
                response = InventoryMasterMapper((List<InventoryMasterModel>)model.InventoryMasterList, response);
                response.RecordCount = model.RecordCount;
            }

            return response;
        }

        private GetInventoryMasterResponseDto InventoryMasterMapper(List<InventoryMasterModel> inventoryMasterList, GetInventoryMasterResponseDto response)
        {
            Mapper.CreateMap<InventoryMasterModel, InventoryMaster>();
            response.InventoryMasterList =
                Mapper.Map<List<InventoryMasterModel>, List<InventoryMaster>>(inventoryMasterList);

            return response;
        }
    }
}
