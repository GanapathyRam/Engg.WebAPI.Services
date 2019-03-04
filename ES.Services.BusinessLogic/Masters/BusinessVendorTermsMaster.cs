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
    public class BusinessVendorTermsMaster : IBusinessVendorTermsMaster
    {
        private readonly IVendorTermsMasterRepository vendorTermsMasterRepository;
        public BusinessVendorTermsMaster(IVendorTermsMasterRepository vendorTermsMasterRepository)
        {
            this.vendorTermsMasterRepository = vendorTermsMasterRepository;
        }

        public AddVendorTermsMasterResponseDto AddVendorTermsMaster(AddVendorTermsMasterRequestDto addVendorTermsMasterRequestDto)
        {
            var createdBy = Helper.userIdToekn();
            var model = new AddVendorTermsMasterResponseDto();
            var cModel = new AddVendorTermsMasterCM
            {
                VendorCode = addVendorTermsMasterRequestDto.VendorCode,
                CGSTPercent = addVendorTermsMasterRequestDto.CGSTPercent,
                DeliveryTerms = addVendorTermsMasterRequestDto.DeliveryTerms,
                Documents = addVendorTermsMasterRequestDto.Documents,
                IGSTPercent = addVendorTermsMasterRequestDto.IGSTPercent,
                PaymentTerms = addVendorTermsMasterRequestDto.PaymentTerms,
                SGSTPercent = addVendorTermsMasterRequestDto.SGSTPercent,
                Transport = addVendorTermsMasterRequestDto.Transport,
                Remarks = addVendorTermsMasterRequestDto.Remarks,
                CreatedBy = createdBy
            };

            var response = vendorTermsMasterRepository.AddVendorTermsMaster(cModel);
            model.VendorCode = response.VendorCode;
            return model;
        }

        public DeleteVendorTermsMasterResponseDto DeleteVendorTermsMaster(DeleteVendorTermsMasterRequestDto deleteVendorTermsMasterRequestDto)
        {
            var model = new DeleteVendorTermsMasterResponseDto();
            var cModel = new DeleteVendorTermsMasterCM
            {
                VendorCode = deleteVendorTermsMasterRequestDto.VendorCode,
            };

            var response = vendorTermsMasterRepository.DeleteVendorTermsMaster(cModel);
            model.VendorCode = response.VendorCode;
            return model;
        }

        public UpdateVendorTermsMasterResponseDto UpdateVendorTermsMaster(UpdateVendorTermsMasterRequestDto updateVendorTermsMasterRequestDto)
        {
            var updatedBy = Helper.userIdToekn();
            var model = new UpdateVendorTermsMasterResponseDto();
            var cModel = new UpdateVendorTermsMasterCM
            {
                VendorCode = updateVendorTermsMasterRequestDto.VendorCode,
                CGSTPercent = updateVendorTermsMasterRequestDto.CGSTPercent,
                DeliveryTerms = updateVendorTermsMasterRequestDto.DeliveryTerms,
                Documents = updateVendorTermsMasterRequestDto.Documents,
                IGSTPercent = updateVendorTermsMasterRequestDto.IGSTPercent,
                PaymentTerms = updateVendorTermsMasterRequestDto.PaymentTerms,
                SGSTPercent = updateVendorTermsMasterRequestDto.SGSTPercent,
                Transport = updateVendorTermsMasterRequestDto.Transport,
                Remarks = updateVendorTermsMasterRequestDto.Remarks,
                UpdatedBy = updatedBy
            };

            var response = vendorTermsMasterRepository.UpdateVendorTermsMaster(cModel);
            model.VendorCode = response.VendorCode;
            return model;
        }
    }
}
