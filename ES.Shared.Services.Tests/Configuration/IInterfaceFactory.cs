using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.ReportLogic.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Shared.Services.Tests.Configuration
{
    public interface IInterfaceFactory
    {
        IBusinessRegistration RegistrationBusinessProvider();

        IReportAuthentication AuthenticationBusinessProvider();
    }
}
