using ES.Services.DataAccess.Commands.Stores;
using ES.Services.DataAccess.Interface.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Repositories.Stores
{
   public class GatePassRepository: IGatePassRepository
    {
        public GPTypeMasterQM getGPTypeMaster()
        {
            GPTypeMasterQM gpTypeMasterQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var rolesInsertCommand = new GPTypeMasterSelectCommand { Connection = connection };
                gpTypeMasterQM = rolesInsertCommand.Execute();
            }
            return gpTypeMasterQM;
        }

        public GetGPReceiptVendorQM getGPReceiptVendor()
        {
            GetGPReceiptVendorQM getGPReceiptVendorQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GetGPReceiptVendorSelectCommand { Connection = connection };
                getGPReceiptVendorQM = rolesInsertCommand.Execute();
            }
            return getGPReceiptVendorQM;
        }

        public string getGPSendingNumber(string gpType)
        {
            string GPNumber = string.Empty;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GPSendingNumberSelectCommand { Connection = connection };
                GPNumber = gPNumberCommand.Execute(gpType);
            }
            return GPNumber;
        }

        public string getGPReceiptNumber()
        {
            string GPReceiptNumber = string.Empty;

            using(var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GPReceiptNumberSelectCommand { Connection = connection };
                GPReceiptNumber = gPNumberCommand.Execute();
            }
            return GPReceiptNumber;
        }
    }
}
