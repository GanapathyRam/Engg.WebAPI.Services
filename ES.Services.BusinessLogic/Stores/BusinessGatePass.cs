using ES.Services.BusinessLogic.Interface.Stores;
using ES.Services.DataAccess.Interface.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Stores
{
    public class BusinessGatePass: IBusinessGatePass
    {
        private readonly IGatePassRepository gatePassRepository;

        public BusinessGatePass(IGatePassRepository gatePassRepository)
        {
            this.gatePassRepository = gatePassRepository;
        }

    }
}
