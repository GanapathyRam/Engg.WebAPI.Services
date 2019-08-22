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
                    var poType = "PO";
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
                responseDto = POTransactionMapper((List<GetPoResponseModel>)model.GetPoResponseModelList, responseDto);
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

        public GetGRNNumberResponseDto GetGRNNumber()
        {
            var response = new GetGRNNumberResponseDto();

            var model = transactionRepository.GetPoNumber();
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(0, 2));


                if (!savedYear.Equals(currentYear))
                {
                    response.GRNNumber = "GR" + Convert.ToString(currentYear + "0001");
                }
                else
                {
                    var poType = "GR";
                    var workOrderInc = Int32.Parse(model) + 1;
                    response.GRNNumber = Convert.ToString(poType + workOrderInc);
                }
            }
            else
            {
                response.GRNNumber = "GR" + Convert.ToString(currentYear + "0001");
            }

            return response;
        }

        public GetGRNFromVendorCodeResponseDto GetGRNDetailsFromVendorCode(long vendorCode)
        {
            var response = new GetGRNFromVendorCodeResponseDto();
            var model = transactionRepository.GetGRNDetails(vendorCode);
            if (model != null && model.GetGRNDetailsModelList.Any())
            {
                response = GetGRNDetailsFromVendorCodeMapper((List<GetGRNDetailsModel>)model.GetGRNDetailsModelList, response);
            }

            return response;
        }

        public GetGRNSupplierNameResponseDto GetGRNSupplierName()
        {
            var response = new GetGRNSupplierNameResponseDto();
            var model = transactionRepository.GetGRNSupplierName();
            if (model != null && model.GetGRNSupplierNameModelList.Any())
            {
                response = GetGRNSupplierNameMapper((List<GetGRNSupplierNameModel>)model.GetGRNSupplierNameModelList, response);
            }

            return response;
        }

        public GetGRNMasterAndDetailsResponseDto GetGRNMasterAndDetails()
        {
            var response = new GetGRNMasterAndDetailsResponseDto()
            {
                GetGRNMasterResponseList = new List<GetGRNMasterResponse>()
            };
            var responseDto = new GetGRNMasterResponse();

            var model = transactionRepository.GetGRNMasterAndDetails();

            if (model != null)
            {
                responseDto = GRNTransactionMapper((List<GetGRNMasterAndDetailsModel>)model.GetGRNMasterAndDetailsModelList, responseDto);
            }

            foreach (var GrnMasterDetails in responseDto.GetGRNDetailsResponseList)
            {
                var getsingle = new GetGRNMasterResponse
                {
                    GetGRNDetailsResponseList = new List<GetGRNDetailsResponse>()
                };
                var getGRNMasterDetailsResponse = new GetGRNDetailsResponse();

                getGRNMasterDetailsResponse.GRNNumber = GrnMasterDetails.GRNNumber;
                getGRNMasterDetailsResponse.GRNDate = GrnMasterDetails.GRNDate;                
                getGRNMasterDetailsResponse.ReceivedDate = GrnMasterDetails.ReceivedDate;
                getGRNMasterDetailsResponse.VendorCode = GrnMasterDetails.VendorCode;
                getGRNMasterDetailsResponse.VendorName = GrnMasterDetails.VendorName;
                getGRNMasterDetailsResponse.InvoiceNumber = GrnMasterDetails.InvoiceNumber;
                getGRNMasterDetailsResponse.InvoiceDate = GrnMasterDetails.InvoiceDate;
                getGRNMasterDetailsResponse.Remarks = GrnMasterDetails.Remarks;
                getGRNMasterDetailsResponse.PONumber = GrnMasterDetails.PONumber;
                getGRNMasterDetailsResponse.POSerial = GrnMasterDetails.POSerial;
                getGRNMasterDetailsResponse.GRNSerial = GrnMasterDetails.GRNSerial;
                getGRNMasterDetailsResponse.ItemCode = GrnMasterDetails.ItemCode;
                getGRNMasterDetailsResponse.ItemDescription = GrnMasterDetails.ItemDescription;
                getGRNMasterDetailsResponse.ReceivedQuantity = GrnMasterDetails.ReceivedQuantity;
                getGRNMasterDetailsResponse.StockQuantity = GrnMasterDetails.StockQuantity;
                getGRNMasterDetailsResponse.IsDeletable = GrnMasterDetails.IsDeletable;

                if (response.GetGRNMasterResponseList.Count > 0)
                {
                    var isExist = response.GetGRNMasterResponseList.Any(GRNNumber => GRNNumber.GRNNumber == GrnMasterDetails.GRNNumber);
                    if (isExist)
                    {
                        var index = response.GetGRNMasterResponseList.FindIndex(a => a.GRNNumber == GrnMasterDetails.GRNNumber);

                        response.GetGRNMasterResponseList[index].GetGRNDetailsResponseList.Add(getGRNMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.GRNNumber = GrnMasterDetails.GRNNumber;
                        getsingle.GRNDate = GrnMasterDetails.GRNDate;
                        getsingle.VendorCode = GrnMasterDetails.VendorCode;
                        getsingle.VendorName = GrnMasterDetails.VendorName;
                        getsingle.InvoiceDate = GrnMasterDetails.InvoiceDate;
                        getsingle.InvoiceNumber = GrnMasterDetails.InvoiceNumber;
                        getsingle.ReceivedDate = GrnMasterDetails.ReceivedDate;
                        getsingle.Remarks = GrnMasterDetails.Remarks;
                        getsingle.StockQuantity = GrnMasterDetails.StockQuantity;

                        getsingle.GetGRNDetailsResponseList.Add
                        (getGRNMasterDetailsResponse);

                        response.GetGRNMasterResponseList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GRNNumber = GrnMasterDetails.GRNNumber;
                    getsingle.GRNDate = GrnMasterDetails.GRNDate;
                    getsingle.VendorCode = GrnMasterDetails.VendorCode;
                    getsingle.VendorName = GrnMasterDetails.VendorName;
                    getsingle.InvoiceDate = GrnMasterDetails.InvoiceDate;
                    getsingle.InvoiceNumber = GrnMasterDetails.InvoiceNumber;
                    getsingle.ReceivedDate = GrnMasterDetails.ReceivedDate;
                    getsingle.Remarks = GrnMasterDetails.Remarks;
                    getsingle.StockQuantity = GrnMasterDetails.StockQuantity;

                    getsingle.GetGRNDetailsResponseList.Add
                    (getGRNMasterDetailsResponse);

                    response.GetGRNMasterResponseList.Add(getsingle);
                }
            }

            return response;
        }


        #region Private Method

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

        private static GetGRNFromVendorCodeResponseDto GetGRNDetailsFromVendorCodeMapper(List<GetGRNDetailsModel> list, GetGRNFromVendorCodeResponseDto getGRNFromVendorCodeResponseDto)
        {
            Mapper.CreateMap<GetGRNDetailsModel, GetGRNFromVendorCodeResponse>();
            getGRNFromVendorCodeResponseDto.GetGRNFromVendorCodeResponseList =
                Mapper.Map<List<GetGRNDetailsModel>, List<GetGRNFromVendorCodeResponse>>(list);

            return getGRNFromVendorCodeResponseDto;
        }

        private static GetGRNSupplierNameResponseDto GetGRNSupplierNameMapper(List<GetGRNSupplierNameModel> list, GetGRNSupplierNameResponseDto getGRNSupplierNameResponseDto)
        {
            Mapper.CreateMap<GetGRNSupplierNameModel, GetGRNSupplierNameResponse>();
            getGRNSupplierNameResponseDto.GetGRNSupplierNameResponseList =
                Mapper.Map<List<GetGRNSupplierNameModel>, List<GetGRNSupplierNameResponse>>(list);

            return getGRNSupplierNameResponseDto;
        }

        private static GetPoResponseMaster POTransactionMapper(List<GetPoResponseModel> list, GetPoResponseMaster getPoResponseMaster)
        {
            Mapper.CreateMap<GetPoResponseModel, GetPoResponseDetails>();
            getPoResponseMaster.GetPoResponseDetailsList =
                Mapper.Map<List<GetPoResponseModel>, List<GetPoResponseDetails>>(list);

            return getPoResponseMaster;
        }

        private static GetGRNMasterResponse GRNTransactionMapper(List<GetGRNMasterAndDetailsModel> list, GetGRNMasterResponse getGRNMasterResponse)
        {
            Mapper.CreateMap<GetGRNMasterAndDetailsModel, GetGRNDetailsResponse>();
            getGRNMasterResponse.GetGRNDetailsResponseList =
                Mapper.Map<List<GetGRNMasterAndDetailsModel>, List<GetGRNDetailsResponse>>(list);

            return getGRNMasterResponse;
        }


        #endregion
    }
}
