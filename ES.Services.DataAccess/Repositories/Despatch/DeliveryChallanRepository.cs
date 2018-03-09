using ES.Services.DataAccess.Commands.Despatch;
using ES.Services.DataAccess.Interface.Despatch;
using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using SS.Framework.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Despatch
{
    public class DeliveryChallanRepository : IDeliveryChallanRepository
    {
        public GetDcTypeQM GetDcType()
        {
            var model = new GetDcTypeQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDcTypeSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public GetWOMasterForDcQM GetWoMasterForDc(Int64 vendorCode, string woType)
        {
            var model = new GetWOMasterForDcQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetWoMasterForDcSelectCommand { Connection = connection };
                model = command.Execute(vendorCode, woType);
            }

            return model;
        }

        public GetSerialNoFromWoNumerWoSerialQM GetSerialNoFromWoNumerWoSerialForDc(string woNumber, decimal woSerial)
        {
            var model = new GetSerialNoFromWoNumerWoSerialQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetSerialNoForDcSelectCommand { Connection = connection };
                model = command.Execute(woNumber, woSerial);
            }

            return model;
        }

        public string GetDCNumber(string WoType)
        {
            string workOrderNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDCNumberSelectCommand { Connection = connection };
                workOrderNumber = command.Execute(WoType);
            }

            return workOrderNumber;
        }

        public GetDcMasterQM GetDcMaster()
        {
            GetDcMasterQM getDcMasterQM = new GetDcMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDcMasterSelectCommand { Connection = connection };
                getDcMasterQM = command.Execute();
            }

            return getDcMasterQM;
        }

        public void AddDcMasterDetails(string WorkOrderType, DateTime DcDate, string DcNumber, Int64 VendorCode, string DcType, string VehicleNo, bool Billable)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcMasterCommonInsertCommand { Connection = connection };
                command.Execute(WorkOrderType, DcNumber, DcDate, VendorCode, DcType, VehicleNo, Billable);
            }
        }

        public void AddDcDetails(string DcNumber, string WoNumber, decimal DcSerial, Int64 PartCode, decimal Quantity, string Remarks, bool InvoicedTag, int WoSerail)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcDetailsInsertCommand { Connection = connection };
                command.Execute(DcNumber, WoNumber, DcSerial, PartCode, Quantity, Remarks, InvoicedTag, WoSerail);
            }
        }

        public void AddDcSerial(DcDetailSerialCM dcDetailSerialCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcSerialInsertCommand { Connection = connection };
                command.Execute(dcDetailSerialCM.DcDetailSerialItems.ToDataTableWithNull(), dcDetailSerialCM);
            }
        }

        public GetWoMasterAndDetailsFromCustomerCodeTypeQM GetWoMasterAndDetails(Int64 vendorCode, string woType, string DcNumber, bool Invoiced)
        {
            var model = new GetWoMasterAndDetailsFromCustomerCodeTypeQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetWoMasterAndDetailsSelectCommand { Connection = connection };
                model = command.Execute(vendorCode, woType, DcNumber, Invoiced);
            }

            return model;
        }

        public void DeleteDcDetails(DeleteDcDetailsCM deleteDcDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcDeleteCommand { Connection = connection };
                command.Execute(deleteDcDetailsCM.dcDetailsListItems.ToDataTableWithNull(), deleteDcDetailsCM.DcNumer, deleteDcDetailsCM.WoNumber, deleteDcDetailsCM.IsDeleteFrom);
            }
        }

        public void UpdateDcDetails(string DcNumber, string WoNumber, decimal DcSerial, decimal Quantity, int WoSerail)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new DcDetailsUpdateCommand { Connection = connection };
                command.Execute(DcNumber, WoNumber, DcSerial, Quantity, WoSerail);
            }
        }

    }
}
