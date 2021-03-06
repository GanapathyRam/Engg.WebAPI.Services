﻿using ES.Services.DataAccess.Model.QueryModel.SubContract;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class GetScReceivingMasterSelectCommand : SsDbCommand
    {
        public GetScReceivingMasterQM Execute()
        {
            var response = new GetScReceivingMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSCReceivingMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetScReceiveMasterModelList = reader.ToList<GetScReceivingMasterModel>();
                }
            }

            return response;
        }
    }
}
