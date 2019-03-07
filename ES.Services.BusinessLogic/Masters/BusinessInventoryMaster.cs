using ES.ExceptionAttributes;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessInventoryMaster : IBusinessInventoryMaster
    {
        private readonly IInventoryMasterRepository inventoryMasterRepository;
        public BusinessInventoryMaster(IInventoryMasterRepository inventoryMasterRepository)
        {
            this.inventoryMasterRepository = inventoryMasterRepository;
        }
        public AddInventoryMasterResponseDto AddInventoryMaster(AddInventoryMasterRequestDto addInventoryMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddInventoryMasterResponseDto();
            var cModel = new AddInventoryMasterCM
            {
                ItemDescription = addInventoryMasterRequestDto.ItemDescription,
                UOMCode = addInventoryMasterRequestDto.UOMCode,
                GroupCode = addInventoryMasterRequestDto.GroupCode,
                BaseRate = addInventoryMasterRequestDto.BaseRate,
                ReOrderQuantity = addInventoryMasterRequestDto.ReOrderQuantity,
                MinimumOrderQuantity = addInventoryMasterRequestDto.MinimumOrderQuantity,
                StockQuantity = addInventoryMasterRequestDto.StockQuantity,
                CreatedBy = createdBy
            };

            var response = inventoryMasterRepository.AddInventoryMaster(cModel);
            model.ItemCode = response.ItemCode;
            return model;
        }

        public UpdateInventoryMasterResponseDto UpdateInventoryMaster(UpdateInventoryMasterRequestDto updateInventoryMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new UpdateInventoryMasterResponseDto();
            var cModel = new UpdateInventoryMasterCM
            {
                ItemCode = updateInventoryMasterRequestDto.ItemCode,
                ItemDescription = updateInventoryMasterRequestDto.ItemDescription,
                UOMCode = updateInventoryMasterRequestDto.UOMCode,
                GroupCode = updateInventoryMasterRequestDto.GroupCode,
                BaseRate = updateInventoryMasterRequestDto.BaseRate,
                ReOrderQuantity = updateInventoryMasterRequestDto.ReOrderQuantity,
                MinimumOrderQuantity = updateInventoryMasterRequestDto.MinimumOrderQuantity,
                StockQuantity = updateInventoryMasterRequestDto.StockQuantity,
                UpdatedBy = createdBy
            };

            var response = inventoryMasterRepository.UpdateInventoryMaster(cModel);
            model.ItemCode = response.ItemCode;
            return model;
        }
    }
}
