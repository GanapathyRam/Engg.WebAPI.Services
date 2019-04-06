using ES.Services.DataAccess.Model.CommandModel.Transaction;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Transaction
{
    public interface ITransactionRepository
    {
        void AddPoMaster(AddPoMasterCM addPoMasterCM);

        void AddPoDetails(AddPoDetailsCM addPoDetailsCM);

        string GetPoNumber();

        GetVendorTermsMasterQM GetVendorTermsMaster(Int64 VendorCode);

        GetPOTypeQM GetPOTypeMaster();

        void UpdatePoMaster(AddPoMasterCM addPoMasterCM);

        void UpdatePoDetails(UpdatePoDetailsCM updatePoDetailsCM);

        void DeletePoMasterAndDetails(string PoNumber, decimal PoSerialNo, int IsDeleteFrom);

        GetPoResponseQM GetPoMasterAndDetails();

        GetRateMasterDetailsFromVendorCodeQM GetRateMasterDetailsFromVendorCode(Int64 VendorCode, decimal ItemCode);
    }
}
