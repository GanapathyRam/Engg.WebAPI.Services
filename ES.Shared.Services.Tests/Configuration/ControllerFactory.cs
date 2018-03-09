using System;
using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.ReportLogic.Interface.Authentication;
using ES.Shared.Services.Controllers.Registration;
using ES.Shared.Services.Controllers.Authentication;

namespace ES.Shared.Services.Tests.Configuration
{
    public class ControllerFactory : IInterfaceFactory
    {
        public IReportAuthentication AuthenticationBusinessProvider()
        {
            return new AuthenticationController();
        }

        public IBusinessRegistration RegistrationBusinessProvider()
        {
            return new RegistrationController();
        }
    }
}
