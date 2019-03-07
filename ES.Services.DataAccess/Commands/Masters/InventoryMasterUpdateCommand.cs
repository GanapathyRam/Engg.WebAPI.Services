using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class InventoryMasterUpdateCommand : SsDbCommand
    {
        public UpdateInventoryMasterQM Execute(UpdateInventoryMasterCM model)
        {
            var response = new UpdateInventoryMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateInventoryMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ItemDescription", SsDbType.VarChar, ParameterDirection.Input, model.ItemDescription));
                sqlCommand.Parameters.Add(AddParameter("@UOMCode", SsDbType.Decimal, ParameterDirection.Input, model.UOMCode));
                sqlCommand.Parameters.Add(AddParameter("@GroupCode", SsDbType.Decimal, ParameterDirection.Input, model.GroupCode));
                sqlCommand.Parameters.Add(AddParameter("@BaseRate", SsDbType.Decimal, ParameterDirection.Input, model.BaseRate));
                sqlCommand.Parameters.Add(AddParameter("@ReOrderQuantity", SsDbType.Decimal, ParameterDirection.Input, model.ReOrderQuantity));
                sqlCommand.Parameters.Add(AddParameter("@MinimumOrderQuantity", SsDbType.Decimal, ParameterDirection.Input, model.MinimumOrderQuantity));
                sqlCommand.Parameters.Add(AddParameter("@StockQuantity", SsDbType.Decimal, ParameterDirection.Input, model.StockQuantity));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.VarChar, ParameterDirection.Input, model.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@ItemCode", SsDbType.Decimal, ParameterDirection.InputOutput, model.ItemCode));
                sqlCommand.ExecuteNonQuery();
                response.ItemCode = Convert.ToInt32(sqlCommand.Parameters["@ItemCode"].Value);
                return response;
            }

        }


    }
}
