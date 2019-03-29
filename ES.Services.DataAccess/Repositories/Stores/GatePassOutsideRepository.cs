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
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GPOutsideReceiptDeleteCommand { Connection = connection };
                rolesInsertCommand.Execute(deleteGPOutsideReceiptCM.DeleteGPOutsideReceiptDetailList.ToDataTableWithNull(), deleteGPOutsideReceiptCM.GPOutsideReceiptNumber, deleteGPOutsideReceiptCM.IsDeleteFrom);
            }

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

        public GetGPOutsideReturnQM GetGPOutsideReturn()
        {
            GetGPOutsideReturnQM getGPOutsideReturnQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GPOutsideReturnMasterAndDetailsSelectCommand { Connection = connection };
                getGPOutsideReturnQM = rolesInsertCommand.Execute();
            }
            return getGPOutsideReturnQM;
        }

        public string GetGPOutsideReturnNumber()
        {
            string GPOutsideReturnNumber = string.Empty;

            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var gPNumberCommand = new GPOutsideReturnNumberSelectCommand { Connection = connection };
                GPOutsideReturnNumber = gPNumberCommand.Execute();
            }
            return GPOutsideReturnNumber;
        }

        public GPOutsideReturnVendorQM GetGPOutsideReturnVendorList()
        {
            GPOutsideReturnVendorQM gPOutsideReturnVendorQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GetGPOutsideReturnVendorSelectCommand { Connection = connection };
                gPOutsideReturnVendorQM = rolesInsertCommand.Execute();
            }
            return gPOutsideReturnVendorQM;
        }

        public GPOutsideReturnDetailsGridQM GetGPReceivedDetailsGrid(Int64 VendorCode)
        {
            GPOutsideReturnDetailsGridQM gpOutsideReturnDetailsGridQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();
                var rolesInsertCommand = new GPOutsideReturnDetailsGridSelectCommand { Connection = connection };
                gpOutsideReturnDetailsGridQM = rolesInsertCommand.Execute(VendorCode);
            }
            return gpOutsideReturnDetailsGridQM;
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

        public void SaveGPOutsideReturnDetails(GPOutsideReturnDetailsCM gpOutsideReturnDetailsCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPOutsideReturnDetailsInsertCommand { Connection = connection };
                command.Execute(gpOutsideReturnDetailsCM.GPOutsideReturnDetailsList.ToDataTableWithNull(), gpOutsideReturnDetailsCM);
            }
        }

        public void SaveGPOutsideReturnMaster(GPOutsideReturnMasterCM gpOutsideReturnMasterCM)
        {
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var command = new GPOutsideReturnMasterInsertCommand { Connection = connection };
                command.Execute(gpOutsideReturnMasterCM);
            }
        }
    }
}
