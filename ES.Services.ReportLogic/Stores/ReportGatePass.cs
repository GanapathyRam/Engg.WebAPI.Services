using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
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
            var model  = gatePassRepository.getGPSendingNumber(gpType);
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
                    var gpnumbernc = (Int32.Parse(model.ToString().Substring(model.ToString().Length - 4)) + 1).ToString().PadLeft(4,'0');
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

            if (model != null)
            {
                responseDto = GetGPSendingMapper((List<GetGPSendingModel>)model.getGPSendingModel, responseDto);
            }

            foreach (var gpSendingDetails in responseDto.GetGPSendingDetailsist)
            {
                var getsingle = new GetGPSendingResponse
                {
                    GetGPSendingDetailsist = new List<GetGPSendingDetails>()
                };
                var getGPSendingDetailsResponse = new GetGPSendingDetails();
                getGPSendingDetailsResponse.GPNumber = gpSendingDetails.GPNumber;
                getGPSendingDetailsResponse.GPType = gpSendingDetails.GPType;
                getGPSendingDetailsResponse.GPSerialNo = gpSendingDetails.GPSerialNo;
                getGPSendingDetailsResponse.Description = gpSendingDetails.Description;
                getGPSendingDetailsResponse.Units = gpSendingDetails.Units;
                getGPSendingDetailsResponse.SentQuantity = gpSendingDetails.SentQuantity;
                getGPSendingDetailsResponse.ReceivedQuantity = gpSendingDetails.ReceivedQuantity;

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
                        getsingle.GPNumber = gpSendingDetails.GPNumber;                      
                        getsingle.GPDate = gpSendingDetails.GPDate;
                        getsingle.VendorCode = gpSendingDetails.VendorCode;
                        getsingle.RequestedBy = gpSendingDetails.RequestedBy;
                        getsingle.Remarks = gpSendingDetails.Remarks;

                        getsingle.GetGPSendingDetailsist.Add
                        (getGPSendingDetailsResponse);

                        response.GetGPSendingResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.GPType = gpSendingDetails.GPType;
                    getsingle.GPNumber = gpSendingDetails.GPNumber;
                    getsingle.GPDate = gpSendingDetails.GPDate;
                    getsingle.VendorCode = gpSendingDetails.VendorCode;
                    getsingle.RequestedBy = gpSendingDetails.RequestedBy;
                    getsingle.Remarks = gpSendingDetails.Remarks;

                    getsingle.GetGPSendingDetailsist.Add
                    (getGPSendingDetailsResponse);

                    response.GetGPSendingResponse.Add(getsingle);
                }
            }

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
