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
                    response.PoNumber = "PO" + Convert.ToString(currentYear + "0001");
                }
                else
                {
                    var poType = "SS";
                    var workOrderInc = Int32.Parse(model) + 1;
                    response.PoNumber = Convert.ToString(poType + workOrderInc);
                }
            }
            else
            {
                response.PoNumber = "PO" + Convert.ToString(currentYear + "0001");
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

        public GetRateMasterDetailsFromVendorCodeResponseDto GetRateMasterDetailsFromVendorCode(Int64 vendorCode, decimal ItemCode)
        {
            var response = new GetRateMasterDetailsFromVendorCodeResponseDto();
            var model = transactionRepository.GetRateMasterDetailsFromVendorCode(vendorCode, ItemCode);
            if (model != null)
            {
                response.Rate = model.Rate;
                response.Discount = model.Discount;
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

            foreach (var poMasterDetails in responseDto.GetPoResponseDetailsList)
            {
                var getsingle = new GetPoResponseMaster
                {
                    GetPoResponseDetailsList = new List<GetPoResponseDetails>()
                };
                var getWorkOrderMasterDetailsResponse = new GetPoResponseDetails();
                getWorkOrderMasterDetailsResponse.PONumber = poMasterDetails.PONumber;
                getWorkOrderMasterDetailsResponse.POSerial = poMasterDetails.POSerial;
                getWorkOrderMasterDetailsResponse.POAmendNumber = poMasterDetails.POAmendNumber;
                getWorkOrderMasterDetailsResponse.ItemCode = poMasterDetails.ItemCode;
                getWorkOrderMasterDetailsResponse.ItemDescription = poMasterDetails.ItemDescription;
                getWorkOrderMasterDetailsResponse.UOMCode = poMasterDetails.UOMCode;
                getWorkOrderMasterDetailsResponse.POQuantity = poMasterDetails.POQuantity;
                getWorkOrderMasterDetailsResponse.PORate = poMasterDetails.PORate;
                getWorkOrderMasterDetailsResponse.DiscountPercent = poMasterDetails.DiscountPercent;
                getWorkOrderMasterDetailsResponse.DiscountValue = poMasterDetails.DiscountValue;
                getWorkOrderMasterDetailsResponse.ItemRate = poMasterDetails.ItemRate;
                getWorkOrderMasterDetailsResponse.Amount = poMasterDetails.Amount;
                getWorkOrderMasterDetailsResponse.DeliveryDate = poMasterDetails.DeliveryDate;
                getWorkOrderMasterDetailsResponse.ReceivedQuantity = poMasterDetails.ReceivedQuantity;
                getWorkOrderMasterDetailsResponse.ShortCloseQuantity = poMasterDetails.ShortCloseQuantity;
                getWorkOrderMasterDetailsResponse.DeliveryDate = poMasterDetails.DeliveryDate;
                getWorkOrderMasterDetailsResponse.UOMDescription = poMasterDetails.UOMDescription;    

                if (response.GetPoResponseMasterList.Count > 0)
                {
                    var isExist = response.GetPoResponseMasterList.Any(PoNumber => PoNumber.PONumber == poMasterDetails.PONumber);
                    if (isExist)
                    {
                        var index = response.GetPoResponseMasterList.FindIndex(a => a.PONumber == poMasterDetails.PONumber);

                        response.GetPoResponseMasterList[index].GetPoResponseDetailsList.Add(getWorkOrderMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.PONumber = poMasterDetails.PONumber;
                        getsingle.VendorCode = poMasterDetails.VendorCode;
                        getsingle.VendorName = poMasterDetails.VendorName;
                        getsingle.POTypeCode = poMasterDetails.POTypeCode;
                        getsingle.PODate = poMasterDetails.PODate;
                        getsingle.Reference = poMasterDetails.Reference;
                        getsingle.ReferenceDate = poMasterDetails.ReferenceDate;

                        getsingle.GetPoResponseDetailsList.Add
                        (getWorkOrderMasterDetailsResponse);

                        response.GetPoResponseMasterList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.PONumber = poMasterDetails.PONumber;
                    getsingle.VendorCode = poMasterDetails.VendorCode;
                    getsingle.VendorName = poMasterDetails.VendorName;
                    getsingle.POTypeCode = poMasterDetails.POTypeCode;
                    getsingle.PODate = poMasterDetails.PODate;
                    getsingle.Reference = poMasterDetails.Reference;
                    getsingle.ReferenceDate = poMasterDetails.ReferenceDate;

                    getsingle.GetPoResponseDetailsList.Add
                    (getWorkOrderMasterDetailsResponse);

                    response.GetPoResponseMasterList.Add(getsingle);
                }
            }

            return response;
        }

        public GetPOTypeResponseDto GetPOTypeMaster()
        {
            var response = new GetPOTypeResponseDto();

            var model = transactionRepository.GetPOTypeMaster();

            if (model != null)
            {
                response = POTypeMapper((List<GetPOTypeModel>)model.GetPOTypeModelList, response);
            }

            return response;
        }

        private static GetPOTypeResponseDto POTypeMapper(List<GetPOTypeModel> list, GetPOTypeResponseDto getPOTypeResponseDto)
        {
            Mapper.CreateMap<GetPOTypeModel, POTypeList>();
            getPOTypeResponseDto.GetPOTypeList =
                Mapper.Map<List<GetPOTypeModel>, List<POTypeList>>(list);

            return getPOTypeResponseDto;
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

        public GetGRNFromVendorCodeResponseDto GetGRNDetailsFromVendorCode(long vendorCode)
        {
            throw new NotImplementedException();
        }
    }
}
