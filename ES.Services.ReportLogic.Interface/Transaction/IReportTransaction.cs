using ES.Services.DataTransferObjects.Response.Masters;
using ES.Services.DataTransferObjects.Response.Sales;
using ES.Services.DataTransferObjects.Response.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.ReportLogic.Interface.Transaction
{
    public interface IReportTransaction
    {
        GetPoNumberResponseDto GetPoNumber();

        GetVendorTermsMasterResponseDto GetVendorTermsMaster(Int64 vendorCode);

        GetRateMasterDetailsFromVendorCodeResponseDto GetRateMasterDetailsFromVendorCode(Int64 vendorCode, decimal ItemCode);

        GetPoResponseDto GetPoMasterAndDetails();

        GetGRNFromVendorCodeResponseDto GetGRNDetailsFromVendorCode(Int64 vendorCode);
    }
}
