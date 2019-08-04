using ES.Services.DataAccess.Commands.Stores;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using SS.Framework.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Stores
{
   public class GatePassRepository: IGatePassRepository
    {
        public GPTypeMasterQM getGPTypeMaster()
        {
            GPTypeMasterQM gpTypeMasterQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var rolesInsertCommand = new GPTypeMasterSelectCommand { Connection = connection };
                gpTypeMasterQM = rolesInsertCommand.Execute();
            }
            return gpTypeMasterQM;
        }

        public GetUnitMasterQM GetUnitMaster()
        {
            GetUnitMasterQM getUnitMasterQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var rolesInsertCommand = new GetUnitMasterSelectCommand { Connection = connection };
                getUnitMasterQM = rolesInsertCommand.Execute();
            }
            return getUnitMasterQM;
        }

        public GetGPReceiptVendorQM getGPReceiptVendor()
        {
            GetGPReceiptVendorQM getGPReceiptVendorQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GetGPReceiptVendorSelectCommand { Connection = connection };
                getGPReceiptVendorQM = rolesInsertCommand.Execute();
            }
            return getGPReceiptVendorQM;
        }

        public string getGPSendingNumber(string gpType)
        {
            string GPNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GPSendingNumberSelectCommand { Connection = connection };
                GPNumber = gPNumberCommand.Execute(gpType);
            }
            return GPNumber;
        }

        public string getGPReceiptNumber()
        {
            string GPReceiptNumber = string.Empty;

            using(var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GPReceiptNumberSelectCommand { Connection = connection };
                GPReceiptNumber = gPNumberCommand.Execute();
            }
            return GPReceiptNumber;
        }

        public void SaveGPSendingMaster(string GPType, string GPNumber, Int64 VendorCode, DateTime GPDate, string RequestedBy, string Remarks)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPSendingMasterInsertCommand { Connection = connection };
                command.Execute(GPType, GPNumber, VendorCode, GPDate, RequestedBy, Remarks, new Guid(), DateTime.UtcNow);
            }
        }

        public void SaveGPSendingDetails(GPSendingDetailsCM GPSendingDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPSendingDetailsInsertCommand { Connection = connection };
                command.Execute(GPSendingDetailsCM.GPSendingDetailsListItemsCM.ToDataTableWithNull(), GPSendingDetailsCM);
            }
        }

        public GetGPSendingQM GetGPSendingMasterAndDetails()
        {
            var model = new GetGPSendingQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPSendingMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public void DeleteGPSendingMasterAndDetails(DeleteGPSendingCM DeleteGPSendingCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPSendingDeleteCommand { Connection = connection };
                command.Execute(DeleteGPSendingCM.DeleteGPSendingDetailsCM.ToDataTableWithNull(), DeleteGPSendingCM.GPNumber, DeleteGPSendingCM.IsDeleteFrom);
            }
        }

        public GetGPReceivingResponseQM GetGPReceivingMasterAndDetails(Int64 VendorCode)
        {
            var model = new GetGPReceivingResponseQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetReceivingMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute(VendorCode);
            }

            return model;
        }

        public void SaveGPReceivingMaster(string GPReceiptNumber, DateTime ReceiptDate, Int64 VendorCode, string DocumentId, DateTime DocumentDate, string Remarks)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPReceivingMasterInsertCommand { Connection = connection };
                command.Execute(GPReceiptNumber, ReceiptDate, VendorCode, DocumentId, DocumentDate, Remarks, new Guid(), DateTime.UtcNow);
            }
        }

        public void SaveGPReceivingDetails(GPReceivingDetailsCM GPReceivingDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPReceivingDetailsInsertCommand { Connection = connection };
                command.Execute(GPReceivingDetailsCM.GPReceivingDetailsListItemsCM.ToDataTableWithNull(), GPReceivingDetailsCM);
            }
        }


        public GetGPReceivedDetailsQM GetGPReceivedDetails()
        {
            var model = new GetGPReceivedDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetReceivedDetailsSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

    }
}
