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
    public class BusinessRateMaster : IBusinessRateMaster
    {
        private readonly IRateMasterRepository rateMasterRepository;
        public BusinessRateMaster(IRateMasterRepository rateMasterRepository)
        {
            this.rateMasterRepository = rateMasterRepository;
        }
        public AddRateMasterResponseDto AddRateMaster(AddRateMasterRequestDto addRateMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddRateMasterResponseDto();
            var cModel = new AddRateMasterCM
            {
                Discount = addRateMasterRequestDto.Discount,
                ItemCode = addRateMasterRequestDto.ItemCode,
                Rate = addRateMasterRequestDto.Rate,
                VendorCode = addRateMasterRequestDto.VendorCode,
                CreatedBy = createdBy
            };

            var response = rateMasterRepository.AddRateMaster(cModel);
            model.ItemCode = response.ItemCode;
            return model;
        }

        public DeleteRateMasterResponseDto DeleteRateMaster(DeleteRateMasterRequestDto deleteRateMasterRequestDto)
        {
            var model = new DeleteRateMasterResponseDto();
            var cModel = new DeleteRateMasterCM
            {
                ItemCode = deleteRateMasterRequestDto.ItemCode,
                VendorCode = deleteRateMasterRequestDto.VendorCode,
            };

            var response = rateMasterRepository.DeleteRateMaster(cModel);
            model.ItemCode = response.ItemCode;
            return model;
        }

        public UpdateRateMasterResponseDto UpdateRateMaster(UpdateRateMasterRequestDto updateRateMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new UpdateRateMasterResponseDto();
            var cModel = new UpdateRateMasterCM
            {
                Discount = updateRateMasterRequestDto.Discount,
                ItemCode = updateRateMasterRequestDto.ItemCode,
                Rate = updateRateMasterRequestDto.Rate,
                VendorCode = updateRateMasterRequestDto.VendorCode,
                UpdatedBy = createdBy
            };

            var response = rateMasterRepository.UpdateRateMaster(cModel);
            model.ItemCode = response.ItemCode;
            return model;
        }
    }
}
