using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class UpdateGroupMasterCM
    {
        public decimal GroupCode { get; set; }

        public string GroupDescription { get; set; }

        public string UpdatedBy { get; set; }
    }
}
