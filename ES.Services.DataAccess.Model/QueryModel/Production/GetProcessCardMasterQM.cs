using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Production
{
    public class GetProcessCardMasterQM
    {
       public IEnumerable<GetProcessCardMasterQMModel> GetProcessCardMasterModelList { get; set; }
    }

    public class GetProcessCardMasterQMModel
    {
        public string SerialNo { get; set; }

        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public DateTime JobCardDate { get; set; }
    }
}
