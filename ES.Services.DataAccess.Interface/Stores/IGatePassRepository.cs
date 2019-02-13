using ES.Services.DataAccess.Model.QueryModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Stores
{
    public interface IGatePassRepository
    {
        GPTypeMasterQM getGPTypeMaster();
        string getGPSendingNumber(string gpType);
        string getGPReceiptNumber();
        GetGPReceiptVendorQM getGPReceiptVendor();
    }
}
