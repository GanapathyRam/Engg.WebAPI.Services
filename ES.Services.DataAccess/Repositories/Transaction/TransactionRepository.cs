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

namespace ES.Services.DataAccess.Repositories.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
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
    }
}
