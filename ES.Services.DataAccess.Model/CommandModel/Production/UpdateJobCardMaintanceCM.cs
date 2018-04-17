using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Production
{
    public class UpdateJobCardMaintanceCM
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string SerialNo { get; set; }

        public decimal ActualSettingTime { get; set; }

        public decimal ActualRunningTime { get; set; }

        public DateTime OperationDate { get; set; }

        public string Shift { get; set; }

        public string EmployeeCode { get; set; }

        public IEnumerable<UpdateJobCardDetails> GetUpdateJobCardDetails { get; set; }
    }

    public class UpdateJobCardDetails
    {
        public string SerialNo { get; set; }

        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal Serial { get; set; }

        public string DimensionActual { get; set; }

        public string DatumDimensionActual { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
