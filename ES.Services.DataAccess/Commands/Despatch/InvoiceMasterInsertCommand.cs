using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class InvoiceMasterInsertCommand : SsDbCommand
    {
        public void Execute(string InvoiceNumber, DateTime InvoiceDate, string DcNumber, string WoType, Int64 VendorCode, string Tariff, string Vehicle, 
            string EWayBill, decimal CGSTPercent, decimal SGSTPercent, decimal IGSTPercent, decimal ValuesOfGoods, decimal CGSTAmount, decimal SGSTAmount,
            decimal IGSTAmount, decimal GrandTotal, decimal RoundOff, decimal FineTotal, bool PrintTag)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddInvoiceMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InvoiceNumber", SsDbType.VarChar, ParameterDirection.Input, InvoiceNumber));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceDate", SsDbType.DateTime, ParameterDirection.Input, InvoiceDate));
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.NVarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.NVarChar, ParameterDirection.Input, WoType));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@Tariff ", SsDbType.NVarChar, ParameterDirection.Input, Tariff));
                sqlCommand.Parameters.Add(AddParameter("@Vehicle", SsDbType.NVarChar, ParameterDirection.Input, Vehicle));
                sqlCommand.Parameters.Add(AddParameter("@EWayBill", SsDbType.NVarChar, ParameterDirection.Input, EWayBill));
                sqlCommand.Parameters.Add(AddParameter("@CGSTPercent", SsDbType.Decimal, ParameterDirection.Input, CGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@SGSTPercent", SsDbType.Decimal, ParameterDirection.Input, SGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@IGSTPercent", SsDbType.Decimal, ParameterDirection.Input, IGSTPercent));
                sqlCommand.Parameters.Add(AddParameter("@ValuesOfGoods", SsDbType.Decimal, ParameterDirection.Input, ValuesOfGoods));
                sqlCommand.Parameters.Add(AddParameter("@CGSTAmount", SsDbType.Decimal, ParameterDirection.Input, CGSTAmount));
                sqlCommand.Parameters.Add(AddParameter("@SGSTAmount", SsDbType.Decimal, ParameterDirection.Input, SGSTAmount));
                sqlCommand.Parameters.Add(AddParameter("@IGSTAmount", SsDbType.Decimal, ParameterDirection.Input, IGSTAmount));
                sqlCommand.Parameters.Add(AddParameter("@GrandTotal", SsDbType.Decimal, ParameterDirection.Input, GrandTotal));
                sqlCommand.Parameters.Add(AddParameter("@RoundOff", SsDbType.Decimal, ParameterDirection.Input, RoundOff));
                sqlCommand.Parameters.Add(AddParameter("@FineTotal", SsDbType.Decimal, ParameterDirection.Input, FineTotal));
                sqlCommand.Parameters.Add(AddParameter("@PrintTag", SsDbType.Bit, ParameterDirection.Input, PrintTag));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
