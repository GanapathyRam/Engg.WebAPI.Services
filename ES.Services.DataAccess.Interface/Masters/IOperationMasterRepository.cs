using ES.Services.DataAccess.Model.CommandModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Masters
{
    public interface IOperationMasterRepository
    {
        AddOperationMasterQM AddOperationMaster(AddOperationMasterCM addOperationMasterCM);

        UpdateOperationMasterQM UpdateOperationMaster(UpdateOperationMasterCM updateOperationMasterCM);

        GetOperationMasterQM GetOperationMaster();
    }
}
