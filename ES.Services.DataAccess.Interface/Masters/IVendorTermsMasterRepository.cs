using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Interface.Masters
{
   public interface IVendorTermsMasterRepository
    {
        AddVendorTermsMasterQM AddVendorTermsMaster(AddVendorTermsMasterCM addVendorTermsMasterCM);

        UpdateVendorTermsMasterQM UpdateVendorTermsMaster(UpdateVendorTermsMasterCM updateVendorTermsMasterCM);

        DeleteVendorTermsMasterQM DeleteVendorTermsMaster(DeleteVendorTermsMasterCM deleteVendorTermsMasterCM);

        GetVendorTermsMasterQM GetVendorTermsMaster();
    }
}
