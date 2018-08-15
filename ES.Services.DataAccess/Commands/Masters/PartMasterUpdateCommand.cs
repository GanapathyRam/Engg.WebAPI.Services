using ES.Services.DataAccess.Model.CommandModel.Masters;
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
    public class PartMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdatePartMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdatePartMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.BigInt, ParameterDirection.Input, model.PartCode));

                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@Description", SsDbType.VarChar, ParameterDirection.Input, model.Description));
                sqlCommand.Parameters.Add(AddParameter("@DrawingNumber", SsDbType.VarChar, ParameterDirection.Input, model.DrawingNumber));
                sqlCommand.Parameters.Add(AddParameter("@DrawingUnit", SsDbType.VarChar, ParameterDirection.Input, model.DrawingUnit));
                sqlCommand.Parameters.Add(AddParameter("@DrawingNoRevision", SsDbType.VarChar, ParameterDirection.Input, model.DrawingNumberRevision));
                sqlCommand.Parameters.Add(AddParameter("@ItemCode", SsDbType.VarChar, ParameterDirection.Input, model.ItemCode));
                sqlCommand.Parameters.Add(AddParameter("@RatePiece", SsDbType.Decimal, ParameterDirection.Input, model.RatePiece));
                sqlCommand.Parameters.Add(AddParameter("@RawWeight", SsDbType.Decimal, ParameterDirection.Input, model.RawWeight));
                sqlCommand.Parameters.Add(AddParameter("@FinishWeight", SsDbType.Decimal, ParameterDirection.Input, model.FinishWeight));
                sqlCommand.Parameters.Add(AddParameter("@MaterialCode", SsDbType.Decimal, ParameterDirection.Input, model.MaterialCode));


                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
