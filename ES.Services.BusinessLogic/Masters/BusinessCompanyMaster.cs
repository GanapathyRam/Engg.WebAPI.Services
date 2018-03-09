using ES.Services.BusinessLogic.Interface.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Registration;
using ES.Services.DataTransferObjects.Response.Registration;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataTransferObjects.Request.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;

namespace ES.Services.BusinessLogic.Masters
{
    public class BusinessCompanyMaster : IBusinessCompanyMaster
    {
        private readonly ICompanyMastersRepository companyMastersRepository;

        public BusinessCompanyMaster(ICompanyMastersRepository companyMastersRepository)
        {
            this.companyMastersRepository = companyMastersRepository;
        }
        public AddCompanyMasterResponseDto AddCompanyMaster(AddCompanyMasterRequestDto request)
        {
            var registerUserResponseDto = new RegisterUserResponseDto();

            var cModel = new AddCompanyMasterCommandModel
            {
                //Cess1Percent = request.Cess1Percent,
                //Cess2Percent = request.Cess2Percent,
                //CompanyAddress1 = request.CompanyAddress1,
                //CompanyAddress2 = request.CompanyAddress2,
                //CompanyCECode = request.CompanyCECode,
                //CompanyCity = request.CompanyCity,
                //CompanyCode = request.CompanyCode,
                //CompanyCST = request.CompanyCST,
                //CompanyEmail = request.CompanyEmail,
                //CompanyFax = request.CompanyFax,
                //CompanyIECode = request.CompanyIECode,
                //CompanyName = request.CompanyName,
                //CompanyPhone = request.CompanyPhone,
                //CompanyPincode = request.CompanyPincode,
                //CompanyTIN = request.CompanyTIN,
                //CompanyTNGST = request.CompanyTNGST,
                //CompanyWeb = request.CompanyWeb,
                //CreatedBy = request.CreatedBy,
                //CreatedDateTime = request.CreatedDateTime,
                //EDPercent = request.EDPercent,
                //EPFPercent = request.EPFPercent,
                //ESILimit = request.ESILimit,
                //ESIPercent = request.ESIPercent,
                //ESIPercent_Employer = request.ESIPercent_Employer,
                //FPFPercent = request.FPFPercent,
                //PFLimit = request.PFLimit,
                //PFPercent = request.PFPercent,
                //VatPercent = request.VatPercent

            };
            var response = companyMastersRepository.AddCompanyMaster(cModel);

            return new AddCompanyMasterResponseDto();
        }

    }
}
