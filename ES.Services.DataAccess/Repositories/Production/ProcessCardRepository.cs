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
    public class ProcessCardRepository : IProcessCardRepository
    {
        public void AddProcessCard(AddProcessCardCM addProcessCardCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ProcessCardInsertCommand { Connection = connection };
                command.Execute(addProcessCardCM.PartCode,addProcessCardCM.SequenceNumber, addProcessCardCM.MachineCode, addProcessCardCM.JigCode,
                    addProcessCardCM.SettingTime, addProcessCardCM.RunningTime, addProcessCardCM.ListProcessCardDetails.ToDataTableWithNull(), addProcessCardCM);
            }
        }

        public GetSequenceNumberQM GetSequenceNumber(decimal PartCode)
        {
            GetSequenceNumberQM model = new GetSequenceNumberQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSequenceNumberSelectCommand { Connection = connection };
                model = command.Execute(PartCode);
            }

            return model;
        }

        public GetProcessCardQM GetProcessCard()
        {
            GetProcessCardQM model = new GetProcessCardQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetProcessCardSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void UpdateProcessCard(AddProcessCardCM addProcessCardCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ProcessCardUpdateCommand { Connection = connection };
                command.Execute(addProcessCardCM.PartCode, addProcessCardCM.SequenceNumber, addProcessCardCM.MachineCode, addProcessCardCM.JigCode,
                    addProcessCardCM.SettingTime, addProcessCardCM.RunningTime, addProcessCardCM.ListProcessCardDetails.ToDataTableWithNull(), addProcessCardCM);
            }
        }
    }
}
