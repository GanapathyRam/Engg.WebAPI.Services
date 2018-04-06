using ES.Services.DataAccess.Commands.Sales;
using ES.Services.DataAccess.Interface.Sales;
using ES.Services.DataAccess.Model.CommandModel.Sales;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Sales
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        public GetWorkOrderTypeQM GetWorkOrderType()
        {
            var model = new GetWorkOrderTypeQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderTypeSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public string GetWorkOrderNumber()
        {
            //var model = new GetWorkOrderTypeQM();
            string workOrderNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderNumberSelectCommand { Connection = connection };
                workOrderNumber = command.Execute();
            }

            return workOrderNumber;
        }

        public GetWorkOrderClientSerialNoQM GetWorkOrderClientSerialNo()
        {
            //var model = new GetWorkOrderTypeQM();
            GetWorkOrderClientSerialNoQM workOrderNumber;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderNumberClientSerialNoSelectCommand { Connection = connection };
                workOrderNumber = command.Execute();
            }

            return workOrderNumber;
        }

        public AddWorkOrderQM AddWorkOrder(AddWorkOrderCM addWorkOrderCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderMasterInsertCommand { Connection = connection };
                command.Execute(addWorkOrderCM.WorkOrderMasterListItems.ToDataTableWithNull(), addWorkOrderCM);
            }

            return new AddWorkOrderQM();
        }

        public void UpdateWorkOrder(UpdateWorkOrderCM updateWorkOrderCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new UpdateWorkOrderMasterInsertCommand { Connection = connection };

                command.Execute(updateWorkOrderCM);
            }

            //return new UpdateWorkOrderQM();
        }

        public void DeleteWorkOrder(GetWorkOrderDetailsStatusCM deleteWorkOrderCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderMasterDeleteCommand { Connection = connection };

                command.Execute(deleteWorkOrderCM);
            }

            //return new UpdateWorkOrderQM();
        }

        public void AddWorkOrderDetails(WorkOrderDetailsCM workOrderDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderDetailsInsertCommand { Connection = connection };
                command.Execute(workOrderDetailsCM);
            }

            //return new AddWorkOrderQM();
        }

        public void AddWorkOrderMasterCommon(string WorkOrderType, string WorkOrderNumber, DateTime WorkOrderDate, Int64 VendorCode)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderMasterCommonInsertCommand { Connection = connection };
                command.Execute(WorkOrderType, WorkOrderNumber, WorkOrderDate, VendorCode);
            }

            //return new AddWorkOrderQM();
        }

        public GetWorkOrderQM GetWorkOrder()
        {
            var model = new GetWorkOrderQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderSelectCommand { Connection = connection };
                model = command.Execute();
            }

            return model;
        }

        public GetWorkOrderDetailsStatusQM GetWorkOrderDetailsStatus(GetWorkOrderDetailsStatusCM modelCM)
        {
            var model = new GetWorkOrderDetailsStatusQM();
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new WorkOrderDetailsStatusSelectCommand { Connection = connection };
                model = command.Execute(modelCM);
            }

            return model;
        }
    }
}
