using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using ES.Services.ReportLogic.Interface.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ES.Services.DataTransferObjects.Response.Stores.GPTypeMasterResponseDto;

namespace ES.Services.ReportLogic.Stores
{
    public class ReportGatePass : IReportGatePass
    {
        private readonly IGatePassRepository gatePassRepository;

        public ReportGatePass(IGatePassRepository gatePassRepository)
        {
            this.gatePassRepository = gatePassRepository;
        }
        #region Sending

        public GetUnitMasterResponseDto GetUnitMaster()
        {
            var response = new GetUnitMasterResponseDto();
            var model = gatePassRepository.GetUnitMaster();
            if (model != null)
            {
                response = GPUnitMasterMapper((List<GetUnitMasterQMList>)model.GetUnitMasterQMList, response);
            }

            return response;
        }

        public GPTypeMasterResponseDto getGPTypeMaster()
        {
            var response = new GPTypeMasterResponseDto();
            var model = gatePassRepository.getGPTypeMaster();
            if (model != null)
            {
                response = GPTypeMasterMapper((List<GPTypeMasterResponseModel>)model.gpTypeList, response);
            }

            return response;
        }

        public GPSendingNumberResponseDto getGPSendingNumber(string gpType)
        {
            var response = new GPSendingNumberResponseDto();
            var model = gatePassRepository.getGPSendingNumber(gpType);
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(1, 2));
                if (!savedYear.Equals(currentYear))
                {
                    response.GPNumber = "G" + Convert.ToString(currentYear + "I" + gpType + "0001");
                }
                else
                {
                    var gpnumbernc = (Int32.Parse(model.ToString().Substring(model.ToString().Length - 4)) + 1).ToString().PadLeft(4, '0');
                    response.GPNumber = "G" + Convert.ToString(currentYear + "I" + gpType + gpnumbernc);
                }
            }
            else
            {
                response.GPNumber = "G" + Convert.ToString(currentYear + "I" + gpType + "0001");
            }

            return response;
        }

        public GetGPSendingResponseDto GetGPSendingMasterAndDetails()
        {
            var response = new GetGPSendingResponseDto()
            {
                GetGPSendingResponse = new List<GetGPSendingResponse>()
            };
            var responseDto = new GetGPSendingResponse();

            var model = gatePassRepository.GetGPSendingMasterAndDetails();

            //if (model != null)
            //{
            //    responseDto = GetGPSendingMapper((List<GetGPSendingModel>)model.getGPSendingModel, responseDto);
            //}

            foreach (var gpSendingDetails in model.getGPSendingModel)
            {
                var getsingle = new GetGPSendingResponse
                {
                    GetGPSendingDetailsist = new List<GetGPSendingDetails>()
                };
                var getGPSendingDetailsResponse = new GetGPSendingDetails();
                getGPSendingDetailsResponse.GPNumber = gpSendingDetails.GPNumber;
                getGPSendingDetailsResponse.GPSerialNo = gpSendingDetails.GPSerialNo;
                getGPSendingDetailsResponse.Description = gpSendingDetails.Description;
                getGPSendingDetailsResponse.Units = gpSendingDetails.Units;
                getGPSendingDetailsResponse.UnitsDescription = gpSendingDetails.UnitsDescription;
                getGPSendingDetailsResponse.SentQuantity = gpSendingDetails.SentQuantity;
                getGPSendingDetailsResponse.ReceivedQuantity = gpSendingDetails.ReceivedQuantity;
                getGPSendingDetailsResponse.IsDeletable = gpSendingDetails.IsDeletable;

                //getWorkOrderMasterDetailsResponse.IsDeletable = workOrderMasterDetails.IsDeletable;
                //getWorkOrderMasterDetailsResponse.IsNew = false;

                if (response.GetGPSendingResponse.Count > 0)
                {
                    var isExist = response.GetGPSendingResponse.Any(gpNumber => gpNumber.GPNumber == gpSendingDetails.GPNumber);
                    if (isExist)
                    {
                        var index = response.GetGPSendingResponse.FindIndex(a => a.GPNumber == gpSendingDetails.GPNumber);

                        response.GetGPSendingResponse[index].GetGPSendingDetailsist.Add(getGPSendingDetailsResponse);
                    }
                    else
                    {
                        getsingle.GPType = gpSendingDetails.GPType;
                        getsingle.GPDescription = gpSendingDetails.GPDescription;
                        getsingle.GPNumber = gpSendingDetails.GPNumber;
                        getsingle.GPDate = gpSendingDetails.GPDate;
                        getsingle.VendorCode = gpSendingDetails.VendorCode;
                        getsingle.VendorName = gpSendingDetails.VendorName;
                        getsingle.RequestedBy = gpSendingDetails.RequestedBy;
                        getsingle.RequestedName = gpSendingDetails.RequestedName;
                        getsingle.Remarks = gpSendingDetails.Remarks;
                        getsingle.FullAddress = gpSendingDetails.FullAddress;
	                    getsingle.City = gpSendingDetails.City;
                        getsingle.PinCode = gpSendingDetails.PinCode;
                        getsingle.CompanyGST = gpSendingDetails.CompanyGST;
                        getsingle.IsDeletable = gpSendingDetails.IsDeletable;
                        getsingle.GetGPSendingDetailsist.Add
                        (getGPSendingDetailsResponse);

                        response.GetGPSendingResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPType = gpSendingDetails.GPType;
                    getsingle.GPDescription = gpSendingDetails.GPDescription;
                    getsingle.GPNumber = gpSendingDetails.GPNumber;
                    getsingle.GPDate = gpSendingDetails.GPDate;
                    getsingle.VendorCode = gpSendingDetails.VendorCode;
                    getsingle.VendorName = gpSendingDetails.VendorName;
                    getsingle.RequestedBy = gpSendingDetails.RequestedBy;
                    getsingle.RequestedName = gpSendingDetails.RequestedName;
                    getsingle.Remarks = gpSendingDetails.Remarks;
                    getsingle.FullAddress = gpSendingDetails.FullAddress;
                    getsingle.City = gpSendingDetails.City;
                    getsingle.PinCode = gpSendingDetails.PinCode;
                    getsingle.CompanyGST = gpSendingDetails.CompanyGST;
                    getsingle.IsDeletable = gpSendingDetails.IsDeletable;
                    getsingle.GetGPSendingDetailsist.Add
                    (getGPSendingDetailsResponse);

                    response.GetGPSendingResponse.Add(getsingle);
                }
            }

            return response;
        }

        private static GetUnitMasterResponseDto GPUnitMasterMapper(List<GetUnitMasterQMList> list, GetUnitMasterResponseDto response)
        {
            Mapper.CreateMap<GetUnitMasterQMList, UnitMasterList>();
            response.GetUnitMasterList =
                Mapper.Map<List<GetUnitMasterQMList>, List<UnitMasterList>>(list);

            return response;
        }

        private static GPTypeMasterResponseDto GPTypeMasterMapper(List<GPTypeMasterResponseModel> list, GPTypeMasterResponseDto response)
        {
            Mapper.CreateMap<GPTypeMasterResponseModel, GPTypeMasterResponse>();
            response.gpTypeList =
                Mapper.Map<List<GPTypeMasterResponseModel>, List<GPTypeMasterResponse>>(list);

            return response;
        }

        private static GetGPSendingResponse GetGPSendingMapper(List<GetGPSendingModel> list, GetGPSendingResponse getGPSendingResponse)
        {
            Mapper.CreateMap<GetGPSendingModel, GetGPSendingDetails>();
            getGPSendingResponse.GetGPSendingDetailsist =
                Mapper.Map<List<GetGPSendingModel>, List<GetGPSendingDetails>>(list);

            return getGPSendingResponse;
        }

        #endregion

        #region Receipt


        public GPReceiptNumberResponseDto getGPReceiptNumber()
        {
            var response = new GPReceiptNumberResponseDto();
            var model = gatePassRepository.getGPReceiptNumber();
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(1, 2));
                if (!savedYear.Equals(currentYear))
                {
                    response.GPReceiptNumber = "R" + Convert.ToString(currentYear + "IR0001");
                }
                else
                {
                    var gpnumbernc = (Int32.Parse(model.ToString().Substring(model.ToString().Length - 4)) + 1).ToString().PadLeft(4, '0');
                    response.GPReceiptNumber = "R" + Convert.ToString(currentYear + "IR" + gpnumbernc);
                }
            }
            else
            {
                response.GPReceiptNumber = "R" + Convert.ToString(currentYear + "IR0001");
            }
            return response;
        }

        public GetGPReceiptVendorResponseDto getGPReceiptVendor()
        {
            var response = new GetGPReceiptVendorResponseDto();
            var model = gatePassRepository.getGPReceiptVendor();
            if (model != null)
            {
                response = GPReceiptVendorMapper((List<GPReceiptVendorModel>)model.gpReceiptVendorList, response);
            }

            return response;
        }

        public GetGPReceivingResponseDto GetGPReceivingMasterAndDetails(Int64 VendorCode)
        {
            var response = new GetGPReceivingResponseDto()
            {
                getGPReceivingMaster = new List<GetGPReceivingMaster>()
            };

            var model = gatePassRepository.GetGPReceivingMasterAndDetails(VendorCode);


            foreach (var responseModel in model.getGPReceivingResponseModel)
            {
                var getsingle = new GetGPReceivingMaster
                {
                    getGPReceivingDetails  = new List<GetGPReceivingDetails>()
                };
                var getGPReceivingDetailsItems = new GetGPReceivingDetails();
                getGPReceivingDetailsItems.GPNumber = responseModel.GPNumber;
                getGPReceivingDetailsItems.GPSerialNo = responseModel.GPSerialNo;
                getGPReceivingDetailsItems.Units = responseModel.Units;
                getGPReceivingDetailsItems.UnitsDescription = responseModel.UnitsDescription;
                getGPReceivingDetailsItems.SentQuantity = responseModel.SentQuantity;
                getGPReceivingDetailsItems.ReceivedQuantity = responseModel.ReceivedQuantity;
                getGPReceivingDetailsItems.BalanceQty = responseModel.BalanceQty;
                getGPReceivingDetailsItems.Description = responseModel.Description;

                if (response.getGPReceivingMaster.Count > 0)
                {
                    var isExist = response.getGPReceivingMaster.Any(dcMaster => dcMaster.GPNumber == responseModel.GPNumber);
                    if (isExist)
                    {
                        var index = response.getGPReceivingMaster.FindIndex(a => a.GPNumber == responseModel.GPNumber);

                        response.getGPReceivingMaster[index].getGPReceivingDetails.Add(getGPReceivingDetailsItems);
                    }
                    else
                    {
                        getsingle.GPNumber = responseModel.GPNumber;
                        getsingle.GPType = responseModel.GPType;
                        getsingle.VendorName = responseModel.VendorName;
                        getsingle.RequestedBy = responseModel.RequestedBy;
                        getsingle.GPDate = responseModel.GPDate;

                        getsingle.getGPReceivingDetails.Add
                        (getGPReceivingDetailsItems);

                        response.getGPReceivingMaster.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPNumber = responseModel.GPNumber;
                    getsingle.GPType = responseModel.GPType;
                    getsingle.VendorName = responseModel.VendorName;
                    getsingle.RequestedBy = responseModel.RequestedBy;
                    getsingle.GPDate = responseModel.GPDate;

                    getsingle.getGPReceivingDetails.Add
                    (getGPReceivingDetailsItems);

                    response.getGPReceivingMaster.Add(getsingle);
                }
            }

            return response;
        }

        public GetGPReceivedDetailsResponseDto GetGPReceivedDetails()
        {
            var response = new GetGPReceivedDetailsResponseDto()
            {
                GPReceivedMasterDetails = new List<GPReceivedMasterDetails>()
            };

            var model = gatePassRepository.GetGPReceivedDetails();


            foreach (var responseModel in model.GetGPReceivedDetailsModel)
            {
                var getsingle = new GPReceivedMasterDetails
                {
                    GPReceivedDetails = new List<GPReceivedDetails>()
                };
                var getGPReceivingDetailsItems = new GPReceivedDetails();
                getGPReceivingDetailsItems.GPReceiptNumber = responseModel.GPReceiptNumber;
                getGPReceivingDetailsItems.GPNumber = responseModel.GPNumber;
                getGPReceivingDetailsItems.GPSerialNo = responseModel.GPSerialNo;
                getGPReceivingDetailsItems.ReceiptQuantity = responseModel.ReceiptQuantity;
                getGPReceivingDetailsItems.Description = responseModel.Description;

                if (response.GPReceivedMasterDetails.Count > 0)
                {
                    var isExist = response.GPReceivedMasterDetails.Any(dcMaster => dcMaster.GPReceiptNumber == responseModel.GPReceiptNumber);
                    if (isExist)
                    {
                        var index = response.GPReceivedMasterDetails.FindIndex(a => a.GPReceiptNumber == responseModel.GPReceiptNumber);

                        response.GPReceivedMasterDetails[index].GPReceivedDetails.Add(getGPReceivingDetailsItems);
                    }
                    else
                    {
                        getsingle.GPReceiptNumber = responseModel.GPReceiptNumber;
                        getsingle.GPReceiptDate = responseModel.GPReceiptDate;
                        getsingle.VendorName = responseModel.VendorName;
                        getsingle.VendorCode = responseModel.VendorCode;
                        getsingle.DocumentDate = responseModel.DocumentDate;
                        getsingle.DocumentID = responseModel.DocumentID;
                        getsingle.Remarks = responseModel.Remarks;

                        getsingle.GPReceivedDetails.Add
                        (getGPReceivingDetailsItems);

                        response.GPReceivedMasterDetails.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPReceiptNumber = responseModel.GPReceiptNumber;
                    getsingle.GPReceiptDate = responseModel.GPReceiptDate;
                    getsingle.VendorName = responseModel.VendorName;
                    getsingle.VendorCode = responseModel.VendorCode;
                    getsingle.DocumentDate = responseModel.DocumentDate;
                    getsingle.DocumentID = responseModel.DocumentID;
                    getsingle.Remarks = responseModel.Remarks;

                    getsingle.GPReceivedDetails.Add
                    (getGPReceivingDetailsItems);

                    response.GPReceivedMasterDetails.Add(getsingle);
                }
            }

            return response;
        }

        private GetGPReceiptVendorResponseDto GPReceiptVendorMapper(List<GPReceiptVendorModel> gpReceiptVendorList, GetGPReceiptVendorResponseDto response)
        {
            Mapper.CreateMap<GPReceiptVendorModel, GPReceiptVendorResponse>();
            response.gpReceiptVendorList =
                Mapper.Map<List<GPReceiptVendorModel>, List<GPReceiptVendorResponse>>(gpReceiptVendorList);

            return response;
        }
        #endregion


    }
}
