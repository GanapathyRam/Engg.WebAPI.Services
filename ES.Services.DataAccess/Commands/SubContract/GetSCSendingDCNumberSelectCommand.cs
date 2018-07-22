﻿using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class GetSCSendingDCNumberSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            string DcNumberForSCSending = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSCSendingDCNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        DcNumberForSCSending = Convert.ToString(reader["SubContractDCNumber"]);
                    }
                }
            }
            return DcNumberForSCSending;
        }
    }
}
