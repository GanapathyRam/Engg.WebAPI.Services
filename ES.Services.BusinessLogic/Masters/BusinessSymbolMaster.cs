using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.DataAccess.Interface.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Masters
{
   public class BusinessSymbolMaster : IBusinessSymbolMaster
    {
        private readonly ISymbolMasterRepository symbolMasterRepository;
    }
}
