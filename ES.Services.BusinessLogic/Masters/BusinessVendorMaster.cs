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
    public class BusinessVendorMaster : IBusinessVendorMaster
    {
        private readonly IVendorMasterRepository vendorMastersRepository;

        public BusinessVendorMaster(IVendorMasterRepository vendorMastersRepository)
        {
            this.vendorMastersRepository = vendorMastersRepository;
        }
        public AddVendorMasterResponseDto AddVendorMaster(AddVendorMasterRequestDto request)
        {
            var cModel = new AddVendorMasterCM
            {
                AddedDate = request.AddedDate,
                Address1 = request.Address1,
                Address2 = request.Address2,
                CategoryCode = request.CategoryCode,
                CERegisterCode = request.CERegisterCode,
                City = request.City,
                Contact1 = request.Contact1,
                Contact2 = request.Contact2,
                CreatedBy = request.CreatedBy,
                CreatedDateTime = request.CreatedDateTime,
                DCTo = request.DeliveryChallanTo,
                DeletedDate = request.DeletedDate,
                Email = request.Email,
                Fax = request.Fax,
                InvoiceTo = request.InvoiceTo,
                PaymentDays = request.PaymentDays,
                Phone = request.Phone,
                PinCode = request.PinCode,
                CompanyGST = request.CompanyGST,
                VendorCustomerCode = request.VendorCustomerCode,
                VendorName = request.VendorName,
                VendorShortName = request.VendorShortName,
                Country = request.Country,
                State = request.State
            };
            var response = vendorMastersRepository.AddVendorMaster(cModel);

            return new AddVendorMasterResponseDto { VendorCode = response.VendorCode};
        }

        public UpdateVendorMasterResponseDto UpdateVendorMaster(UpdateVendorMasterRequestDto request)
        {
            var cModel = new UpdateVendorMasterCM
            {
                AddedDate = request.AddedDate,
                Address1 = request.Address1,
                Address2 = request.Address2,
                CategoryCode = request.CategoryCode,
                CERegisterCode = request.CERegisterCode,
                City = request.City,
                Contact1 = request.Contact1,
                Contact2 = request.Contact2,
                DCTo = request.DeliveryChallanTo,
                DeletedDate = request.DeletedDate,
                Email = request.Email,
                Fax = request.Fax,
                InvoiceTo = request.InvoiceTo,
                PaymentDays = request.PaymentDays,
                Phone = request.Phone,
                PinCode = request.PinCode,
                CompanyGST = request.CompanyGST,
                UpdatedBy = request.UpdatedBy,
                UpdatedDateTime = request.UpdatedDateTime,
                VendorCustomerCode = request.VendorCustomerCode,
                VendorName = request.VendorName,
                VendorShortName = request.VendorShortName,
                VendorCode = request.VendorCode,
                Country = request.Country,
                State = request.State
            };
            vendorMastersRepository.UpdateVendorMaster(cModel);

            return new UpdateVendorMasterResponseDto();
        }
    }
}
