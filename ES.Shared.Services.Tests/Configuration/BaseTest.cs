using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Shared.Services.Tests.Configuration
{
    public class BaseTest
    {
        private IInterfaceFactory factory = InterfaceFactoryConfig.GetInstance();

        public IInterfaceFactory Factory
        {
            get { return factory; }
        }
    }
}
