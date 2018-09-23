using ES.Services.DataAccess.Model.QueryModel.Enquiry;
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

namespace ES.Services.DataAccess.Commands.Enquiry
{
    public class GetSerialNoEnquirySelectCommandForGrid : SsDbCommand
    {
        public SerialNoEnquiryOptionQM Execute(string SerialNo)
        {
            SerialNoEnquiryOptionQM response = new SerialNoEnquiryOptionQM();

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSerialNoEnquiry]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.NVarChar, ParameterDirection.Input, SerialNo));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getSerialNoEnquiryOptionModel = reader.ToList<SerialNoEnquiryOptionModel>();
                }
            }

            return response;
        }
    }
}
