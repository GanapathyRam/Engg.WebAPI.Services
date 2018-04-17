using AutoMapper;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using ES.Services.DataTransferObjects.Response.Production;
using ES.Services.ReportLogic.Interface.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Production
{
    public class ReportJobCardGeneration : IReportJobCardGeneration
    {
        private readonly IJobCardGenerationRepository jobCardGenerationRepository;

        public ReportJobCardGeneration(IJobCardGenerationRepository jobCardGenerationRepository)
        {
            this.jobCardGenerationRepository = jobCardGenerationRepository;
        }

        public GetJobCardGenerationResponseDto GetJobCardGeneration()
        {
            var response = new GetJobCardGenerationResponseDto();

            var model = jobCardGenerationRepository.GetJobCardGeneration();

            if (model != null)
            {
                response = GetJobCardGenerationMapper((List<GetJobCardGenerationModel>)model.GetJobCardGenerationModelList, response);
            }

            return response;
        }

        public GetJobCardMaintanceResponseDto GetJobCardMaintane()
        {
            var response = new GetJobCardMaintanceResponseDto()
            {
                GetJobCardMaintanceResponseList = new List<GetJobCardMaintanceMaster>()
            };

            var model = jobCardGenerationRepository.GetJobCardMaintane();

            foreach (var dcMasterDetails in model.getJobCardMaintanceQMModelList)
            {
                var getsingle = new GetJobCardMaintanceMaster
                {
                    getJobCardMaintanceDetails = new List<GetJobCardMaintanceDetails>()
                };
                var getWoMasterDetailsResponse = new GetJobCardMaintanceDetails();

                getWoMasterDetailsResponse.Serial = dcMasterDetails.Serial;
                getWoMasterDetailsResponse.SerialNo = dcMasterDetails.SerialNo;
                getWoMasterDetailsResponse.PartCode = dcMasterDetails.PartCode;
                getWoMasterDetailsResponse.SequenceNumber = dcMasterDetails.SequenceNumber;
                getWoMasterDetailsResponse.DimensionMax = dcMasterDetails.DimensionMax;
                getWoMasterDetailsResponse.DimensionMin = dcMasterDetails.DimensionMin;
                getWoMasterDetailsResponse.Description = dcMasterDetails.Description;
                getWoMasterDetailsResponse.DimensionActual = dcMasterDetails.DimensionActual;
                getWoMasterDetailsResponse.ParameterCode = dcMasterDetails.ParameterCode;
                getWoMasterDetailsResponse.InstrumentCode = dcMasterDetails.InstrumentCode;
                getWoMasterDetailsResponse.ToolCode = dcMasterDetails.ToolCode;
                getWoMasterDetailsResponse.DRFlag = dcMasterDetails.DRFlag;
                getWoMasterDetailsResponse.Symbol = dcMasterDetails.Symbol;
                getWoMasterDetailsResponse.Datum = dcMasterDetails.Datum;
                getWoMasterDetailsResponse.DatumDimension = dcMasterDetails.DatumDimension;
                getWoMasterDetailsResponse.BooleanNumber = dcMasterDetails.BooleanNumber;
                getWoMasterDetailsResponse.DatumDimesionActual = dcMasterDetails.DatumDimesionActual;
                getWoMasterDetailsResponse.ParameterDescription = dcMasterDetails.ParameterDescription;
                getWoMasterDetailsResponse.InstrumentName = dcMasterDetails.InstrumentName;
                getWoMasterDetailsResponse.ToolDescription = dcMasterDetails.ToolDescription;

                //getWoMasterDetailsResponse.IsNew = dcMasterDetails.IsNew ? false : true;

                if (response.GetJobCardMaintanceResponseList.Count > 0)
                {
                    var isExist = response.GetJobCardMaintanceResponseList.Any(dcMaster => dcMaster.PartCode == dcMasterDetails.PartCode && dcMaster.SequenceNumber == dcMasterDetails.SequenceNumber);
                    if (isExist)
                    {
                        var index = response.GetJobCardMaintanceResponseList.FindIndex(a => a.PartCode == dcMasterDetails.PartCode && a.SequenceNumber == dcMasterDetails.SequenceNumber);

                        response.GetJobCardMaintanceResponseList[index].getJobCardMaintanceDetails.Add(getWoMasterDetailsResponse);
                    }
                    else
                    {
                        getsingle.PartCode = dcMasterDetails.PartCode;
                        getsingle.SequenceNumber = dcMasterDetails.SequenceNumber;
                        getsingle.MachineCode = dcMasterDetails.MachineCode;
                        getsingle.MachineName = dcMasterDetails.MachineName;
                        getsingle.JigCode = dcMasterDetails.JigCode;
                        getsingle.JigsDescription = dcMasterDetails.JigsDescription;
                        getsingle.PartDescription = dcMasterDetails.PartDescription;
                        getsingle.SettingTime = dcMasterDetails.SettingTime;
                        getsingle.RunningTime = dcMasterDetails.RunningTime;
                        getsingle.ActualSettingTime = dcMasterDetails.ActualSettingTime;
                        getsingle.ActualRunningTime = dcMasterDetails.ActualRunningTime;
                        getsingle.OperationDate = dcMasterDetails.OperationDate;
                        getsingle.EmployeeCode = dcMasterDetails.EmployeeCode;
                        getsingle.Shift = dcMasterDetails.Shift;

                        //if (!dcMasterDetails.IsDelete)
                        //{
                        getsingle.getJobCardMaintanceDetails.Add
                        (getWoMasterDetailsResponse);
                        //}

                        response.GetJobCardMaintanceResponseList.Add(getsingle);
                    }
                }
                else
                {
                    getsingle.PartCode = dcMasterDetails.PartCode;
                    getsingle.SequenceNumber = dcMasterDetails.SequenceNumber;
                    getsingle.MachineCode = dcMasterDetails.MachineCode;
                    getsingle.MachineName = dcMasterDetails.MachineName;
                    getsingle.JigCode = dcMasterDetails.JigCode;
                    getsingle.JigsDescription = dcMasterDetails.JigsDescription;
                    getsingle.PartDescription = dcMasterDetails.PartDescription;
                    getsingle.SettingTime = dcMasterDetails.SettingTime;
                    getsingle.RunningTime = dcMasterDetails.RunningTime;
                    getsingle.ActualSettingTime = dcMasterDetails.ActualSettingTime;
                    getsingle.ActualRunningTime = dcMasterDetails.ActualRunningTime;
                    getsingle.OperationDate = dcMasterDetails.OperationDate;
                    getsingle.EmployeeCode = dcMasterDetails.EmployeeCode;
                    getsingle.Shift = dcMasterDetails.Shift;
                    //if (!dcMasterDetails.IsDelete)
                    //{
                    getsingle.getJobCardMaintanceDetails.Add
                    (getWoMasterDetailsResponse);
                    //}
                    response.GetJobCardMaintanceResponseList.Add(getsingle);
                }
            }

            return response;
        }

        #region Mapper Method

        private static GetJobCardGenerationResponseDto GetJobCardGenerationMapper(List<GetJobCardGenerationModel> list, GetJobCardGenerationResponseDto getJobCardGenerationResponseDto)
        {
            Mapper.CreateMap<GetJobCardGenerationModel, GetJobCardGenerationResponse>();
            getJobCardGenerationResponseDto.GetJobCardGenerationResponseList =
                Mapper.Map<List<GetJobCardGenerationModel>, List<GetJobCardGenerationResponse>>(list);

            return getJobCardGenerationResponseDto;
        }

        #endregion
    }
}
