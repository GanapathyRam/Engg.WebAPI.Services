﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Production
{
    public class UpdateProcessCardCM
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public string SettingTime { get; set; }

        public string RunningTime { get; set; }

        public IList<UpdateProcessCardDetailsCmModel> ListUpdateProcessCardDetails { get; set; }
    }

    public class UpdateProcessCardMasterCmModel
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public string SettingTime { get; set; }

        public string RunningTime { get; set; }

    }

    public class UpdateProcessCardDetailsCmModel
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal SerialNo { get; set; }

        public string Description { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionMin { get; set; }

        public string ParameterCode { get; set; }

        public string InstrumentCode { get; set; }

        public string ToolCode { get; set; }

        public bool DRFlag { get; set; }

        public string Symbol { get; set; }

        public string Datum { get; set; }

        public string DatumDimension { get; set; }

        public string BooleanNumber { get; set; }
    }
}
