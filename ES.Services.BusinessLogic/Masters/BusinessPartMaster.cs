using ES.Services.BusinessLogic.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessPartMaster : IBusinessPartMaster
    {
        private readonly IPartMasterRepository partMasterRepository;

        public BusinessPartMaster(IPartMasterRepository partMasterRepository)
        {
            this.partMasterRepository = partMasterRepository;
        }

        public AddPartMasterResponseDto AddPartMaster(AddPartMasterRequestDto addPartMasterRequestDto)
        {
            var cModel = new AddPartMasterCM
            {
                Description = addPartMasterRequestDto.Description,
                DrawingNumber = addPartMasterRequestDto.DrawingNumber,
                DrawingNumberRevision = addPartMasterRequestDto.DrawingNumberRevision,
                FinishWeight = addPartMasterRequestDto.FinishWeight,
                ItemCode = addPartMasterRequestDto.ItemCode,
                MaterialCode = addPartMasterRequestDto.MaterialCode,
                RatePiece = addPartMasterRequestDto.RatePiece,
                RawWeight = addPartMasterRequestDto.RawWeight,
                VendorCode = addPartMasterRequestDto.VendorCode
            };

            var response = partMasterRepository.AddPartMaster(cModel);

            return new AddPartMasterResponseDto();
        }

        public UpdatePartMasterResponseDto UpdatePartMaster(UpdatePartMasterRequestDto updatePartMasterRequestDto)
        {
            var cModel = new UpdatePartMasterCM
            {
                Description = updatePartMasterRequestDto.Description,
                DrawingNumber = updatePartMasterRequestDto.DrawingNumber,
                DrawingNumberRevision = updatePartMasterRequestDto.DrawingNumberRevision,
                FinishWeight = updatePartMasterRequestDto.FinishWeight,
                ItemCode = updatePartMasterRequestDto.ItemCode,
                MaterialCode = updatePartMasterRequestDto.MaterialCode,
                RatePiece = updatePartMasterRequestDto.RatePiece,
                RawWeight = updatePartMasterRequestDto.RawWeight,
                VendorCode = updatePartMasterRequestDto.VendorCode,
                PartCode = updatePartMasterRequestDto.PartCode
            };

            var response = partMasterRepository.UpdatePartMaster(cModel);

            return new UpdatePartMasterResponseDto();
        }
    }
}
