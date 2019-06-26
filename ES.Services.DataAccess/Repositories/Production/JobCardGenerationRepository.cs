using ES.Services.DataAccess.Commands.Production;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.CommandModel.Production;
using ES.Services.DataAccess.Model.QueryModel.Production;
using SS.Framework.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Production
{
    public class JobCardGenerationRepository : IJobCardGenerationRepository
    {
        public GetJobCardGenerationQM GetJobCardGeneration()
        {
            GetJobCardGenerationQM model = new GetJobCardGenerationQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetJobCardGenerationSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void AddJobCardGeneration()
        {
            GetJobCardGenerationQM model = new GetJobCardGenerationQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetJobCardGenerationSelectCommand { Connection = connection };
                model = command.Execute();
            }
        }

        public GetProcessCardMasterQM GetProcessCardMaster(decimal PartCode)
        {
            GetProcessCardMasterQM model = new GetProcessCardMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetProcessCardMasterSelectCommand { Connection = connection };
                model = command.Execute(PartCode);
            }

            return model;
        }

        public GetProcessCardDetailsQM GetProcessCardDetails(decimal PartCode)
        {
            GetProcessCardDetailsQM model = new GetProcessCardDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetProcessCardDetailsSelectCommand { Connection = connection };
                model = command.Execute(PartCode);
            }

            return model;
        }

        public void AddJobCardMasterAndDetails(AddJobCardMasterAndDetailsCM addJobCardMasterAndDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new JobCardMasterAndDetailsInsertCommand { Connection = connection };
                command.Execute(addJobCardMasterAndDetailsCM.AddJobCardMasterCMList.ToDataTableWithNull(), addJobCardMasterAndDetailsCM.AddJobCardDetailsCMList.ToDataTableWithNull());
            }
        }

        public GetJobCardMaintanceQM GetJobCardMaintane(string SerialNo)
        {
            GetJobCardMaintanceQM model = new GetJobCardMaintanceQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetJobCardMaintanceSelectCommand { Connection = connection };
                model = command.Execute(SerialNo);
            }

            return model;
        }

        public void UpdateJobCardMaintance(UpdateJobCardMaintanceCM updateJobCardMaintanceCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new UpdateJobCardMaintanceUpdateCommand { Connection = connection };
                command.Execute(updateJobCardMaintanceCM.GetUpdateJobCardDetails.ToDataTableWithNull(), updateJobCardMaintanceCM);
            }
        }

        public void DeleteJobCardDetails(string serialNo, decimal partCode, decimal sequenceNumber)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new JobCardMaintanceDeleteCommand { Connection = connection };
                command.Execute(serialNo, partCode, sequenceNumber);
            }
        }
    }
}
