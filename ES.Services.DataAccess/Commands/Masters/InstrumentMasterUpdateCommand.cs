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
    public class InstrumentMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateInstrumentMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].uspUpdateInstrumentMaster";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InstrumentName", SsDbType.VarChar, ParameterDirection.Input, model.InstrumentName));
                sqlCommand.Parameters.Add(AddParameter("@AddedDate", SsDbType.DateTime, ParameterDirection.Input, model.AddedDate));
                sqlCommand.Parameters.Add(AddParameter("@Make", SsDbType.VarChar, ParameterDirection.Input, model.Make));
                sqlCommand.Parameters.Add(AddParameter("@Range", SsDbType.VarChar, ParameterDirection.Input, model.Range));
                sqlCommand.Parameters.Add(AddParameter("@Accuracy", SsDbType.VarChar, ParameterDirection.Input, model.Accuracy));
                sqlCommand.Parameters.Add(AddParameter("@Serial", SsDbType.VarChar, ParameterDirection.Input, model.Serial));
                sqlCommand.Parameters.Add(AddParameter("@CalibratedDate", SsDbType.DateTime, ParameterDirection.Input, model.CalibratedDate));
                sqlCommand.Parameters.Add(AddParameter("@Frequency", SsDbType.Decimal, ParameterDirection.Input, model.Frequency));
                sqlCommand.Parameters.Add(AddParameter("@CalibratedDueDate", SsDbType.DateTime, ParameterDirection.Input, model.CalibrationDueDate));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.VarChar, ParameterDirection.Input, model.VendorCode));              
                sqlCommand.Parameters.Add(AddParameter("@InstrumentCode", SsDbType.Decimal, ParameterDirection.Input, model.InstrumentCode));

                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
