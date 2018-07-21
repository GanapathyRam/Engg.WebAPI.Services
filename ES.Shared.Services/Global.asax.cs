using Castle.DynamicProxy;
using ES.Services.BusinessLogic.Authentication;
using ES.Services.BusinessLogic.Despatch;
using ES.Services.BusinessLogic.Interface.Authentication;
using ES.Services.BusinessLogic.Interface.Despatch;
using ES.Services.BusinessLogic.Interface.Masters;
using ES.Services.BusinessLogic.Interface.Production;
using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.BusinessLogic.Interface.Sales;
using ES.Services.BusinessLogic.Interface.SubContract;
using ES.Services.BusinessLogic.Masters;
using ES.Services.BusinessLogic.Production;
using ES.Services.BusinessLogic.Registration;
using ES.Services.BusinessLogic.Sales;
using ES.Services.BusinessLogic.SubContract;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.DataAccess.Interface.Masters;
using ES.Services.DataAccess.Interface.Production;
using ES.Services.DataAccess.Interface.Registration;
using ES.Services.DataAccess.Interface.Sales;
using ES.Services.DataAccess.Interface.SubContract;
using ES.Services.DataAccess.Repositories.Authentication;
using ES.Services.DataAccess.Repositories.Despatch;
using ES.Services.DataAccess.Repositories.Masters;
using ES.Services.DataAccess.Repositories.Production;
using ES.Services.DataAccess.Repositories.Registration;
using ES.Services.DataAccess.Repositories.Sales;
using ES.Services.DataAccess.Repositories.SubContract;
using ES.Services.ReportLogic.Authentication;
using ES.Services.ReportLogic.Despatch;
using ES.Services.ReportLogic.Interface.Authentication;
using ES.Services.ReportLogic.Interface.Despatch;
using ES.Services.ReportLogic.Interface.Masters;
using ES.Services.ReportLogic.Interface.Production;
using ES.Services.ReportLogic.Interface.Sales;
using ES.Services.ReportLogic.Interface.SubContract;
using ES.Services.ReportLogic.Masters;
using ES.Services.ReportLogic.Production;
using ES.Services.ReportLogic.Sales;
using ES.Services.ReportLogic.SubContract;
using SS.Framework.AopInterceptor;
using StructureMap;
using System.Web.Http;

namespace ES.Shared.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ObjectFactory.Configure(x =>
            {
                x.For<IReportAuthentication>().Use<ReportAuthentication>();
                x.For<IBusinessAuthentication>().Use<BusinessAuthentication>();
                x.For<IAuthenticationRepository>().Use<AuthenticationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessAuthentication>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

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
                x.For<IReportVendorMaster>().Use<ReportVendorMaster>();
                x.For<IBusinessVendorMaster>().Use<BusinessVendorMaster>();
                x.For<IVendorMasterRepository>().Use<VendorMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessVendorMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IBusinessCompanyMaster>().Use<BusinessCompanyMaster>();
                x.For<ICompanyMastersRepository>().Use<CompanyMastersRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessCompanyMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportCategoryMaster>().Use<ReportCategoryMaster>();
                x.For<ICategoryMasterRepository>().Use<CategoryMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportCategoryMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportMaterialMaster>().Use<ReportMaterialMaster>();
                x.For<IBusinessMaterialMaster>().Use<BusinessMaterialMaster>();
                x.For<IMaterialMasterRepository>().Use<MaterialMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessMaterialMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportOperationMaster>().Use<ReportOperationMaster>();
                x.For<IBusinessOperationMaster>().Use<BusinessOperationMaster>();
                x.For<IOperationMasterRepository>().Use<OperationMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessOperationMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportToolsMaster>().Use<ReportToolsMaster>();
                x.For<IBusinessToolsMaster>().Use<BusinessToolsMaster>();
                x.For<IToolsMasterRepository>().Use<ToolsMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessToolsMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportJigsMaster>().Use<ReportJigsMaster>();
                x.For<IBusinessJigsMaster>().Use<BusinessJigsMaster>();
                x.For<IJigsMasterRepository>().Use<JigsMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessJigsMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportParameterMaster>().Use<ReportParameterMaster>();
                x.For<IBusinessParameterMaster>().Use<BusinessParameterMaster>();
                x.For<IParameterMasterRepository>().Use<ParameterMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessParameterMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });
            ObjectFactory.Configure(x =>
            {
                x.For<IReportSubcontractProcessMaster>().Use<ReportSubcontractProcessMaster>();
                x.For<IBusinessSubcontractProcessMaster>().Use<BusinessSubcontractProcessMaster>();
                x.For<ISubcontractProcessMasterRepository>().Use<SubcontractProcessMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessSubcontractProcessMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
                 {
                     x.For<IReportSymbolMaster>().Use<ReportSymbolMaster>();
                     x.For<IBusinessSymbolMaster>().Use<BusinessSymbolMaster>();
                     x.For<ISymbolMasterRepository>().Use<SymbolMasterRepository>();
                     var proxyGenerator = new ProxyGenerator();
                     var transactionInterceptor = new TransactionInterceptor();
                     x.For<IBusinessSymbolMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
                 });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportPartMaster>().Use<ReportPartMaster>();
                x.For<IBusinessPartMaster>().Use<BusinessPartMaster>();
                x.For<IPartMasterRepository>().Use<PartMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessPartMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportMachineMaster>().Use<ReportMachineMaster>();
                x.For<IBusinessMachineMaster>().Use<BusinessMachineMaster>();
                x.For<IMachineMasterRepository>().Use<MachineMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessMachineMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportInstrumentMaster>().Use<ReportInstrumentMaster>();
                x.For<IBusinessInstrumentMaster>().Use<BusinessInstrumentMaster>();
                x.For<IInstrumentMasterRepository>().Use<InstrumentMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IBusinessInstrumentMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            #region Sales

            ObjectFactory.Configure(x =>
            {
                x.For<IReportWorkOrder>().Use<ReportWorkOrder>();
                x.For<IBusinessWorkOrder>().Use<BusinessWorkOrder>();
                x.For<IWorkOrderRepository>().Use<WorkOrderRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportWorkOrder>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            #endregion

            #region Despatch

            ObjectFactory.Configure(x =>
            {
                x.For<IReportDeliveryChallan>().Use<ReportDeliveryChallan>();
                x.For<IBusinessDeliveryChallan>().Use<BusinessDeliveryChallan>();
                x.For<IDeliveryChallanRepository>().Use<DeliveryChallanRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportDeliveryChallan>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportInvoice>().Use<ReportInvoice>();
                x.For<IBusinessInvoice>().Use<BusinessInvoice>();
                x.For<IInvoiceRepository>().Use<InvoiceRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                //x.For<IReportInvoice>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
                x.For<IBusinessInvoice>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            #endregion

            #region Prodution
            ObjectFactory.Configure(x =>
            {
                x.For<IReportProcessCard>().Use<ReportProcessCard>();
                x.For<IBusinessProcessCard>().Use<BusinessProcessCard>();
                x.For<IProcessCardRepository>().Use<ProcessCardRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportProcessCard>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportJobCardGeneration>().Use<ReportJobCardGeneration>();
                x.For<IBusinessJobCardGeneration>().Use<BusinessJobCardGeneration>();
                x.For<IJobCardGenerationRepository>().Use<JobCardGenerationRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                //x.For<IReportJobCardGeneration>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
                x.For<IBusinessJobCardGeneration>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            ObjectFactory.Configure(x =>
            {
                x.For<IReportEmployeeMaster>().Use<ReportEmployeeMaster>();
                x.For<IEmployeeMasterRepository>().Use<EmployeeMasterRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportEmployeeMaster>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });

            #endregion

            #region Sub Contract
            ObjectFactory.Configure(x =>
            {
                x.For<IReportSubContract>().Use<ReportSubContract>();
                x.For<IBusinessSubContract>().Use<BusinessSubContract>();
                x.For<ISubContractRepository>().Use<SubContractRepository>();
                var proxyGenerator = new ProxyGenerator();
                var transactionInterceptor = new TransactionInterceptor();
                x.For<IReportSubContract>().EnrichAllWith(instance => proxyGenerator.CreateInterfaceProxyWithTarget(instance, transactionInterceptor));
            });
            #endregion

        }
    }
}
