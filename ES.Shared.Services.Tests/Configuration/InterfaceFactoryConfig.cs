using Castle.DynamicProxy;
using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.BusinessLogic.Registration;
using ES.Services.DataAccess.Interface.Registration;
using ES.Services.DataAccess.Repositories.Registration;
using ES.Services.ReportLogic.Interface.Authentication;
using ES.Services.ReportLogic.Authentication;
using SS.Framework.AopInterceptor;
using StructureMap;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Repositories.Authentication;

namespace ES.Shared.Services.Tests.Configuration
{
    public static class InterfaceFactoryConfig
    {
        static InterfaceFactoryConfig()
        {
            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessRegistration>().Use<BusinessRegistration>();
                x.For<IRegistrationRepository>().Use<RegistrationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessRegistration>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });
            ObjectFactory.Configure(x =>
            {
                x.For<IReportAuthentication>().Use<ReportAuthentication>();
                x.For<IAuthenticationRepository>().Use<AuthenticationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessRegistration>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x => x.For<IInterfaceFactory>().Use<ControllerFactory>());
            ////x.For<IInterfaceFactory>().Use<GatewayFactory>();
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="IInterfaceFactory"/>.
        /// </returns>
        public static IInterfaceFactory GetInstance()
        {
            return ObjectFactory.GetInstance<IInterfaceFactory>();
        }
    }
}
