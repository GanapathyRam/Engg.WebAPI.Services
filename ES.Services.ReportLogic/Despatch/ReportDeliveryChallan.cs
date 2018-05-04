using ES.Services.ReportLogic.Interface.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.DataAccess.Interface.Despatch;
using AutoMapper;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataTransferObjects.Request.Despatch;

namespace ES.Services.ReportLogic.Despatch
{
    public class ReportDeliveryChallan : IReportDeliveryChallan
    {
        private readonly IDeliveryChallanRepository deliveryChallanRepository;

        public ReportDeliveryChallan(IDeliveryChallanRepository deliveryChallanRepository)
        {
            this.deliveryChallanRepository = deliveryChallanRepository;
        }

        public GetDcTypeResponseDto GetDCType()
        {
            var response = new GetDcTypeResponseDto();

            var model = deliveryChallanRepository.GetDcType();

            if (model != null)
            {
                response = DcTypeMapper((List<DcTypeModel>)model.dcTypeModelList, response);
            }

            return response;
        }

        public GetWOMasterForDcResponseDto GetWoMasterForDc(GetWOMasterForDcRequestDto getWOMasterForDcRequestDto)
        {
            var response = new GetWOMasterForDcResponseDto()
            {
                getWOMasterForDcResponseList = new List<GetWOMasterForDcResponse>()
            };

            var model = deliveryChallanRepository.GetWoMasterAndDetails(getWOMasterForDcRequestDto.VendorCode, getWOMasterForDcRequestDto.WoType, getWOMasterForDcRequestDto.DcNumber, getWOMasterForDcRequestDto.Invoiced);


            foreach (var dcMasterDetails in model.getWoMasterAndDetailsFromCustomerCodeType)
            {
                var getsingle = new GetWOMasterForDcResponse
                {
                    getSerialNoFromWoNumerWoSerialResponseList = new List<GetSerialNoFromWoNumerWoSerialList>()
                };
                var getWoMasterDetailsResponse = new GetSerialNoFromWoNumerWoSerialList();
                getWoMasterDetailsResponse.SerialNo = dcMasterDetails.SerialNo;
                getWoMasterDetailsResponse.WONumber = dcMasterDetails.WONumber;
                getWoMasterDetailsResponse.WOSerial = dcMasterDetails.WOSerial;
                getWoMasterDetailsResponse.DCNumber = dcMasterDetails.DCNumber;
                getWoMasterDetailsResponse.IsNew = dcMasterDetails.IsNew ? false : true;

                if (response.getWOMasterForDcResponseList.Count > 0)
                {
                    var isExist = response.getWOMasterForDcResponseList.Any(dcMaster => dcMaster.WONumber == dcMasterDetails.WONumber && dcMaster.WOSerial == dcMasterDetails.WOSerial);
                    if (isExist)
                    {
                        var index = response.getWOMasterForDcResponseList.FindIndex(a => a.WONumber == dcMasterDetails.WONumber && a.WOSerial == dcMasterDetails.WOSerial);

                        response.getWOMasterForDcResponseList[index].getSerialNoFromWoNumerWoSerialResponseList.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.PartCode = dcMasterDetails.PartCode;
                        getsingle.WONumber = dcMasterDetails.WONumber;
                        getsingle.WOSerial = dcMasterDetails.WOSerial;
                        getsingle.DCNumber = dcMasterDetails.DCNumber;
                        getsingle.WOQuantity = dcMasterDetails.WOQuantity;
                        getsingle.MaterialCode = dcMasterDetails.MaterialCode;
                        getsingle.DrawingNumber = dcMasterDetails.DrawingNumber;
                        getsingle.DrawingNumberRevision = dcMasterDetails.DrawingNumberRevision;
                        getsingle.HeatNo = dcMasterDetails.HeatNo;
                        getsingle.WDCNumber = dcMasterDetails.WDCNumber;
                        getsingle.ItemCode = dcMasterDetails.ItemCode;
                        getsingle.PONumber = dcMasterDetails.PONumber;
                        getsingle.PartDescription = dcMasterDetails.PartDescription;
                        getsingle.MaterialDescription = dcMasterDetails.MaterialDescription;
                        getsingle.IsDeletable = false;
                        getsingle.IsNew = dcMasterDetails.IsNew ? false : true;
                        getsingle.DcSerial = dcMasterDetails.DcSerial;

                        //if (!dcMasterDetails.IsDelete)
                        //{
                        getsingle.getSerialNoFromWoNumerWoSerialResponseList.Add
                        (getWoMasterDetailsResponse);
                        //}

                        response.getWOMasterForDcResponseList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.PartCode = dcMasterDetails.PartCode;
                    getsingle.WONumber = dcMasterDetails.WONumber;
                    getsingle.WOSerial = dcMasterDetails.WOSerial;
                    getsingle.DCNumber = dcMasterDetails.DCNumber;
                    getsingle.WOQuantity = dcMasterDetails.WOQuantity;
                    getsingle.MaterialCode = dcMasterDetails.MaterialCode;
                    getsingle.ItemCode = dcMasterDetails.ItemCode;
                    getsingle.PONumber = dcMasterDetails.PONumber;
                    getsingle.PartDescription = dcMasterDetails.PartDescription;
                    getsingle.DrawingNumber = dcMasterDetails.DrawingNumber;
                    getsingle.DrawingNumberRevision = dcMasterDetails.DrawingNumberRevision;
                    getsingle.HeatNo = dcMasterDetails.HeatNo;
                    getsingle.WDCNumber = dcMasterDetails.WDCNumber;
                    getsingle.MaterialDescription = dcMasterDetails.MaterialDescription;
                    getsingle.IsDeletable = false;
                    getsingle.IsNew = dcMasterDetails.IsNew ? false : true;
                    getsingle.DcSerial = dcMasterDetails.DcSerial;
                    //if (!dcMasterDetails.IsDelete)
                    //{
                    getsingle.getSerialNoFromWoNumerWoSerialResponseList.Add
                    (getWoMasterDetailsResponse);
                    //}
                    response.getWOMasterForDcResponseList.Add(getsingle);
                }
            }

            // 
            //if (getWOMasterForDcRequestDto.WoNumber == string.Empty && getWOMasterForDcRequestDto.WoSerial == 0)
            //{
            //    var model = deliveryChallanRepository.GetWoMasterForDc(getWOMasterForDcRequestDto.VendorCode, getWOMasterForDcRequestDto.WoType);

            //    if (model != null)
            //    {
            //        response = GetWoMasterForDcMapper((List<GetWOMasterForDcModel>)model.GetWOMasterForDcModelList, response);
            //    }
            //}
            //else
            //{
            //    var model = deliveryChallanRepository.GetSerialNoFromWoNumerWoSerialForDc(getWOMasterForDcRequestDto.WoNumber, getWOMasterForDcRequestDto.WoSerial);

            //    if (model != null)
            //    {
            //        response = GetWoMasterForDcMapper((List<GetSerialNoFromWoNumerWoSerialModel>)model.getSerialNoFromWoNumerWoSerialModel, response);
            //    }
            //}

            return response;
        }

        public GetDCNumberResponseDto GetDCNumber(string WoType)
        {
            var response = new GetDCNumberResponseDto();

            var model = deliveryChallanRepository.GetDCNumber(WoType);

            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(2, 2));
                var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));

                if (!savedYear.Equals(currentYear))
                {
                    response.DCNumber = "D" + WoType + Convert.ToString(System.DateTime.UtcNow.ToString().Substring(8, 2) + "0001");
                }
                else
                {
                    var dcType = Convert.ToString(model.ToString().Substring(0, 1));
                    var workOrderInc = Int32.Parse(model.ToString().Substring(2, 6)) + 1;
                    response.DCNumber = dcType + WoType + Convert.ToString(workOrderInc);
                }
            }
            else
            {
                response.DCNumber = "D" + WoType + Convert.ToString(System.DateTime.UtcNow.ToString().Substring(8, 2) + "0001");
            }

            return response;
        }

        public GetDcMasterResponseDto GetDcMaster()
        {
            GetDcMasterResponseDto response = new GetDcMasterResponseDto();

            var model = deliveryChallanRepository.GetDcMaster();

            if (model != null)
            {
                response = DcMasterMapper((List<GetDcMasterModel>)model.GetDcMasterModelList, response);
            }

            return response;
        }

        #region
        private static GetDcTypeResponseDto DcTypeMapper(List<DcTypeModel> list, GetDcTypeResponseDto getDcTypeResponseDto)
        {
            Mapper.CreateMap<DcTypeModel, DcTypeList>();
            getDcTypeResponseDto.DcTypeList =
                Mapper.Map<List<DcTypeModel>, List<DcTypeList>>(list);

            return getDcTypeResponseDto;
        }

        private static GetWOMasterForDcResponseDto GetWoMasterForDcMapper(List<GetWOMasterForDcModel> list, GetWOMasterForDcResponseDto getWOMasterForDcResponseDto)
        {
            //Mapper.CreateMap<GetWOMasterForDcModel, GetWOMasterForDcResponseList>();
            //getWOMasterForDcResponseDto.getWOMasterForDcResponseList =
            //    Mapper.Map<List<GetWOMasterForDcModel>, List<GetWOMasterForDcResponseList>>(list);

            return getWOMasterForDcResponseDto;
        }

        private static GetWOMasterForDcResponseDto GetWoMasterForDcMapper(List<GetSerialNoFromWoNumerWoSerialModel> list, GetWOMasterForDcResponseDto getWOMasterForDcResponseDto)
        {
            //Mapper.CreateMap<GetSerialNoFromWoNumerWoSerialModel, GetSerialNoFromWoNumerWoSerialResponse>();
            //getWOMasterForDcResponseDto.getSerialNoFromWoNumerWoSerialResponseList =
            //    Mapper.Map<List<GetSerialNoFromWoNumerWoSerialModel>, List<GetSerialNoFromWoNumerWoSerialResponse>>(list);

            return getWOMasterForDcResponseDto;
        }

        private static GetDcMasterResponseDto DcMasterMapper(List<GetDcMasterModel> list, GetDcMasterResponseDto getDcMasterResponseDto)
        {
            Mapper.CreateMap<GetDcMasterModel, GetDcMasterResponseModel>();
            getDcMasterResponseDto.GetDcMasterResponseModelList =
                Mapper.Map<List<GetDcMasterModel>, List<GetDcMasterResponseModel>>(list);

            return getDcMasterResponseDto;
        }

        #endregion
    }
}
