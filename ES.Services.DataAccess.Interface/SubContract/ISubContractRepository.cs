using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.CommandModel.SubContract;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.SubContract;
using ES.Services.DataTransferObjects.Request.SubContract;
using ES.Services.DataTransferObjects.Response.Despatch;
using ES.Services.DataTransferObjects.Response.SubContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.SubContract
{
    public interface ISubContractRepository
    {
        GetSubContractSendingResponseQM GetSubContractSendingDetails();

        void AddSubContractMasterDetails(DateTime SubContractDcDate, string SubContractDcNumber, decimal SubContractSentFor, string Vehicle, Int64 VendorCode, string Remarks);

        void AddScDetails(string ScNumber, string WoNumber, decimal WoSerial, decimal PartCode);

        void UpdateScDetails(string ScNumber, string WoNumber, decimal WoSerial, decimal PartCode);

        void AddScSerial(ScDetailSerialCM scDetailSerialCM);

        void DeleteScSendingDetails(DeleteScDetailsCM deleteScDetailsCM);

        GetScMasterQM GetScMaster();

        string GetSCSendingDCNumber(int DcNumberFor);

        GetScDetailsAndSerialsQM GetSubContractDetailAndSerials(Int64 VendorCode, string SubContractDcNumber);

        void AddSubContractReceiveMasterDetails(DateTime ScReceivingDcDate, string ScReceivingDcNumber, Int64 VendorCode, string VendorDCNumber, DateTime ScReceivingVendorDate, string Vehicle, string Remarks);

        void AddScReceivingDetails(string ScReceivingNumber, string WoNumber, decimal WoSerial, decimal PartCode);

        void AddScReceivingSerial(ScReceivingDetailSerialCM scReceivingDetailSerialCM);

        GetSubContractReceivingResponseQM GetSubContractReceivingDetails(Int64 VendorCode);

        GetScReceivingDetailsAndSerialsQM GetScReceivingDetailAndSerials(Int64 VendorCode, string SubContractDcNumber);

        GetScReceivingMasterQM GetScReceivingMaster();

    }
}
