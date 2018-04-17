﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Production
{
    public class GetJobCardMaintanceResponseDto : BaseResponse
    {
        public List<GetJobCardMaintanceMaster> GetJobCardMaintanceResponseList { get; set; }
    }

    public class GetJobCardMaintanceMaster
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string SerialNo { get; set; }

        public decimal MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal JigCode { get; set; }

        public string JigsDescription { get; set; }

        public string PartDescription { get; set; }

        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public decimal ActualSettingTime { get; set; }

        public decimal ActualRunningTime { get; set; }

        public DateTime OperationDate { get; set; }

        public string EmployeeCode { get; set; }

        public string Shift { get; set; }

        //public bool IsNew { get; set; }

        public List<GetJobCardMaintanceDetails> getJobCardMaintanceDetails { get; set; }

    }

    public class GetJobCardMaintanceDetails
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string SerialNo { get; set; }

        public decimal Serial { get; set; }

        public string Description { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionMin { get; set; }

        public string DimensionActual { get; set; }

        public string ParameterCode { get; set; }

        public string InstrumentCode { get; set; }

        public string ToolCode { get; set; }

        public bool DRFlag { get; set; }

        public string Symbol { get; set; }

        public string Datum { get; set; }

        public string DatumDimension { get; set; }

        public string BooleanNumber { get; set; }

        public string DatumDimesionActual { get; set; }

        public string ParameterDescription { get; set; }

        public string InstrumentName { get; set; }

        public string ToolDescription { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
