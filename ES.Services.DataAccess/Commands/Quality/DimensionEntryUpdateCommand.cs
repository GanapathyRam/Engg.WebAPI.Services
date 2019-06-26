using ES.Services.DataAccess.Model.CommandModel.Quality;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Quality
{
    public class DimensionEntryUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateDimensioEntryCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateDimensionEntry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.NVarChar, ParameterDirection.Input, model.SerialNo));
                sqlCommand.Parameters.Add(AddParameter("@DimensionActual", SsDbType.NVarChar, ParameterDirection.Input, model.DimensionActual));
                sqlCommand.Parameters.Add(AddParameter("@DatumDimesionActual", SsDbType.NVarChar, ParameterDirection.Input, model.DatumDimesionActual));
                sqlCommand.Parameters.Add(AddParameter("@Serial", SsDbType.NVarChar, ParameterDirection.Input, model.Serial));
                sqlCommand.Parameters.Add(AddParameter("@SequenceNumber", SsDbType.Decimal, ParameterDirection.Input, model.SequenceNumber));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
