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
    public class VendorMasterUpdateCommand:SsDbCommand
    {
        public void Execute(UpdateVendorMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].uspUpdateVendorMaster";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@VendorName", SsDbType.VarChar, ParameterDirection.Input, model.VendorName));
                sqlCommand.Parameters.Add(AddParameter("@CategoryCode", SsDbType.VarChar, ParameterDirection.Input, model.CategoryCode));
                sqlCommand.Parameters.Add(AddParameter("@VendorShortName", SsDbType.VarChar, ParameterDirection.Input, model.VendorShortName));
                sqlCommand.Parameters.Add(AddParameter("@Address1", SsDbType.VarChar, ParameterDirection.Input, model.Address1));
                sqlCommand.Parameters.Add(AddParameter("@Address2", SsDbType.VarChar, ParameterDirection.Input, model.Address2));
                sqlCommand.Parameters.Add(AddParameter("@City", SsDbType.VarChar, ParameterDirection.Input, model.City));
                sqlCommand.Parameters.Add(AddParameter("@PinCode", SsDbType.VarChar, ParameterDirection.Input, model.PinCode));
                sqlCommand.Parameters.Add(AddParameter("@CompanyGST", SsDbType.VarChar, ParameterDirection.Input, model.CompanyGST));
                sqlCommand.Parameters.Add(AddParameter("@PaymentDays", SsDbType.Int, ParameterDirection.Input, model.PaymentDays));
                sqlCommand.Parameters.Add(AddParameter("@Contact1", SsDbType.VarChar, ParameterDirection.Input, model.Contact1));
                sqlCommand.Parameters.Add(AddParameter("@Contact2", SsDbType.VarChar, ParameterDirection.Input, model.Contact2));
                sqlCommand.Parameters.Add(AddParameter("@Phone", SsDbType.VarChar, ParameterDirection.Input, model.Phone));
                sqlCommand.Parameters.Add(AddParameter("@Fax", SsDbType.VarChar, ParameterDirection.Input, model.Fax));
                sqlCommand.Parameters.Add(AddParameter("@Email", SsDbType.VarChar, ParameterDirection.Input, model.Email));
                sqlCommand.Parameters.Add(AddParameter("@VendorCustomerCode", SsDbType.VarChar, ParameterDirection.Input, model.VendorCustomerCode));
                sqlCommand.Parameters.Add(AddParameter("@AddedDate", SsDbType.DateTime, ParameterDirection.Input, model.AddedDate));
                sqlCommand.Parameters.Add(AddParameter("@DeletedDate", SsDbType.DateTime, ParameterDirection.Input, model.DeletedDate));
                sqlCommand.Parameters.Add(AddParameter("@CERegisterCode", SsDbType.VarChar, ParameterDirection.Input, model.CERegisterCode));
                sqlCommand.Parameters.Add(AddParameter("@DCTo", SsDbType.VarChar, ParameterDirection.Input, model.DCTo));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceTo", SsDbType.VarChar, ParameterDirection.Input, model.InvoiceTo));
                sqlCommand.Parameters.Add(AddParameter("@Country", SsDbType.VarChar, ParameterDirection.Input, model.Country));
                sqlCommand.Parameters.Add(AddParameter("@State", SsDbType.VarChar, ParameterDirection.Input, model.State));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.VarChar, ParameterDirection.Input, model.VendorCode));
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
