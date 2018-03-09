using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataTransferObjects.Response.Despatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Despatch
{
    public interface IDeliveryChallanRepository
    {
        GetDcTypeQM GetDcType();

        GetWOMasterForDcQM GetWoMasterForDc(long vendorCode, string woType);

        GetSerialNoFromWoNumerWoSerialQM GetSerialNoFromWoNumerWoSerialForDc(string woNumber, decimal woSerial);

        string GetDCNumber(string woType);

        void AddDcMasterDetails(string WorkOrderType, DateTime DcDate, string DcNumber,  Int64 VendorCode, string DcType, string VehicleNo, bool Billable);

        void AddDcDetails(string DcNumber, string WoNumber, decimal DcSerial, Int64 PartCode, decimal Quantity, string Remarks, bool InvoicedTag, int WoSerial);

        void AddDcSerial(DcDetailSerialCM dcDetailSerialCM);

        GetDcMasterQM GetDcMaster();

        GetWoMasterAndDetailsFromCustomerCodeTypeQM GetWoMasterAndDetails(long vendorCode, string woType, string DcNumber, bool Invoiced);

        void DeleteDcDetails(DeleteDcDetailsCM deleteDcDetailsCM);

        void UpdateDcDetails(string DcNumber, string WoNumber, decimal DcSerial, decimal Quantity, int WoSerial);
    }
}
