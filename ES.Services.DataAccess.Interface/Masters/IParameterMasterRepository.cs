using ES.Services.DataAccess.Model.CommandModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Masters
{
    public interface IParameterMasterRepository
    {
        AddParameterMasterQM AddParameterMaster(AddParameterMasterCM addParameterMasterCM);

        UpdateParameterMasterQM UpdateParameterMaster(UpdateParameterMasterCM updateParameterMasterCM);

        GetParameterMasterQM GetParameterMaster();
    }
}
