using ES.Services.DataAccess.Commands.Production;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Model.CommandModel.Production;
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
    }
}
