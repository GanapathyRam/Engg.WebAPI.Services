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

        string GetGRNNumber();

        GetRateMasterDetailsFromVendorCodeQM GetRateMasterDetailsFromVendorCode(Int64 VendorCode, decimal ItemCode);

        GetGRNDetailsQM GetGRNDetails(Int64 VendorCode);

        GetGRNSupplierNameQM GetGRNSupplierName();

        void AddGRNMaster(AddGRNMasterCM addGRNMasterCM);

        void AddGRNDetails(AddGRNDetailsCM addGRNDetailsCM);

        void UpdateGRNMaster(AddGRNMasterCM addGRNMasterCM);

        void UpdateGRNDetails(UpdateGRNDetailsCM updateGRNDetailsCM);

        GetGRNMasterAndDetailsQM GetGRNMasterAndDetails();

        void DeleteGRNMasterAndDetails(string GRNNumber, decimal GRNSerialNo, DeleteGRNDetailsCM deleteGRNDetailsCM, int IsDeleteFrom);

        string GetIssuesNumber();

        void AddIssueMaster(AddIssueMasterCM addIssueMasterCM);

        void AddIssueDetails(AddIssueDetailsCM addIssueDetailsCM);

        void UpdateIssueMaster(UpdateIssueMasterCM updateIssueMasterCM);

        void UpdateIssueDetails(UpdateIssueDetailsCM updateIssueDetailsCM);

        GetIssueMasterAndDetailsQM GetIssueMasterAndDetails();

        GetIssueDetailsQM GetIssueDetails();

        void DeleteIssueMasterAndDetails(string IssueNumber, decimal IssueSerialNo, DeleteIssueDetailsCM deleteIssueDetailsCM, int IsDeleteFrom);
    }
}
