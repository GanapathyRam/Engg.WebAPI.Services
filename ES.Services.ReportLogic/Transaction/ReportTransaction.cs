using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Transaction;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Transaction;
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

        public GetPoResponseDto GetPoMasterAndDetails()
        {
            var response = new GetPoResponseDto()
            {
                GetPoResponseMasterList = new List<GetPoResponseMaster>()
            };
            var responseDto = new GetPoResponseMaster();

            var model = transactionRepository.GetPoMasterAndDetails();

            if (model != null)
            {
                responseDto = TransactionMapper((List<GetPoResponseModel>)model.GetPoResponseModelList, responseDto);
            }

            foreach (var workOrderMasterDetails in responseDto.GetPoResponseDetailsList)
            {
                var getsingle = new GetPoResponseMaster
                {
                    GetPoResponseDetailsList = new List<GetPoResponseDetails>()
                };
                var getWorkOrderMasterDetailsResponse = new GetPoResponseDetails();
                getWorkOrderMasterDetailsResponse.PONumber = workOrderMasterDetails.PONumber;
                getWorkOrderMasterDetailsResponse.POSerial = workOrderMasterDetails.POSerial;
                getWorkOrderMasterDetailsResponse.POAmendNumber = workOrderMasterDetails.POAmendNumber;
                getWorkOrderMasterDetailsResponse.ItemCode = workOrderMasterDetails.ItemCode;
                getWorkOrderMasterDetailsResponse.UOMCode = workOrderMasterDetails.UOMCode;
                getWorkOrderMasterDetailsResponse.POQuantity = workOrderMasterDetails.POQuantity;
                getWorkOrderMasterDetailsResponse.PORate = workOrderMasterDetails.PORate;
                getWorkOrderMasterDetailsResponse.DiscountPercent = workOrderMasterDetails.DiscountPercent;
                getWorkOrderMasterDetailsResponse.DiscountValue = workOrderMasterDetails.DiscountValue;
                getWorkOrderMasterDetailsResponse.ItemRate = workOrderMasterDetails.ItemRate;
                getWorkOrderMasterDetailsResponse.Amount = workOrderMasterDetails.Amount;
                getWorkOrderMasterDetailsResponse.DeliveryDate = workOrderMasterDetails.DeliveryDate;
                getWorkOrderMasterDetailsResponse.ReceivedQuantity = workOrderMasterDetails.ReceivedQuantity;
                getWorkOrderMasterDetailsResponse.ShortCloseQuantity = workOrderMasterDetails.ShortCloseQuantity;

                if (response.GetPoResponseMasterList.Count > 0)
                {
                    var isExist = response.GetPoResponseMasterList.Any(PoNumber => PoNumber.PONumber == workOrderMasterDetails.PONumber);
                    if (isExist)
                    {
                        var index = response.GetPoResponseMasterList.FindIndex(a => a.PONumber == workOrderMasterDetails.PONumber);

                        response.GetPoResponseMasterList[index].GetPoResponseDetailsList.Add(getWorkOrderMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.PONumber = workOrderMasterDetails.PONumber;
                        getsingle.VendorCode = workOrderMasterDetails.VendorCode;
                        getsingle.VendorName = workOrderMasterDetails.VendorName;
                        getsingle.POTypeCode = workOrderMasterDetails.POTypeCode;
                        getsingle.PODate = workOrderMasterDetails.PODate;
                        getsingle.Reference = workOrderMasterDetails.Reference;
                        getsingle.ReferenceDate = workOrderMasterDetails.ReferenceDate;

                        getsingle.GetPoResponseDetailsList.Add
                        (getWorkOrderMasterDetailsResponse);

                        response.GetPoResponseMasterList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.PONumber = workOrderMasterDetails.PONumber;
                    getsingle.VendorCode = workOrderMasterDetails.VendorCode;
                    getsingle.VendorName = workOrderMasterDetails.VendorName;
                    getsingle.POTypeCode = workOrderMasterDetails.POTypeCode;
                    getsingle.PODate = workOrderMasterDetails.PODate;
                    getsingle.Reference = workOrderMasterDetails.Reference;
                    getsingle.ReferenceDate = workOrderMasterDetails.ReferenceDate;

                    getsingle.GetPoResponseDetailsList.Add
                    (getWorkOrderMasterDetailsResponse);

                    response.GetPoResponseMasterList.Add(getsingle);
                }
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

        private static GetPoResponseMaster TransactionMapper(List<GetPoResponseModel> list, GetPoResponseMaster getPoResponseMaster)
        {
            Mapper.CreateMap<GetPoResponseModel, GetPoResponseDetails>();
            getPoResponseMaster.GetPoResponseDetailsList =
                Mapper.Map<List<GetPoResponseModel>, List<GetPoResponseDetails>>(list);

            return getPoResponseMaster;
        }
    }
}
