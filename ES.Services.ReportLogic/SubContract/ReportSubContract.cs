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

        public GetDCNumberForScSendingResponseDto GetDCNumber()
        {
            var response = new GetDCNumberForScSendingResponseDto();

            var model = subContractRepository.GetSCSendingDCNumber();

            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                if (!savedYear.Equals(currentYear))
                {
                    response.DCNumber = "SS" + Convert.ToString(System.DateTime.UtcNow.ToString().Substring(8, 2) + "0001");
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
                response.DCNumber = "SS" + Convert.ToString(System.DateTime.UtcNow.ToString().Substring(8, 2) + "0001");
            }

            return response;
        }


        #region Mapper

        private static GetScSendingMasterResponseDto ScSendingMasterMapper(List<GetScMasterModel> list, GetScSendingMasterResponseDto getScSendingMasterResponseDto)
        {
            Mapper.CreateMap<GetScMasterModel, GetScSendingMasterResponseModel>();
            getScSendingMasterResponseDto.GetScSendingMasterResponseModelList = Mapper.Map<List<GetScMasterModel>, List<GetScSendingMasterResponseModel>>(list);

            return getScSendingMasterResponseDto;
        }

        #endregion
    }
}
