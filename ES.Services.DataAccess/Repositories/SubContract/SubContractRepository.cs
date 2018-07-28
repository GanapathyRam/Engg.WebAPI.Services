using ES.Services.DataAccess.Interface.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataAccess.Model.QueryModel.SubContract;
using ES.Services.DataAccess.Commands.Despatch;
using ES.Services.DataAccess.Commands.SubContract;
using ES.Services.DataAccess.Model.CommandModel.SubContract;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Repositories.SubContract
{
    public class SubContractRepository : ISubContractRepository
    {
        public GetSubContractSendingResponseQM GetSubContractSendingDetails()
        {
            var model = new GetSubContractSendingResponseQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSubContractSendingSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void AddScSerial(ScDetailSerialCM scDetailSerialCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScSerialInsertCommand { Connection = connection };
                command.Execute(scDetailSerialCM.ScDetailSerialItems.ToDataTableWithNull(), scDetailSerialCM);
            }
        }

        public void AddSubContractMasterDetails(DateTime SubContractDcDate, string SubContractDcNumber, decimal SubContractSentFor, string Vehicle, long VendorCode, string Remarks)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScMasterCommonInsertCommand { Connection = connection };
                command.Execute(SubContractDcDate, SubContractDcNumber, SubContractSentFor, Vehicle, VendorCode, Remarks);
            }
        }

        public void UpdateScDetails(string ScNumber, string WoNumber, decimal WoSerial, decimal PartCode)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScDetailsInsertCommand { Connection = connection };
                command.Execute(ScNumber, WoNumber, WoSerial, PartCode);
            }
        }

        public void AddScDetails(string ScNumber, string WoNumber, decimal WoSerial, decimal PartCode)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScDetailsInsertCommand { Connection = connection };
                command.Execute(ScNumber, WoNumber, WoSerial, PartCode);
            }
        }

        public GetScMasterQM GetScMaster()
        {
            GetScMasterQM getScMasterQM = new GetScMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetScMasterSelectCommand { Connection = connection };
                getScMasterQM = command.Execute();
            }

            return getScMasterQM;
        }

        public void DeleteScSendingDetails(DeleteScDetailsCM deleteScDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcDeleteCommand { Connection = connection };
                command.Execute(deleteScDetailsCM.scDetailsListItems.ToDataTableWithNull(), deleteScDetailsCM.ScNumer, deleteScDetailsCM.WoNumber, deleteScDetailsCM.IsDeleteFrom);
            }
        }

        public string GetSCSendingDCNumber(int DcNumberFor)
        {
            string DcNumberForSCSending = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSCSendingDCNumberSelectCommand { Connection = connection };
                DcNumberForSCSending = command.Execute(DcNumberFor);
            }

            return DcNumberForSCSending;
        }

        public GetScDetailsAndSerialsQM GetSubContractDetailAndSerials(Int64 vendorCode, string DcNumber)
        {
            var model = new GetScDetailsAndSerialsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetScDetailsAndSerialSelectCommand { Connection = connection };
                model = command.Execute(vendorCode, DcNumber);
            }

            return model;
        }

        #region Subcontract Receiving

        public void AddSubContractReceiveMasterDetails(DateTime ScReceivingDcDate, string ScReceivingDcNumber, Int64 VendorCode, string VendorDCNumber, DateTime ScReceivingVendorDate, string Vehicle, string Remarks)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScReceivingMasterCommonInsertCommand { Connection = connection };
                command.Execute(ScReceivingDcDate, ScReceivingDcNumber, VendorCode, VendorDCNumber, ScReceivingVendorDate,  Vehicle, Remarks);
            }
        }

        public void AddScReceivingDetails(string ScReceivingNumber, string WoNumber, decimal WoSerial, decimal PartCode)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScReceivingDetailsInsertCommand { Connection = connection };
                command.Execute(ScReceivingNumber, WoNumber, WoSerial, PartCode);
            }
        }

        public void AddScReceivingSerial(ScReceivingDetailSerialCM scReceivingDetailSerialCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new ScReceivingSerialInsertCommand { Connection = connection };
                command.Execute(scReceivingDetailSerialCM.ScReceivingDetailSerialItems.ToDataTableWithNull(), scReceivingDetailSerialCM);
            }
        }

        public GetSubContractReceivingResponseQM GetSubContractReceivingDetails(Int64 VendorCode)
        {
            var model = new GetSubContractReceivingResponseQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSubContractReceivingSelectCommand { Connection = connection };
                model = command.Execute(VendorCode);
            }

            return model;
        }

        public GetScReceivingDetailsAndSerialsQM GetScReceivingDetailAndSerials(Int64 VendorCode, string DcNumber)
        {
            var model = new GetScReceivingDetailsAndSerialsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetScReceivingDetailsAndSerialSelectCommand { Connection = connection };
                model = command.Execute(VendorCode, DcNumber);
            }

            return model;
        }

        public GetScReceivingMasterQM GetScReceivingMaster()
        {
            GetScReceivingMasterQM getScReceivingMasterQM = new GetScReceivingMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetScReceivingMasterSelectCommand { Connection = connection };
                getScReceivingMasterQM = command.Execute();
            }

            return getScReceivingMasterQM;
        }


        #endregion
    }
}
