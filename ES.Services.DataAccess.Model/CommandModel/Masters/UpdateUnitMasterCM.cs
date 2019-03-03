using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class UpdateUnitMasterCM
    {
        public decimal UOMCode { get; set; }

        public string UOMDescription { get; set; }

        public string UpdatedBy { get; set; }
    }
}
