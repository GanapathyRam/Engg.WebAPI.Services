using ES.Services.DataAccess.Model.CommandModel.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using ES.Services.DataTransferObjects.Response.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Production
{
    public interface IJobCardGenerationRepository
    {
        GetJobCardGenerationQM GetJobCardGeneration();

        GetProcessCardMasterQM GetProcessCardMaster(decimal PartCode);

        GetProcessCardDetailsQM GetProcessCardDetails(decimal PartCode);

        void AddJobCardMasterAndDetails(AddJobCardMasterAndDetailsCM addJobCardMasterAndDetailsCM);

        GetJobCardMaintanceQM GetJobCardMaintane(string SerialNo);

        void UpdateJobCardMaintance(UpdateJobCardMaintanceCM updateJobCardMaintanceCM);

        void DeleteJobCardDetails(string serialNo, decimal partCode, decimal sequenceNumber);
    }
}
