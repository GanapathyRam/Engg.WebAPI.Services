using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Stores
{
    public interface IGatePassOutsideRepository
    {
        string getGPOutsideReceiptNumber(string gpOutsideType);
        GetGPOutsideReceiptQM getGPOutsideReceipt();
        void SaveGPOutsideReceiptMaster(GPOutsideMasterCM gpOutsideMasterCM);
        void SaveGPOutsideReceiptDetails(GPOutsideReceiptDetailsCM gpOutsideReceiptDetailsCM);
        void DeleteGPOutsideReceiptMasterAndDetails(DeleteGPOutsideReceiptCM deleteGPOutsideReceiptCM);

        string GetGPOutsideReturnNumber();
        GetGPOutsideReturnQM GetGPOutsideReturn();
        GPOutsideReturnVendorQM GetGPOutsideReturnVendorList();
        GPOutsideReturnDetailsGridQM GetGPReceivedDetailsGrid(Int64 VendorCode);
        void SaveGPOutsideReturnMaster(GPOutsideReturnMasterCM gpOutsideReturnMasterCM);
        void SaveGPOutsideReturnDetails(GPOutsideReturnDetailsCM gpOutsideReturnDetailsCM);
    }
}
