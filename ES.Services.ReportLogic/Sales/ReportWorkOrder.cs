﻿using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Sales;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using ES.Services.DataTransferObjects.Request.Sales;
using ES.Services.DataTransferObjects.Response.Sales;
using ES.Services.ReportLogic.Interface.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Sales
{
    public class ReportWorkOrder : IReportWorkOrder
    {
        private readonly IWorkOrderRepository workOrderTypeRepository;

        public ReportWorkOrder(IWorkOrderRepository workOrderTypeRepository)
        {
            this.workOrderTypeRepository = workOrderTypeRepository;
        }
        public GetWorkOrderTypeResponseDto GetWorkOrderType()
        {
            var response = new GetWorkOrderTypeResponseDto();

            var model = workOrderTypeRepository.GetWorkOrderType();

            if (model != null)
            {
                response = WorkOrderTypeMapper((List<WorkOrderTypeModel>)model.workOrderTypeModelList, response);
            }

            return response;
        }

        public GetWorkOrderNumberResponseDto GetWorkOrderNumber()
        {
            var response = new GetWorkOrderNumberResponseDto();

            var model = workOrderTypeRepository.GetWorkOrderNumber();
            var currentYear = Helper.CurrentFiniancialYear();
            if (!string.IsNullOrEmpty(model))
            {
                var savedYear = Convert.ToString(model.ToString().Substring(0, 2));
               

                if (!savedYear.Equals(currentYear))
                {
                    response.WorkOrderNumber = Convert.ToString(currentYear + "0001");
                }
                else
                {
                    var workOrderInc = Int32.Parse(model) + 1;
                    response.WorkOrderNumber = Convert.ToString(workOrderInc);
                }
            }
            else
            {
                response.WorkOrderNumber = Convert.ToString(currentYear + "0001");
            }

            return response;
        }

        public GetWorkOrderClientSerialNoResponseDto GetWorkOrderClientSerialNo(string shortCode)
        {
            var response = new GetWorkOrderClientSerialNoResponseDto();

            var model = workOrderTypeRepository.GetWorkOrderClientSerialNo(shortCode);

            return response;
        }

        public GetJobCardEntryReportResponseDto GetJobCardEntryReport(GetJobCardEntryReportRequestDto getJobCardEntryReportRequestDto)
        {
            var response = new GetJobCardEntryReportResponseDto()
            {
                getJobCardEntryCommonList = new List<JobCardEntryCommon> ()
            };
            var responseDto = new JobCardEntryCommon();

            var model = workOrderTypeRepository.GetJobCardEntryReport(getJobCardEntryReportRequestDto.WoNumber, getJobCardEntryReportRequestDto.WoSerial);

            if (model != null)
            {
                responseDto = JobCardEntryMapper((List<GetJobCardEntryReportModel>)model.GetJobCardEntryReportModel, responseDto);
            }

            foreach (var workOrderMasterDetails in responseDto.getJobCardEntryDetailsResponseList)
            {
                var getsingle = new JobCardEntryCommon
                {
                    getJobCardEntryDetailsResponseList = new List<JobCardEntryDetailsResponse> ()
                };
                var getJobCardEntryDetailsResponse = new JobCardEntryDetailsResponse();
                getJobCardEntryDetailsResponse.WoNumber = workOrderMasterDetails.WoNumber;
                getJobCardEntryDetailsResponse.WoSerial = workOrderMasterDetails.WoSerial;
                getJobCardEntryDetailsResponse.DrawingNumberRevision = workOrderMasterDetails.DrawingNumberRevision;
                getJobCardEntryDetailsResponse.DimensionMax = workOrderMasterDetails.DimensionMax;
                getJobCardEntryDetailsResponse.DimensionMin = workOrderMasterDetails.DimensionMin;
                getJobCardEntryDetailsResponse.HeatNo = workOrderMasterDetails.HeatNo;
                getJobCardEntryDetailsResponse.ItemCode = workOrderMasterDetails.ItemCode;
                getJobCardEntryDetailsResponse.RunningTime = workOrderMasterDetails.RunningTime;
                getJobCardEntryDetailsResponse.SequenceNumber = workOrderMasterDetails.SequenceNumber;
                getJobCardEntryDetailsResponse.Serial = workOrderMasterDetails.Serial;
                getJobCardEntryDetailsResponse.SerialNo = workOrderMasterDetails.SerialNo;
                getJobCardEntryDetailsResponse.SettingTime = workOrderMasterDetails.SettingTime;
              

                if (response.getJobCardEntryCommonList.Count > 0)
                {
                    var isExist = response.getJobCardEntryCommonList.Any(woNumber => woNumber.WoNumber == workOrderMasterDetails.WoNumber);
                    if (isExist)
                    {
                        var index = response.getJobCardEntryCommonList.FindIndex(a => a.WoNumber == workOrderMasterDetails.WoNumber);

                        response.getJobCardEntryCommonList[index].getJobCardEntryDetailsResponseList.Add(getJobCardEntryDetailsResponse);
                    }
                    else
                    {
                        getsingle.WoNumber = workOrderMasterDetails.WoNumber;
                        getsingle.WoSerial = workOrderMasterDetails.WoSerial;
                        getsingle.WoNoAndSI = workOrderMasterDetails.WoNoAndSI;
                        getsingle.PartCode = workOrderMasterDetails.PartCode;
                        getsingle.PartDescription = workOrderMasterDetails.PartDescription;
                        getsingle.CustomerName = workOrderMasterDetails.CustomerName;
                        getsingle.Description = workOrderMasterDetails.Description;
                        getsingle.DrawingNumber = workOrderMasterDetails.DrawingNumber;



                        getsingle.getJobCardEntryDetailsResponseList.Add
                        (getJobCardEntryDetailsResponse);

                        response.getJobCardEntryCommonList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.WoNumber = workOrderMasterDetails.WoNumber;
                    getsingle.WoSerial = workOrderMasterDetails.WoSerial;
                    getsingle.WoNoAndSI = workOrderMasterDetails.WoNoAndSI;
                    getsingle.PartCode = workOrderMasterDetails.PartCode;
                    getsingle.PartDescription = workOrderMasterDetails.PartDescription;
                    getsingle.CustomerName = workOrderMasterDetails.CustomerName;
                    getsingle.Description = workOrderMasterDetails.Description;
                    getsingle.DrawingNumber = workOrderMasterDetails.DrawingNumber;

                    getsingle.getJobCardEntryDetailsResponseList.Add
                    (getJobCardEntryDetailsResponse);

                    response.getJobCardEntryCommonList.Add(getsingle);
                }
            }

            return response;
        }


        public GetWorkOrderResponseDto GetWorkOrder()
        {
            var response = new GetWorkOrderResponseDto()
            {
                GetWorkOrderResponse = new List<GetWorkOrderResponse>()
            };
            var responseDto = new GetWorkOrderResponse();

            var model = workOrderTypeRepository.GetWorkOrder();

            if (model != null)
            {
                responseDto = WorkOrderMapper((List<GetWorkOrderModel>)model.getWorkOrderModel, responseDto);
            }

            foreach (var workOrderMasterDetails in responseDto.getWorkOrderMasterDetailsResponse)
            {
                var getsingle = new GetWorkOrderResponse
                {
                    getWorkOrderMasterDetailsResponse = new List<GetWorkOrderMasterDetailsResponse>()
                };
                var getWorkOrderMasterDetailsResponse = new GetWorkOrderMasterDetailsResponse();
                getWorkOrderMasterDetailsResponse.PartCode = workOrderMasterDetails.PartCode;
                getWorkOrderMasterDetailsResponse.WorkOrderNumber = workOrderMasterDetails.WorkOrderNumber;
                getWorkOrderMasterDetailsResponse.WorkOrderSerial = workOrderMasterDetails.WorkOrderSerial;
                getWorkOrderMasterDetailsResponse.DCNumber = workOrderMasterDetails.DCNumber;
                getWorkOrderMasterDetailsResponse.DCDate = workOrderMasterDetails.DCDate;
                getWorkOrderMasterDetailsResponse.DCSerial = workOrderMasterDetails.DCSerial;
                getWorkOrderMasterDetailsResponse.DrawingNo = workOrderMasterDetails.DrawingNo;
                getWorkOrderMasterDetailsResponse.DrawingRev = workOrderMasterDetails.DrawingRev;
                getWorkOrderMasterDetailsResponse.PartCode = workOrderMasterDetails.PartCode;
                getWorkOrderMasterDetailsResponse.WOQuantity = workOrderMasterDetails.WOQuantity;
                getWorkOrderMasterDetailsResponse.Rate = workOrderMasterDetails.Rate;
                getWorkOrderMasterDetailsResponse.DeliveryDate = workOrderMasterDetails.DeliveryDate;
                getWorkOrderMasterDetailsResponse.MaterialCode = workOrderMasterDetails.MaterialCode;
                getWorkOrderMasterDetailsResponse.ItemCode = workOrderMasterDetails.ItemCode;
                getWorkOrderMasterDetailsResponse.HeatNo = workOrderMasterDetails.HeatNo;
                getWorkOrderMasterDetailsResponse.PONumber = workOrderMasterDetails.PONumber;
                getWorkOrderMasterDetailsResponse.PODate = workOrderMasterDetails.PODate;
                getWorkOrderMasterDetailsResponse.POSerial = workOrderMasterDetails.POSerial;
                getWorkOrderMasterDetailsResponse.PartDescription = workOrderMasterDetails.PartDescription;
                getWorkOrderMasterDetailsResponse.MaterialDescription = workOrderMasterDetails.MaterialDescription;
                getWorkOrderMasterDetailsResponse.IsDeletable = workOrderMasterDetails.IsDeletable;
                getWorkOrderMasterDetailsResponse.IsNew = false;

                if (response.GetWorkOrderResponse.Count > 0)
                {
                    var isExist = response.GetWorkOrderResponse.Any(woNumber => woNumber.WorkOrderNumber == workOrderMasterDetails.WorkOrderNumber);
                    if (isExist)
                    {
                        var index = response.GetWorkOrderResponse.FindIndex(a => a.WorkOrderNumber == workOrderMasterDetails.WorkOrderNumber);

                        response.GetWorkOrderResponse[index].getWorkOrderMasterDetailsResponse.Add(getWorkOrderMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.VendorCode = workOrderMasterDetails.VendorCode;
                        getsingle.WorkOrderNumber = workOrderMasterDetails.WorkOrderNumber;
                        getsingle.WorkOrderType = workOrderMasterDetails.WorkOrderType;
                        getsingle.WorkOrderDate = workOrderMasterDetails.WorkOrderDate;
                        getsingle.VendorName = workOrderMasterDetails.VendorName;
                        getsingle.MaxSerial = workOrderMasterDetails.MaxSerial;

                        getsingle.getWorkOrderMasterDetailsResponse.Add
                        (getWorkOrderMasterDetailsResponse);

                        response.GetWorkOrderResponse.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.VendorCode = workOrderMasterDetails.VendorCode;
                    getsingle.WorkOrderNumber = workOrderMasterDetails.WorkOrderNumber;
                    getsingle.WorkOrderType = workOrderMasterDetails.WorkOrderType;
                    getsingle.WorkOrderDate = workOrderMasterDetails.WorkOrderDate;
                    getsingle.VendorName = workOrderMasterDetails.VendorName;
                    getsingle.MaxSerial = workOrderMasterDetails.MaxSerial;

                    getsingle.getWorkOrderMasterDetailsResponse.Add
                    (getWorkOrderMasterDetailsResponse);

                    response.GetWorkOrderResponse.Add(getsingle);
                }
            }

            return response;
        }

        public GetWorkOrderHeatResponseDto GetWorkOrderHeatList(GetWorkOrderHeatRequest getWorkOrderHeatRequest)
        {
            var response = new GetWorkOrderHeatResponseDto()
            {
                getWorkOrderHeatDetails = new List<GetWorkOrderHeatDetailsResponse>()
            };
            var responseDto = new GetWorkOrderHeatResponseDto();
            var model = workOrderTypeRepository.GetWorkOrderHeatList(getWorkOrderHeatRequest.WorkOrderNumber);
            if (model != null)
            {
                responseDto = WorkOrderHeatMapper((List<GetWorkOrderHeatModel>)model.getWorkOrderHeatDetails, response);
            }

                return response;
        }

        public GetWorkOrderNumberForHeatResponseDto GetWorkOrderNumberHeat ()
        {
            var response = new GetWorkOrderNumberForHeatResponseDto()
            {
                getWorkOrderNumberHeatDetails = new List<GetWorkOrderNumberHeatResponseModel>()
            };
            var responseDto = new GetWorkOrderNumberForHeatResponseDto();
            var model = workOrderTypeRepository.GetWorkOrderNumberHeat();
            if (model != null)
            {
                responseDto = WorkOrderNumberHeatMapper((List<GetWorkOrderNumberHeatModelQM>)model.getWorkOrderNumberHeatDetails, response);
            }
            return response;
        }

        private GetWorkOrderNumberForHeatResponseDto WorkOrderNumberHeatMapper(List<GetWorkOrderNumberHeatModelQM> list, GetWorkOrderNumberForHeatResponseDto response)
        {
            Mapper.CreateMap<GetWorkOrderNumberHeatModelQM, GetWorkOrderNumberHeatResponseModel>();
            response.getWorkOrderNumberHeatDetails =
                Mapper.Map<List<GetWorkOrderNumberHeatModelQM>, List<GetWorkOrderNumberHeatResponseModel>>(list);

            return response;
        }

        private static GetWorkOrderResponse WorkOrderMapper(List<GetWorkOrderModel> list, GetWorkOrderResponse getWorkOrderResponseDto)
        {
            Mapper.CreateMap<GetWorkOrderModel, GetWorkOrderMasterDetailsResponse>();
            getWorkOrderResponseDto.getWorkOrderMasterDetailsResponse =
                Mapper.Map<List<GetWorkOrderModel>, List<GetWorkOrderMasterDetailsResponse>>(list);

            return getWorkOrderResponseDto;
        }

        private static GetWorkOrderHeatResponseDto WorkOrderHeatMapper(List<GetWorkOrderHeatModel> list, GetWorkOrderHeatResponseDto getWorkOrderHeatResponseDto)
        {
            Mapper.CreateMap<GetWorkOrderHeatModel, GetWorkOrderHeatDetailsResponse>();
            getWorkOrderHeatResponseDto.getWorkOrderHeatDetails =
                Mapper.Map<List<GetWorkOrderHeatModel>, List<GetWorkOrderHeatDetailsResponse>>(list);

            return getWorkOrderHeatResponseDto;
        }

        private static GetWorkOrderTypeResponseDto WorkOrderTypeMapper(List<WorkOrderTypeModel> list, GetWorkOrderTypeResponseDto getWorkOrderTypeResponseDto)
        {
            Mapper.CreateMap<WorkOrderTypeModel, WorkOrderTypeList>();
            getWorkOrderTypeResponseDto.WorkOrderTypeList =
                Mapper.Map<List<WorkOrderTypeModel>, List<WorkOrderTypeList>>(list);

            return getWorkOrderTypeResponseDto;
        }

        private static JobCardEntryCommon JobCardEntryMapper(List<GetJobCardEntryReportModel> list, JobCardEntryCommon getJobCardEntryReportResponseDto)
        {
            Mapper.CreateMap<GetJobCardEntryReportModel, JobCardEntryDetailsResponse>();
            getJobCardEntryReportResponseDto.getJobCardEntryDetailsResponseList =
                Mapper.Map<List<GetJobCardEntryReportModel>, List<JobCardEntryDetailsResponse>>(list);

            return getJobCardEntryReportResponseDto;
        }

    }
}
