using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.ReportLogic.Interface.Sales;
using ES.Services.ReportLogic.Interface.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Response.SubContract;
using ES.Services.DataAccess.Interface.SubContract;
using AutoMapper;
using ES.Services.DataAccess.Model.QueryModel.SubContract;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.ExceptionAttributes;

namespace ES.Services.ReportLogic.SubContract
{
    public class ReportSubContract : IReportSubContract
    {
        private readonly ISubContractRepository subContractRepository;

        public ReportSubContract(ISubContractRepository subContractRepository)
        {
            this.subContractRepository = subContractRepository;
        }

        public GetSubContractSendingResponseDto GetSubContractSendingDetails()
        {
            var response = new GetSubContractSendingResponseDto()
            {
                getSubContractSendingResponseList = new List<GetSubContractSendingResponse>()
            };

            var model = subContractRepository.GetSubContractSendingDetails();


            foreach (var responseModel in model.getSubContractSendingResponseModel)
            {
                var getsingle = new GetSubContractSendingResponse
                {
                    getSubContractSendingSerialList = new List<GetSubContractSendingSerialList>()
                };
                var getWoMasterDetailsResponse = new GetSubContractSendingSerialList();
                getWoMasterDetailsResponse.SerialNo = responseModel.SerialNo;
                getWoMasterDetailsResponse.WONumber = responseModel.WONumber;
                getWoMasterDetailsResponse.WOSerial = responseModel.WOSerial;

                if (response.getSubContractSendingResponseList.Count > 0)
                {
                    var isExist = response.getSubContractSendingResponseList.Any(dcMaster => dcMaster.WONumber == responseModel.WONumber && dcMaster.WOSerial == responseModel.WOSerial);
                    if (isExist)
                    {
                        var index = response.getSubContractSendingResponseList.FindIndex(a => a.WONumber == responseModel.WONumber && a.WOSerial == responseModel.WOSerial);

                        response.getSubContractSendingResponseList[index].getSubContractSendingSerialList.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.WONumber = responseModel.WONumber;
                        getsingle.WOSerial = responseModel.WOSerial;
                        getsingle.CustomerName = responseModel.CustomerName;
                        getsingle.DrawingNumber = responseModel.DrawingNumber;
                        getsingle.ItemCode = responseModel.ItemCode;
                        getsingle.MaterialCode = responseModel.MaterialCode;
                        getsingle.MaterialDescription = responseModel.MaterialDescription;
                        getsingle.PartCode = responseModel.PartCode;
                        getsingle.PartDescription = responseModel.PartDescription;


                        getsingle.getSubContractSendingSerialList.Add
                        (getWoMasterDetailsResponse);

                        response.getSubContractSendingResponseList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.WONumber = responseModel.WONumber;
                    getsingle.WOSerial = responseModel.WOSerial;
                    getsingle.CustomerName = responseModel.CustomerName;
                    getsingle.DrawingNumber = responseModel.DrawingNumber;
                    getsingle.ItemCode = responseModel.ItemCode;
                    getsingle.MaterialCode = responseModel.MaterialCode;
                    getsingle.MaterialDescription = responseModel.MaterialDescription;
                    getsingle.PartCode = responseModel.PartCode;
                    getsingle.PartDescription = responseModel.PartDescription;

                    getsingle.getSubContractSendingSerialList.Add
                    (getWoMasterDetailsResponse);

                    response.getSubContractSendingResponseList.Add(getsingle);
                }
            }

            return response;
        }

        public GetScSendingMasterResponseDto GetScSendingMaster()
        {
            GetScSendingMasterResponseDto response = new GetScSendingMasterResponseDto();

            var model = subContractRepository.GetScMaster();

            if (model != null)
            {
                response = ScSendingMasterMapper((List<GetScMasterModel>)model.GetScMasterModelList, response);
            }

            return response;
        }

        public GetDCNumberForScSendingResponseDto GetDCNumber(int DcNumberFor)
        {
            var response = new GetDCNumberForScSendingResponseDto();

            var model = subContractRepository.GetSCSendingDCNumber(DcNumberFor);

            var currentYear = Helper.CurrentFiniancialYear();

            if (DcNumberFor == 1)
            {
                if (!string.IsNullOrEmpty(model))
                {
                    var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                    //var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                    if (!savedYear.Equals(currentYear))
                    {
                        response.DCNumber = "SS" + Convert.ToString(currentYear + "0001");
                    }
                    else
                    {
                        var dcType = "SS";
                        var workOrderInc = Int32.Parse(model.ToString().Substring(2, 6)) + 1;
                        response.DCNumber = Convert.ToString(dcType + workOrderInc);
                    }
                }
                else
                {
                    response.DCNumber = "SS" + Convert.ToString(currentYear + "0001");
                }
            }
            else if (DcNumberFor == 2)
            {
                if (!string.IsNullOrEmpty(model))
                {
                    var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                    //var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                    if (!savedYear.Equals(currentYear))
                    {
                        response.DCNumber = "SR" + Convert.ToString(currentYear + "0001");
                    }
                    else
                    {
                        var dcType = "SR";
                        var workOrderInc = Int32.Parse(model.ToString().Substring(2, 6)) + 1;
                        response.DCNumber = Convert.ToString(dcType + workOrderInc);
                    }
                }
                else
                {
                    response.DCNumber = "SR" + Convert.ToString(currentYear + "0001");
                }
            }

            return response;
        }

        public GetScDetailsAndSerialsResponseDto GetSubContractDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto)
        {
            var response = new GetScDetailsAndSerialsResponseDto()
            {
                getScDetailsResponse = new List<GetScDetailsResponse>()
            };

            var model = subContractRepository.GetSubContractDetailAndSerials(getScDetailsAndSerialsRequestDto.VendorCode, getScDetailsAndSerialsRequestDto.DcNumber);


            foreach (var responseModel in model.getScDetailsAndSerialsModel)
            {
                var getsingle = new GetScDetailsResponse
                {
                    getGetScSerialsResponse = new List<GetScSerialsResponse>()
                };
                var getWoMasterDetailsResponse = new GetScSerialsResponse();
                getWoMasterDetailsResponse.SerialNo = responseModel.SerialNo;
                getWoMasterDetailsResponse.WoNumber = responseModel.WONumber;
                getWoMasterDetailsResponse.WoSerial = responseModel.WOSerial;

                if (response.getScDetailsResponse.Count > 0)
                {
                    var isExist = response.getScDetailsResponse.Any(dcMaster => dcMaster.WoNumber == responseModel.WONumber && dcMaster.WoSerial == responseModel.WOSerial);
                    if (isExist)
                    {
                        var index = response.getScDetailsResponse.FindIndex(a => a.WoNumber == responseModel.WONumber && a.WoSerial == responseModel.WOSerial);

                        response.getScDetailsResponse[index].getGetScSerialsResponse.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.WoNumber = responseModel.WONumber;
                        getsingle.WoSerial = responseModel.WOSerial;
                        getsingle.PartCode = responseModel.PartCode;
                        getsingle.DrawingNumber = responseModel.DrawingNumber;
                        getsingle.ItemCode = responseModel.ItemCode;
                        getsingle.MaterialCode = responseModel.MaterialCode;
                        getsingle.MaterialDescription = responseModel.MaterialDescription;
                        getsingle.PartDescription = responseModel.PartDescription;


                        getsingle.getGetScSerialsResponse.Add
                        (getWoMasterDetailsResponse);

                        response.getScDetailsResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.WoNumber = responseModel.WONumber;
                    getsingle.WoSerial = responseModel.WOSerial;
                    getsingle.PartCode = responseModel.PartCode;
                    getsingle.DrawingNumber = responseModel.DrawingNumber;
                    getsingle.ItemCode = responseModel.ItemCode;
                    getsingle.MaterialCode = responseModel.MaterialCode;
                    getsingle.MaterialDescription = responseModel.MaterialDescription;
                    getsingle.PartDescription = responseModel.PartDescription;
                    getsingle.getGetScSerialsResponse.Add
                    (getWoMasterDetailsResponse);

                    response.getScDetailsResponse.Add(getsingle);
                }
            }

            return response;
        }

        #region SubContract Receiving 

        public GetScReceivingDetailsResponseDto GetSubContractReceivingDetails(Int64 VendorCode)
        {
            var response = new GetScReceivingDetailsResponseDto()
            {
                getSubContractReceivingResponseList = new List<GetSubContractReceivingResponse>()
            };

            var model = subContractRepository.GetSubContractReceivingDetails(VendorCode);


            foreach (var responseModel in model.getSubContractReceivingResponseModel)
            {
                var getsingle = new GetSubContractReceivingResponse
                {
                    getSubContractReceivingSerialList = new List<GetSubContractReceivingSerialList>()
                };
                var getWoMasterDetailsResponse = new GetSubContractReceivingSerialList();
                getWoMasterDetailsResponse.SerialNo = responseModel.SerialNo;
                getWoMasterDetailsResponse.WONumber = responseModel.WONumber;
                getWoMasterDetailsResponse.WOSerial = responseModel.WOSerial;

                if (response.getSubContractReceivingResponseList.Count > 0)
                {
                    var isExist = response.getSubContractReceivingResponseList.Any(dcMaster => dcMaster.WONumber == responseModel.WONumber && dcMaster.WOSerial == responseModel.WOSerial);
                    if (isExist)
                    {
                        var index = response.getSubContractReceivingResponseList.FindIndex(a => a.WONumber == responseModel.WONumber && a.WOSerial == responseModel.WOSerial);

                        response.getSubContractReceivingResponseList[index].getSubContractReceivingSerialList.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.WONumber = responseModel.WONumber;
                        getsingle.WOSerial = responseModel.WOSerial;
                        getsingle.CustomerName = responseModel.VendorName;
                        getsingle.DrawingNumber = responseModel.DrawingNumber;
                        getsingle.ItemCode = responseModel.ItemCode;
                        getsingle.MaterialCode = responseModel.MaterialCode;
                        getsingle.MaterialDescription = responseModel.MaterialDescription;
                        getsingle.PartCode = responseModel.PartCode;
                        getsingle.PartDescription = responseModel.PartDescription;


                        getsingle.getSubContractReceivingSerialList.Add
                        (getWoMasterDetailsResponse);

                        response.getSubContractReceivingResponseList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.WONumber = responseModel.WONumber;
                    getsingle.WOSerial = responseModel.WOSerial;
                    getsingle.CustomerName = responseModel.VendorName;
                    getsingle.DrawingNumber = responseModel.DrawingNumber;
                    getsingle.ItemCode = responseModel.ItemCode;
                    getsingle.MaterialCode = responseModel.MaterialCode;
                    getsingle.MaterialDescription = responseModel.MaterialDescription;
                    getsingle.PartCode = responseModel.PartCode;
                    getsingle.PartDescription = responseModel.PartDescription;

                    getsingle.getSubContractReceivingSerialList.Add
                    (getWoMasterDetailsResponse);

                    response.getSubContractReceivingResponseList.Add(getsingle);
                }
            }

            return response;
        }

        public GetScReceivingDetailsAndSerialsResponseDto GetSubContractReceivingDetailAndSerials(GetScDetailsAndSerialsRequestDto getScDetailsAndSerialsRequestDto)
        {
            var response = new GetScReceivingDetailsAndSerialsResponseDto()
            {
                getScReceivingDetailsResponse = new List<GetScReceivingDetailsResponse>()
            };

            var model = subContractRepository.GetScReceivingDetailAndSerials(getScDetailsAndSerialsRequestDto.VendorCode, getScDetailsAndSerialsRequestDto.DcNumber);


            foreach (var responseModel in model.getScReceivingDetailsAndSerialsModel)
            {
                var getsingle = new GetScReceivingDetailsResponse
                {
                    getGetScReceivingSerialsResponse = new List<GetScReceivingSerialsResponse>()
                };
                var getWoMasterDetailsResponse = new GetScReceivingSerialsResponse();
                getWoMasterDetailsResponse.SerialNo = responseModel.SerialNo;
                getWoMasterDetailsResponse.WoNumber = responseModel.WONumber;
                getWoMasterDetailsResponse.WoSerial = responseModel.WOSerial;

                if (response.getScReceivingDetailsResponse.Count > 0)
                {
                    var isExist = response.getScReceivingDetailsResponse.Any(dcMaster => dcMaster.WoNumber == responseModel.WONumber && dcMaster.WoSerial == responseModel.WOSerial);
                    if (isExist)
                    {
                        var index = response.getScReceivingDetailsResponse.FindIndex(a => a.WoNumber == responseModel.WONumber && a.WoSerial == responseModel.WOSerial);

                        response.getScReceivingDetailsResponse[index].getGetScReceivingSerialsResponse.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.WoNumber = responseModel.WONumber;
                        getsingle.WoSerial = responseModel.WOSerial;
                        getsingle.PartCode = responseModel.PartCode;
                        getsingle.DrawingNumber = responseModel.DrawingNumber;
                        getsingle.ItemCode = responseModel.ItemCode;
                        getsingle.MaterialCode = responseModel.MaterialCode;
                        getsingle.MaterialDescription = responseModel.MaterialDescription;
                        getsingle.PartDescription = responseModel.PartDescription;


                        getsingle.getGetScReceivingSerialsResponse.Add
                        (getWoMasterDetailsResponse);

                        response.getScReceivingDetailsResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.WoNumber = responseModel.WONumber;
                    getsingle.WoSerial = responseModel.WOSerial;
                    getsingle.PartCode = responseModel.PartCode;
                    getsingle.DrawingNumber = responseModel.DrawingNumber;
                    getsingle.ItemCode = responseModel.ItemCode;
                    getsingle.MaterialCode = responseModel.MaterialCode;
                    getsingle.MaterialDescription = responseModel.MaterialDescription;
                    getsingle.PartDescription = responseModel.PartDescription;
                    getsingle.getGetScReceivingSerialsResponse.Add
                    (getWoMasterDetailsResponse);

                    response.getScReceivingDetailsResponse.Add(getsingle);
                }
            }

            return response;
        }

        public GetScReceivingMasterResponseDto GetScReceivingMaster()
        {
            GetScReceivingMasterResponseDto response = new GetScReceivingMasterResponseDto();

            var model = subContractRepository.GetScReceivingMaster();

            if (model != null)
            {
                response = ScSendingMasterMapper((List<GetScReceivingMasterModel>)model.GetScReceiveMasterModelList, response);
            }

            return response;
        }

        #endregion

        #region Mapper

        private static GetScSendingMasterResponseDto ScSendingMasterMapper(List<GetScMasterModel> list, GetScSendingMasterResponseDto getScSendingMasterResponseDto)
        {
            Mapper.CreateMap<GetScMasterModel, GetScSendingMasterResponseModel>();
            getScSendingMasterResponseDto.GetScSendingMasterResponseModelList = Mapper.Map<List<GetScMasterModel>, List<GetScSendingMasterResponseModel>>(list);

            return getScSendingMasterResponseDto;
        }


        private static GetScReceivingMasterResponseDto ScSendingMasterMapper(List<GetScReceivingMasterModel> list, GetScReceivingMasterResponseDto getScSendingMasterResponseDto)
        {
            Mapper.CreateMap<GetScReceivingMasterModel, GetScReceivingMasterResponseModel>();
            getScSendingMasterResponseDto.GetScReceivingMasterResponseModel = Mapper.Map<List<GetScReceivingMasterModel>, List<GetScReceivingMasterResponseModel>>(list);

            return getScSendingMasterResponseDto;
        }

        #endregion
    }
}
