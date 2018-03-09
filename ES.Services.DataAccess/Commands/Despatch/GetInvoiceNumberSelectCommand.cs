using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetInvoiceNumberSelectCommand : SsDbCommand
    {
        public string Execute(string WoType)
        {
            //var response = new GetWorkOrderTypeQM();
            string InvoiceNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetInvoiceNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, WoType));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        InvoiceNumber = Convert.ToString(reader["InvoiceNumber"]);
                    }
                }
            }
            return InvoiceNumber;
        }
    }
}
