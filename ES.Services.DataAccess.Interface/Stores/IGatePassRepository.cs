using ES.Services.DataAccess.Model.CommandModel.Stores;
using ES.Services.DataAccess.Model.QueryModel.Stores;
using ES.Services.DataTransferObjects.Request.Stores;
using ES.Services.DataTransferObjects.Response.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Stores
{
    public interface IGatePassRepository
    {
        GetUnitMasterQM GetUnitMaster();

        GPTypeMasterQM getGPTypeMaster();

        string getGPSendingNumber(string gpType);

        string getGPReceiptNumber();

        GetGPReceiptVendorQM getGPReceiptVendor();

        void SaveGPSendingMaster(string GPType, string GPNumber, Int64 VendorCode, DateTime GPDate, string RequestedBy, string Remarks);

        void SaveGPSendingDetails(GPSendingDetailsCM GPSendingDetailsCM);

        GetGPSendingQM GetGPSendingMasterAndDetails();

        void DeleteGPSendingMasterAndDetails(DeleteGPSendingCM DeleteGPSendingCM);

        GetGPReceivingResponseQM GetGPReceivingMasterAndDetails(Int64 VendorCode);

        GetGPReceivedDetailsQM GetGPReceivedDetails();

        void SaveGPReceivingMaster(string GPReceiptNumber, DateTime GPReceiptDate, Int64 VendorCode, string DocumentId, DateTime DocumentDate, string Remarks);

        void SaveGPReceivingDetails(GPReceivingDetailsCM GPReceivingDetailsCM);
    }
}
