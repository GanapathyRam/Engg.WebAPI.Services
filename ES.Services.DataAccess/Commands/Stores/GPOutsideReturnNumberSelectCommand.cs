using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
   public class GPOutsideReturnNumberSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            string GPOutsideReturnNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPOutsideReturnNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        GPOutsideReturnNumber = Convert.ToString(reader["GPOutsideReturnNumber"]);
                    }
                }
            }
            return GPOutsideReturnNumber;
        }
    }
}
