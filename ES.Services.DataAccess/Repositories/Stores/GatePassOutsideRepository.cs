using ES.Services.DataAccess.Commands.Stores;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using SS.Framework.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Stores
{
    public class GatePassOutsideRepository : IGatePassOutsideRepository
    {
        public void DeleteGPOutsideReceiptMasterAndDetails(DeleteGPOutsideReceiptCM deleteGPOutsideReceiptCM)
        {
            throw new NotImplementedException();
        }

        public GetGPOutsideReceiptQM getGPOutsideReceipt()
        {
            GetGPOutsideReceiptQM gGetGPOutsideReceiptQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GetGPOutsideReceiptSelectCommand { Connection = connection };
                gGetGPOutsideReceiptQM = rolesInsertCommand.Execute();
            }
            return gGetGPOutsideReceiptQM;
        }

        public string getGPOutsideReceiptNumber(string gpOutsideType)
        {
            string GPOutsideReceiptNumber = string.Empty;

            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GetGPOutsideReceiptNumberSelectCommand { Connection = connection };
                GPOutsideReceiptNumber = gPNumberCommand.Execute(gpOutsideType);
            }
            return GPOutsideReceiptNumber;
        }

        public void SaveGPOutsideReceiptDetails(GPOutsideReceiptDetailsCM gpOutsideReceiptDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPOutsideReceiptDetailsInsertCommand { Connection = connection };
                command.Execute(gpOutsideReceiptDetailsCM.GPOutsideReceiptDetailsList.ToDataTableWithNull(), gpOutsideReceiptDetailsCM);
            }
        }

        public void SaveGPOutsideReceiptMaster(GPOutsideMasterCM gpOutsideMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPOutsideReceiptMasterInsertCommand { Connection = connection };
                command.Execute(gpOutsideMasterCM);
            }
        }
    }
}
