using ES.Services.DataAccess.Model.CommandModel.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Production
{
    public interface IProcessCardRepository
    {
        void AddProcessCard(AddProcessCardCM addProcessCardCM);
    }
}
