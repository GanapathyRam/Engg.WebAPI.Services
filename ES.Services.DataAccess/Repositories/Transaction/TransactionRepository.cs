using ES.Services.DataAccess.Interface.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataAccess.Model.CommandModel.Transaction;
using ES.Services.DataAccess.Commands.Transaction;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Transaction;

namespace ES.Services.DataAccess.Repositories.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        #region PO
        public void AddPoDetails(AddPoDetailsCM addPoDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoDetailsInsertCommand { Connection = connection };
                command.Execute(addPoDetailsCM.AddPoDetailsCMItems.ToDataTableWithNull(), addPoDetailsCM);
            }
        }

        public void AddPoMaster(AddPoMasterCM addPoMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoMasterInsertCommand { Connection = connection };
                command.Execute(addPoMasterCM);
            }

        }

        public string GetPoNumber()
        {
            string poNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoNumberSelectCommand { Connection = connection };
                poNumber = command.Execute();
            }

            return poNumber;
        }

        public GetVendorTermsMasterQM GetVendorTermsMaster(Int64 VendorCode)
        {
            var model = new GetVendorTermsMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new TermsMasterFromCodeSelectCommand { Connection = connection };
                model = command.Execute(VendorCode);
            }

            return model;

        }

        public GetRateMasterDetailsFromVendorCodeQM GetRateMasterDetailsFromVendorCode(Int64 VendorCode, decimal ItemCode)
        {
            var model = new GetRateMasterDetailsFromVendorCodeQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetRateMasterDetailsFromVendorCode { Connection = connection };
                model = command.Execute(VendorCode, ItemCode);
            }

            return model;

        }

        public GetPOTypeQM GetPOTypeMaster()
        {
            var model = new GetPOTypeQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetPOTypeMasterSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;

        }

        public void UpdatePoMaster(AddPoMasterCM addPoMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoMasterUpdateCommand { Connection = connection };
                command.Execute(addPoMasterCM);
            }

        }

        public void UpdatePoDetails(UpdatePoDetailsCM updatePoDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoDetailsUpdateCommand { Connection = connection };
                command.Execute(updatePoDetailsCM.UpdatePoDetailsCMItems.ToDataTableWithNull(), updatePoDetailsCM);
            }
        }

        public void DeletePoMasterAndDetails(string PoNumber, decimal PoSerialNo, int IsDeleteFrom)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new PoMasterAndDetailsDeleteCommand { Connection = connection };
                command.Execute(PoNumber, PoSerialNo, IsDeleteFrom);
            }
        }

        public GetPoResponseQM GetPoMasterAndDetails()
        {
            var model = new GetPoResponseQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetPoMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;

        }

        #endregion

        #region GRN

        public string GetGRNNumber()
        {
            string GRNNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNNumberSelectCommand { Connection = connection };
                GRNNumber = command.Execute();
            }

            return GRNNumber;
        }

        public GetGRNDetailsQM GetGRNDetails(Int64 VendorCode)
        {
            var model = new GetGRNDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetGRNDetailsFromVendorCodeSelectCommand { Connection = connection };
                model = command.Execute(VendorCode);
            }

            return model;

        }

        public GetGRNSupplierNameQM GetGRNSupplierName()
        {
            var model = new GetGRNSupplierNameQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetGRNSupplierNameSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;

        }

        public void AddGRNMaster(AddGRNMasterCM addGRNMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNMasterInsertCommand { Connection = connection };
                command.Execute(addGRNMasterCM);
            }
        }

        public void AddGRNDetails(AddGRNDetailsCM addGRNDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNDetailsInsertCommand { Connection = connection };
                command.Execute(addGRNDetailsCM.AddGRNDetailsCMItems.ToDataTableWithNull(), addGRNDetailsCM);
            }
        }

        public void UpdateGRNMaster(AddGRNMasterCM updateGRNMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNMasterUpdateCommand { Connection = connection };
                command.Execute(updateGRNMasterCM);
            }
        }

        public void UpdateGRNDetails(UpdateGRNDetailsCM updateGRNDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNDetailsUpdateCommand { Connection = connection };
                command.Execute(updateGRNDetailsCM.UpdateGRNDetailsCMItems.ToDataTableWithNull(), updateGRNDetailsCM);
            }
        }

        public GetGRNMasterAndDetailsQM GetGRNMasterAndDetails()
        {
            var model = new GetGRNMasterAndDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetGRNMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void DeleteGRNMasterAndDetails(string GRNNumber, decimal GRNSerialNo, DeleteGRNDetailsCM deleteGRNDetailsCM, int IsDeleteFrom)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNMasterAndDetailsDeleteCommand { Connection = connection };
                command.Execute(GRNNumber, GRNSerialNo, deleteGRNDetailsCM.DeleteGRNDetailsCMList.ToDataTableWithNull(), IsDeleteFrom);
            }
        }

        #endregion

        #region Issues

        public string GetIssuesNumber()
        {
            string IssuesNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GRNNumberSelectCommand { Connection = connection };
                IssuesNumber = command.Execute();
            }

            return IssuesNumber;
        }

        public void AddIssueMaster(AddIssueMasterCM addIssueMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new IssueMasterInsertCommand { Connection = connection };
                command.Execute(addIssueMasterCM);
            }
        }

        public void AddIssueDetails(AddIssueDetailsCM addIssueDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new IssueDetailsInsertCommand { Connection = connection };
                command.Execute(addIssueDetailsCM.AddIssueDetailsCMItems.ToDataTableWithNull(), addIssueDetailsCM);
            }
        }

        public void UpdateIssueMaster(UpdateIssueMasterCM updateIssueMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new IssueMasterUpdateCommand { Connection = connection };
                command.Execute(updateIssueMasterCM);
            }
        }

        public void UpdateIssueDetails(UpdateIssueDetailsCM updateIssueDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new IssueDetailsUpdateCommand { Connection = connection };
                command.Execute(updateIssueDetailsCM.UpdateIssueDetailsCMItems.ToDataTableWithNull(), updateIssueDetailsCM);
            }
        }

        public GetIssueMasterAndDetailsQM GetIssueMasterAndDetails()
        {
            var model = new GetIssueMasterAndDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSavedIssueMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public GetIssueDetailsQM GetIssueDetails()
        {
            var model = new GetIssueDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetIssueDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void DeleteIssueMasterAndDetails(string IssueNumber, decimal IssueSerialNo, DeleteIssueDetailsCM deleteIssueDetailsCM, int IsDeleteFrom)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new IssueMasterAndDetailsDeleteCommand { Connection = connection };
                command.Execute(IssueNumber, IssueSerialNo, deleteIssueDetailsCM.DeleteIssueDetailsCMItemList.ToDataTableWithNull(), IsDeleteFrom);
            }
        }


        #endregion
    }
}
