using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Transaction;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataTransferObjects.Response.Transaction;
using ES.Services.ReportLogic.Interface.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Transaction
{
    public class ReportTransaction : IReportTransaction
    {
        private readonly ITransactionRepository transactionRepository;

        public ReportTransaction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public GetPoNumberResponseDto GetPoNumber()
        {
            var response = new GetPoNumberResponseDto();

            var model = transactionRepository.GetPoNumber();
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(0, 2));


                if (!savedYear.Equals(currentYear))
                {
                    response.PoNumber = Convert.ToString(currentYear + "0001");
                }
                else
                {
                    var workOrderInc = Int32.Parse(model) + 1;
                    response.PoNumber = Convert.ToString(workOrderInc);
                }
            }
            else
            {
                response.PoNumber = Convert.ToString(currentYear + "0001");
            }

            return response;
        }

        public GetVendorTermsMasterResponseDto GetVendorTermsMaster(Int64 VendorCode)
        {
            var response = new GetVendorTermsMasterResponseDto();
            var model = transactionRepository.GetVendorTermsMaster(VendorCode);
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
