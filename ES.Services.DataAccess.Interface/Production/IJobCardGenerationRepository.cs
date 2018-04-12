using ES.Services.DataAccess.Model.CommandModel.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
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

        GetProcessCardMasterQM GetProcessCardMaster(decimal PartCode, decimal SequenceNumber);

        GetProcessCardDetailsQM GetProcessCardDetails(decimal PartCode, decimal SequenceNumber);

        void AddJobCardMasterAndDetails(AddJobCardMasterAndDetailsCM addJobCardMasterAndDetailsCM);
    }
}
