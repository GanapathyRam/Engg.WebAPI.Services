using ES.Services.DataAccess.Model.QueryModel.Quality;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Quality
{
    public class DimensionEntrySelectCommand : SsDbCommand
    {
        public GetDimensionEntryQM Execute(String SerialNo)
        {
            var response = new GetDimensionEntryQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDimenstionEntryReport]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.VarChar, ParameterDirection.Input, SerialNo));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        response.WONumber = Convert.ToString(reader["WONumber"]);
                        response.WOSerial = Convert.ToDecimal(reader["WOSerial"]);
                        response.VendorName = Convert.ToString(reader["VendorName"]);
                        response.PartDescription = Convert.ToString(reader["PartDescription"]);
                        response.DrawingNumber = Convert.ToString(reader["DrawingNumber"]);
                        response.ItemCode = Convert.ToString(reader["ItemCode"]);
                        response.MaterialDescription = Convert.ToString(reader["MaterialDescription"]);
                    }

                    response.GetDimensionEntryEditModelList = reader.ToList<GetDimensionEntryEditModel>();
                }
            }

            return response;
        }
    }
}
