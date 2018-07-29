using ES.Services.DataAccess.Model.CommandModel.Sales;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class UpdateWorkOrderMasterInsertCommand : SsDbCommand
    {
        public void Execute(UpdateWorkOrderCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateWorkOrderMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.Decimal, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().WorkOrderSerial));
                sqlCommand.Parameters.Add(AddParameter("@DCNumber", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().DCNumber));
                sqlCommand.Parameters.Add(AddParameter("@DCSerial", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().DCSerial));
                sqlCommand.Parameters.Add(AddParameter("@DCDate", SsDbType.DateTime, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().DCDate));
                sqlCommand.Parameters.Add(AddParameter("@PONumber", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().PONumber));
                sqlCommand.Parameters.Add(AddParameter("@POSerial", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().POSerial));
                sqlCommand.Parameters.Add(AddParameter("@PODate", SsDbType.DateTime, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().PODate));
                sqlCommand.Parameters.Add(AddParameter("@DrawingNo", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().DrawingNo));
                sqlCommand.Parameters.Add(AddParameter("@DrawingRevisionNo", SsDbType.NVarChar, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().DrawingRev));
                sqlCommand.Parameters.Add(AddParameter("@Rate", SsDbType.Decimal, ParameterDirection.Input, model.UpdateWorkOrderMasterListItems.FirstOrDefault().Rate));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
