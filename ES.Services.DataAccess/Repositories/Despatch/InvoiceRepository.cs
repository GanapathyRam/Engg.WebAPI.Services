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
    public class InvoiceRepository : IInvoiceRepository
    {
        public string GetInvoiceNumber(string WoType)
        {
            string workOrderNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetInvoiceNumberSelectCommand { Connection = connection };
                workOrderNumber = command.Execute(WoType);
            }

            return workOrderNumber;
        }

        public GetDcNumberForInvoiceQM GetDcNumberForInvoice(Int64 VendorCode, string WoType)
        {
            var response = new GetDcNumberForInvoiceQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDcNumberForInvoiceSelectCommand { Connection = connection };
                response = command.Execute(VendorCode, WoType);
            }

            return response;
        }

        public GetDcDetailsForInvoiceQM GetDcDetailsForInvoice(string DcNumber)
        {
            var response = new GetDcDetailsForInvoiceQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDcDetailsForInvoiceSelectCommand { Connection = connection };
                response = command.Execute(DcNumber);
            }

            return response;
        }

        public void AddInvoiceDetails(InvoiceDetailCM InvoiceDetailCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceDetailsInsertCommand { Connection = connection };
                command.Execute(InvoiceDetailCM.InvoiceDetailsItems.ToDataTableWithNull(), InvoiceDetailCM);
            }
        }

        public void AddInvoiceMaster(string InvoiceNumber, DateTime InvoiceDate, string DcNumber, string WoType, Int64 VendorCode, string Tariff, string Vehicle,
            string EWayBill, decimal CGSTPercent, decimal SGSTPercent, decimal IGSTPercent, decimal ValuesOfGoods, decimal CGSTAmount, decimal SGSTAmount,
            decimal IGSTAmount, decimal GrandTotal, decimal RoundOff, decimal FineTotal, bool PrintTag)
        {
            var response = new GetDcDetailsForInvoiceQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceMasterInsertCommand { Connection = connection };
                command.Execute(InvoiceNumber, InvoiceDate, DcNumber, WoType, VendorCode, Tariff, Vehicle, EWayBill, CGSTPercent, SGSTPercent, IGSTPercent, ValuesOfGoods,
                    CGSTAmount, SGSTAmount,IGSTAmount, GrandTotal, RoundOff, FineTotal, PrintTag);
            }

        }

        public void AddInvoiceDetailSerial(InvoiceDetailSerialCM InvoiceDetailSerialCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceDetailsSerialInsertCommand { Connection = connection };
                command.Execute(InvoiceDetailSerialCM.InvoiceDetailSerialItem.ToDataTableWithNull(), InvoiceDetailSerialCM);
            }
        }

        public GetInvoiceMasterQM GetInvoiceMaster()
        {
            var response = new GetInvoiceMasterQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetInvoiceMasterSelectCommand { Connection = connection };
                response = command.Execute();
            }

            return response;
        }

        public GetInvoiceDetailsQM GetInvoiceDetails(string InvoiceNumber)
        {
            var response = new GetInvoiceDetailsQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetInvoiceDetailsSelectCommand { Connection = connection };
                response = command.Execute(InvoiceNumber);
            }

            return response;
        }

        public void DeleteInvoice(DeleteInvoiceCM deleteInvoiceCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceDeleteCommand { Connection = connection };
                command.Execute(deleteInvoiceCM.DeleteInvoiceCMModelList.ToDataTableWithNull(), deleteInvoiceCM.DcNumber, deleteInvoiceCM.InvoiceNumber);
            }
        }

        public GetDcSerialForInvoiceSerialQM GetDcDetailsSerialForInvoiceSerial(string DcNumber)
        {
            var response = new GetDcSerialForInvoiceSerialQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDcSerialForInvoiceSerialSelectCommand { Connection = connection };
                response = command.Execute(DcNumber);
            }

            return response;
        }

        public void UpdateInvoiceDetails(InvoiceDetailCM InvoiceDetailCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceDetailsUpdateCommand { Connection = connection };
                command.Execute(InvoiceDetailCM.InvoiceDetailsItems.ToDataTableWithNull(), InvoiceDetailCM);
            }
        }

        public void UpdateInvoiceMaster(string InvoiceNumber, DateTime InvoiceDate, string DcNumber, string WoType, Int64 VendorCode, string Tariff, string Vehicle,
            string EWayBill, decimal CGSTPercent, decimal SGSTPercent, decimal IGSTPercent, decimal ValuesOfGoods, decimal CGSTAmount, decimal SGSTAmount,
            decimal IGSTAmount, decimal GrandTotal, decimal RoundOff, decimal FineTotal)
        {
            var response = new GetDcDetailsForInvoiceQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new InvoiceMasterUpdateCommand { Connection = connection };
                command.Execute(InvoiceNumber, InvoiceDate, DcNumber, WoType, VendorCode, Tariff, Vehicle, EWayBill, CGSTPercent, SGSTPercent, IGSTPercent, ValuesOfGoods,
                    CGSTAmount, SGSTAmount, IGSTAmount, GrandTotal, RoundOff, FineTotal);
            }

        }

        public GetDimensionReportQM GetDimensionReport(string InvoiceNumber, decimal InvoiceSerial, int IsReportFor)
        {
            var response = new GetDimensionReportQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GetDimensionReportSelectCommand { Connection = connection };
                response = command.Execute(InvoiceNumber, InvoiceSerial, IsReportFor);
            }

            return response;
        }
    }
}
